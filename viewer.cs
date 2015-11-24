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
    public partial class viewer : Form
    {
        public viewer()
        {
            InitializeComponent();
        }

        

        private void viewer_Load(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            foreach(string item in Form1.queue)
            {
                string res = readlist(item);
                temp.Add(res);
            }
            lbqueue.DataSource = temp;
        }

        public static string readlist(string item)
        {
            if (item.Length > 20)
            {
                string sub = item.Substring(0, 20);
                sub += "...";
                return sub;
            }
            else
            {
                return item;
            }
        }

        private void lbqueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbqueue.SelectedIndex != -1)
            {
                rtbShow.Text = Form1.queue[lbqueue.SelectedIndex];
            }
            else
            {
                btnSelect.Enabled = false;
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Form1.queue.RemoveRange(0, Form1.queue.Count);
            lbqueue.DataSource = null;
            lbqueue.DataSource = Form1.queue;
            rtbShow.Text = "";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Form1.copy = false;
            Form1.t.changetext("the snippet \"" + readlist(Form1.queue[lbqueue.SelectedIndex]) + "\"has been copied to the clipboard","snippet copied");
            Clipboard.SetText(Form1.queue[lbqueue.SelectedIndex], TextDataFormat.UnicodeText);
            Form1.copy = true;
        }
    }
}
