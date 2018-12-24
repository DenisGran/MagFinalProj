namespace Samung_Alpha
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConnectButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SignInButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(538, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Beta";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(586, 23);
            this.label2.TabIndex = 4;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(586, 23);
            this.label3.TabIndex = 5;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Change Password?";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ConnectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectButton.BorderRadius = 0;
            this.ConnectButton.ButtonText = "Connect to User";
            this.ConnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectButton.DisabledColor = System.Drawing.Color.Gray;
            this.ConnectButton.Iconcolor = System.Drawing.Color.Transparent;
            this.ConnectButton.Iconimage = null;
            this.ConnectButton.Iconimage_right = null;
            this.ConnectButton.Iconimage_right_Selected = null;
            this.ConnectButton.Iconimage_Selected = null;
            this.ConnectButton.IconMarginLeft = 0;
            this.ConnectButton.IconMarginRight = 0;
            this.ConnectButton.IconRightVisible = true;
            this.ConnectButton.IconRightZoom = 0D;
            this.ConnectButton.IconVisible = true;
            this.ConnectButton.IconZoom = 90D;
            this.ConnectButton.IsTab = false;
            this.ConnectButton.Location = new System.Drawing.Point(256, 257);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.ConnectButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.ConnectButton.OnHoverTextColor = System.Drawing.Color.White;
            this.ConnectButton.selected = false;
            this.ConnectButton.Size = new System.Drawing.Size(95, 48);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect to User";
            this.ConnectButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ConnectButton.Textcolor = System.Drawing.Color.White;
            this.ConnectButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // SignInButton
            // 
            this.SignInButton.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SignInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SignInButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SignInButton.BorderRadius = 0;
            this.SignInButton.ButtonText = "Sign In";
            this.SignInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignInButton.DisabledColor = System.Drawing.Color.Gray;
            this.SignInButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SignInButton.Iconimage = null;
            this.SignInButton.Iconimage_right = null;
            this.SignInButton.Iconimage_right_Selected = null;
            this.SignInButton.Iconimage_Selected = null;
            this.SignInButton.IconMarginLeft = 0;
            this.SignInButton.IconMarginRight = 0;
            this.SignInButton.IconRightVisible = true;
            this.SignInButton.IconRightZoom = 0D;
            this.SignInButton.IconVisible = true;
            this.SignInButton.IconZoom = 90D;
            this.SignInButton.IsTab = false;
            this.SignInButton.Location = new System.Drawing.Point(256, 203);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.SignInButton.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.SignInButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SignInButton.selected = false;
            this.SignInButton.Size = new System.Drawing.Size(95, 48);
            this.SignInButton.TabIndex = 9;
            this.SignInButton.Text = "Sign In";
            this.SignInButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SignInButton.Textcolor = System.Drawing.Color.White;
            this.SignInButton.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(607, 404);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuFlatButton ConnectButton;
        private Bunifu.Framework.UI.BunifuFlatButton SignInButton;
    }
}

