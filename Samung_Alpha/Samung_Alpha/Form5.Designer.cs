namespace Samung_Alpha
{
    partial class Form5
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
            this.okBtn = new System.Windows.Forms.Button();
            this.rejBtn = new System.Windows.Forms.Button();
            this.fromUserLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(25, 186);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "Accept";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // rejBtn
            // 
            this.rejBtn.Location = new System.Drawing.Point(178, 185);
            this.rejBtn.Name = "rejBtn";
            this.rejBtn.Size = new System.Drawing.Size(75, 23);
            this.rejBtn.TabIndex = 1;
            this.rejBtn.Text = "Reject";
            this.rejBtn.UseVisualStyleBackColor = true;
            this.rejBtn.Click += new System.EventHandler(this.rejBtn_Click);
            // 
            // fromUserLabel
            // 
            this.fromUserLabel.AutoSize = true;
            this.fromUserLabel.Location = new System.Drawing.Point(86, 35);
            this.fromUserLabel.Name = "fromUserLabel";
            this.fromUserLabel.Size = new System.Drawing.Size(93, 13);
            this.fromUserLabel.TabIndex = 2;
            this.fromUserLabel.Text = "[Connection From]";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(70, 69);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(124, 13);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "wants to connect to you!";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.fromUserLabel);
            this.Controls.Add(this.rejBtn);
            this.Controls.Add(this.okBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection request";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button rejBtn;
        private System.Windows.Forms.Label fromUserLabel;
        private System.Windows.Forms.Label infoLabel;
    }
}