using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CopyQueue
{
    public partial class Selector : Form
    {
        public Selector()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int result;
            bool isparsable = int.TryParse(tbNumber.Text,out result);
            if(isparsable)
            {
                if(result <= Form1.queue.Count)
                {
                    Clipboard.SetText(Form1.queue[result - 1], TextDataFormat.UnicodeText);
                    Form1.t.changetext("the snippet \"" + viewer.readlist(Form1.queue[result-1]) + "\"has been copied to the clipboard", "snippet copied");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(string.Format("There is no snippet at position {0}. the highest position is {1}", result, Form1.queue.Count));
                }
            }
            else
            {
                MessageBox.Show("That's not a number, please enter a whole number.");
            }
        }

        private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }

        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Selector_Load(object sender, EventArgs e)
        {
            tbNumber.Select();
        }
    }
}
