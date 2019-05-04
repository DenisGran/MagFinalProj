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
            this.fromUserLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.okBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.rejBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // fromUserLabel
            // 
            this.fromUserLabel.AutoSize = true;
            this.fromUserLabel.Location = new System.Drawing.Point(93, 37);
            this.fromUserLabel.Name = "fromUserLabel";
            this.fromUserLabel.Size = new System.Drawing.Size(93, 13);
            this.fromUserLabel.TabIndex = 2;
            this.fromUserLabel.Text = "[Connection From]";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(78, 76);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(124, 13);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "wants to connect to you!";
            // 
            // okBtn
            // 
            this.okBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(130)))), ((int)(((byte)(201)))));
            this.okBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okBtn.BorderRadius = 0;
            this.okBtn.ButtonText = "Accept";
            this.okBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.okBtn.DisabledColor = System.Drawing.Color.Gray;
            this.okBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.okBtn.Iconimage = null;
            this.okBtn.Iconimage_right = null;
            this.okBtn.Iconimage_right_Selected = null;
            this.okBtn.Iconimage_Selected = null;
            this.okBtn.IconMarginLeft = 0;
            this.okBtn.IconMarginRight = 0;
            this.okBtn.IconRightVisible = true;
            this.okBtn.IconRightZoom = 0D;
            this.okBtn.IconVisible = true;
            this.okBtn.IconZoom = 90D;
            this.okBtn.IsTab = false;
            this.okBtn.Location = new System.Drawing.Point(25, 132);
            this.okBtn.Name = "okBtn";
            this.okBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.okBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.okBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.okBtn.selected = false;
            this.okBtn.Size = new System.Drawing.Size(75, 48);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "Accept";
            this.okBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.okBtn.Textcolor = System.Drawing.Color.White;
            this.okBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // rejBtn
            // 
            this.rejBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.rejBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(130)))), ((int)(((byte)(201)))));
            this.rejBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rejBtn.BorderRadius = 0;
            this.rejBtn.ButtonText = "Reject";
            this.rejBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rejBtn.DisabledColor = System.Drawing.Color.Gray;
            this.rejBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.rejBtn.Iconimage = null;
            this.rejBtn.Iconimage_right = null;
            this.rejBtn.Iconimage_right_Selected = null;
            this.rejBtn.Iconimage_Selected = null;
            this.rejBtn.IconMarginLeft = 0;
            this.rejBtn.IconMarginRight = 0;
            this.rejBtn.IconRightVisible = true;
            this.rejBtn.IconRightZoom = 0D;
            this.rejBtn.IconVisible = true;
            this.rejBtn.IconZoom = 90D;
            this.rejBtn.IsTab = false;
            this.rejBtn.Location = new System.Drawing.Point(178, 131);
            this.rejBtn.Name = "rejBtn";
            this.rejBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.rejBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.rejBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.rejBtn.selected = false;
            this.rejBtn.Size = new System.Drawing.Size(75, 48);
            this.rejBtn.TabIndex = 5;
            this.rejBtn.Text = "Reject";
            this.rejBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rejBtn.Textcolor = System.Drawing.Color.White;
            this.rejBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejBtn.Click += new System.EventHandler(this.rejBtn_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.rejBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.fromUserLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Label fromUserLabel;
        private System.Windows.Forms.Label infoLabel;
        private Bunifu.Framework.UI.BunifuFlatButton okBtn;
        private Bunifu.Framework.UI.BunifuFlatButton rejBtn;
    }
}