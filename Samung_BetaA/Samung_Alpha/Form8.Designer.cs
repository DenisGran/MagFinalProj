namespace Samung_Alpha
{
    partial class Form8
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
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.writeBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatBox.Location = new System.Drawing.Point(12, 37);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(494, 362);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";
            // 
            // writeBox
            // 
            this.writeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.writeBox.Location = new System.Drawing.Point(12, 405);
            this.writeBox.Name = "writeBox";
            this.writeBox.Size = new System.Drawing.Size(494, 46);
            this.writeBox.TabIndex = 1;
            this.writeBox.Text = "";
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(50)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(518, 463);
            this.Controls.Add(this.writeBox);
            this.Controls.Add(this.chatBox);
            this.Name = "Form8";
            this.Text = "Form8";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form8_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.RichTextBox writeBox;
    }
}