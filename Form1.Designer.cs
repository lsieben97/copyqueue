namespace CopyQueue
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stopSnippetRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSnipets = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.selectSnippet = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsIcon
            // 
            this.cmsIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectSnippet,
            this.showSnipets,
            this.stopSnippetRecordingToolStripMenuItem,
            this.help,
            this.Exit});
            this.cmsIcon.Name = "cmsIcon";
            this.cmsIcon.Size = new System.Drawing.Size(159, 136);
            // 
            // stopSnippetRecordingToolStripMenuItem
            // 
            this.stopSnippetRecordingToolStripMenuItem.Checked = true;
            this.stopSnippetRecordingToolStripMenuItem.CheckOnClick = true;
            this.stopSnippetRecordingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stopSnippetRecordingToolStripMenuItem.Name = "stopSnippetRecordingToolStripMenuItem";
            this.stopSnippetRecordingToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.stopSnippetRecordingToolStripMenuItem.Text = "Record snippets";
            this.stopSnippetRecordingToolStripMenuItem.Click += new System.EventHandler(this.stopSnippetRecordingToolStripMenuItem_Click);
            // 
            // showSnipets
            // 
            this.showSnipets.Name = "showSnipets";
            this.showSnipets.Size = new System.Drawing.Size(158, 22);
            this.showSnipets.Text = "Show snippets";
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(158, 22);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // selectSnippet
            // 
            this.selectSnippet.Name = "selectSnippet";
            this.selectSnippet.Size = new System.Drawing.Size(158, 22);
            this.selectSnippet.Text = "Select snippet";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(158, 22);
            this.help.Text = "Help";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsIcon;
        private System.Windows.Forms.ToolStripMenuItem showSnipets;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem stopSnippetRecordingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectSnippet;
        private System.Windows.Forms.ToolStripMenuItem help;

    }
}

