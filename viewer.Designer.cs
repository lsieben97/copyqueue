namespace CopyQueue
{
    partial class viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewer));
            this.lbqueue = new System.Windows.Forms.ListBox();
            this.rtbShow = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbqueue
            // 
            this.lbqueue.FormattingEnabled = true;
            this.lbqueue.Location = new System.Drawing.Point(12, 12);
            this.lbqueue.Name = "lbqueue";
            this.lbqueue.Size = new System.Drawing.Size(759, 147);
            this.lbqueue.TabIndex = 0;
            this.lbqueue.SelectedIndexChanged += new System.EventHandler(this.lbqueue_SelectedIndexChanged);
            // 
            // rtbShow
            // 
            this.rtbShow.Location = new System.Drawing.Point(12, 165);
            this.rtbShow.Name = "rtbShow";
            this.rtbShow.ReadOnly = true;
            this.rtbShow.Size = new System.Drawing.Size(759, 184);
            this.rtbShow.TabIndex = 1;
            this.rtbShow.Text = "Snippets you copy will appear here.";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 355);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear queue";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(696, 355);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 384);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbShow);
            this.Controls.Add(this.lbqueue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "viewer";
            this.Text = "Copy Queue - Viewer";
            this.Load += new System.EventHandler(this.viewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbqueue;
        private System.Windows.Forms.RichTextBox rtbShow;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSelect;

    }
}