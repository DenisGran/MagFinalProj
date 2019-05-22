namespace Desktop_Viewer
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.writeBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new Bunifu.Framework.UI.BunifuThinButton2();
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
            this.writeBox.Size = new System.Drawing.Size(391, 46);
            this.writeBox.TabIndex = 1;
            this.writeBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.ActiveBorderThickness = 1;
            this.sendButton.ActiveCornerRadius = 20;
            this.sendButton.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.sendButton.ActiveForecolor = System.Drawing.Color.White;
            this.sendButton.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(50)))), ((int)(((byte)(67)))));
            this.sendButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendButton.BackgroundImage")));
            this.sendButton.ButtonText = "Send";
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.SeaGreen;
            this.sendButton.IdleBorderThickness = 1;
            this.sendButton.IdleCornerRadius = 20;
            this.sendButton.IdleFillColor = System.Drawing.Color.White;
            this.sendButton.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.sendButton.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.sendButton.Location = new System.Drawing.Point(411, 405);
            this.sendButton.Margin = new System.Windows.Forms.Padding(5);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(95, 46);
            this.sendButton.TabIndex = 2;
            this.sendButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(50)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(518, 463);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.writeBox);
            this.Controls.Add(this.chatBox);
            this.Name = "ChatForm";
            this.Text = "Chat";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form8_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.RichTextBox writeBox;
        private Bunifu.Framework.UI.BunifuThinButton2 sendButton;
    }
}