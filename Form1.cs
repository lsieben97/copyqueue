using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CopyQueue
{
    public partial class Form1 : Form
    {
        public bool record = true;
        public static bool copy;
        public static List<string> queue = new List<string>();
        ClipboardNotification clp = new ClipboardNotification();
        KeyboardHook hook = new KeyboardHook();
        public static test t = new test();
        Timer tim = new Timer();
        public Form1()
        {
            InitializeComponent();
            copy = true;
            t.not.MouseClick += not_MouseClick;
            t.not.BalloonTipShown +=not_BalloonTipShown;
            t.not.BalloonTipClosed += not_BalloonTipClosed;
            t.not.ContextMenuStrip = cmsIcon;
            
        }

        void not_BalloonTipClosed(object sender, EventArgs e)
        {
            t.not.BalloonTipClicked += not_BalloonTipClicked;
        }

        void not_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                viewer vw = new viewer();
                vw.ShowDialog();
            }
        }

        void not_BalloonTipClicked(object sender, EventArgs e)
        {
            viewer vw = new viewer();
            vw.ShowDialog();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
            ClipboardNotification.ClipboardUpdate += ClipboardNotification_ClipboardUpdate;
            hook.KeyPressed += hook_KeyPressed;
            hook.RegisterHotKey(CopyQueue.ModifierKeys.Control | CopyQueue.ModifierKeys.Shift, Keys.S);
            KeyboardHook hook2 = new KeyboardHook();
            hook2.KeyPressed += hook2_KeyPressed;
            hook2.RegisterHotKey(CopyQueue.ModifierKeys.Control | CopyQueue.ModifierKeys.Shift, Keys.V);
            t.changetext("Copy Queue is now running, right click this icon for more options, for a quick guide click on Help!", "Welcome to Copy Queue!");
            
        }

        void hook2_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Selector s = new Selector();
            s.ShowDialog();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            viewer vw = new viewer();
            vw.ShowDialog();
        }

        void ClipboardNotification_ClipboardUpdate(object sender, EventArgs e)
        {
            if (record)
            {
                if (!inArray(Clipboard.GetText(TextDataFormat.UnicodeText)))
                {

                    queue.Add(Clipboard.GetText(TextDataFormat.UnicodeText));
                    if (queue.Count == 1)
                    {
                        t.not.Visible = true;
                        //t.not.BalloonTipShown += not_BalloonTipShown;
                        t.changetext("your queue contains 1 element", "Snippet added to queue.");
                    }
                    else
                    {
                        t.not.Visible = true;
                        //t.not.BalloonTipShown += not_BalloonTipShown;
                        t.changetext(string.Format("your queue contains {0} elements", queue.Count), "Snippet added to queue.");
                    }
                }
            }
        }
        private bool inArray(string content)
        {
            foreach(string text in queue)
            {
                if(text == content)
                {
                    return true;
                }
            }
            return false;
        }

        void not_BalloonTipShown(object sender, EventArgs e)
        {
            t.not.BalloonTipClicked -= not_BalloonTipClicked;

        }


        private void Exit_Click(object sender, EventArgs e)
        {
            t.not.Dispose();
            Application.Exit();
        }

        private void stopSnippetRecordingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stopSnippetRecordingToolStripMenuItem.Checked)
            {
                record = true;
            }
            else
            {
                record = false;
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            helpform h = new helpform();
            h.ShowDialog();
            
        }

       
    }
    public class test
    {
        public test()
        {
           not = new NotifyIcon();
           not.Visible = true;
            not.Icon = new System.Drawing.Icon("default.ico");
        }
        public void changetext(string text, string cap)
        {
            not.ShowBalloonTip(1, cap, text, ToolTipIcon.Info);
        }
        public void hide()
        {
            not.Visible = false;
        }
        public System.Windows.Forms.NotifyIcon not;

    }
    public sealed class ClipboardNotification
    {
        /// <summary>
        /// Occurs when the contents of the clipboard is updated.
        /// </summary>
        public static event EventHandler ClipboardUpdate;

        private static NotificationForm _form = new NotificationForm();

        /// <summary>
        /// Raises the <see cref="ClipboardUpdate"/> event.
        /// </summary>
        /// <param name="e">Event arguments for the event.</param>
        private static void OnClipboardUpdate(EventArgs e)
        {
            var handler = ClipboardUpdate;
            if (handler != null)
            {
                handler(null, e);
            }
        }

        /// <summary>
        /// Hidden form to recieve the WM_CLIPBOARDUPDATE message.
        /// </summary>
        private class NotificationForm : Form
        {
            public NotificationForm()
            {
                NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
                NativeMethods.AddClipboardFormatListener(Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
                {
                    OnClipboardUpdate(null);
                }
                base.WndProc(ref m);
            }
        }
    }

    internal static class NativeMethods
    {
        // See http://msdn.microsoft.com/en-us/library/ms649021%28v=vs.85%29.aspx
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        // See http://msdn.microsoft.com/en-us/library/ms632599%28VS.85%29.aspx#message_only
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        // See http://msdn.microsoft.com/en-us/library/ms633541%28v=vs.85%29.aspx
        // See http://msdn.microsoft.com/en-us/library/ms649033%28VS.85%29.aspx
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
    public sealed class KeyboardHook : IDisposable
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate(object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }



}
