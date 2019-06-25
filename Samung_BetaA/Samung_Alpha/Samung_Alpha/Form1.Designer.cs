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
            this.changePasswordLabel = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.mnmzBtn = new System.Windows.Forms.Button();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.topBar = new System.Windows.Forms.PictureBox();
            this.sginBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.connectBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.allowConnectionBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.sessionStatusBtn = new System.Windows.Forms.Label();
            this.loginStatusBtn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBar)).BeginInit();
            this.SuspendLayout();
            // 
            // changePasswordLabel
            // 
            this.changePasswordLabel.AutoSize = true;
            this.changePasswordLabel.Location = new System.Drawing.Point(8, 426);
            this.changePasswordLabel.Name = "changePasswordLabel";
            this.changePasswordLabel.Size = new System.Drawing.Size(93, 13);
            this.changePasswordLabel.TabIndex = 6;
            this.changePasswordLabel.Text = "Change Password";
            this.changePasswordLabel.Click += new System.EventHandler(this.newPasswordLabel_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(187, 9);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(30, 25);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // mnmzBtn
            // 
            this.mnmzBtn.Location = new System.Drawing.Point(151, 9);
            this.mnmzBtn.Name = "mnmzBtn";
            this.mnmzBtn.Size = new System.Drawing.Size(30, 25);
            this.mnmzBtn.TabIndex = 8;
            this.mnmzBtn.Text = "_";
            this.mnmzBtn.UseVisualStyleBackColor = true;
            this.mnmzBtn.Click += new System.EventHandler(this.mnmzBtn_Click);
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.Transparent;
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoBox.Image = global::Samung_Alpha.Properties.Resources._8ff044b0_13a9_4fed_92b5_1539cbee163e;
            this.logoBox.Location = new System.Drawing.Point(12, 40);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(209, 203);
            this.logoBox.TabIndex = 13;
            this.logoBox.TabStop = false;
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(50)))), ((int)(((byte)(67)))));
            this.topBar.Location = new System.Drawing.Point(0, -6);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(269, 40);
            this.topBar.TabIndex = 9;
            this.topBar.TabStop = false;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barPctr_MouseDown);
            // 
            // sginBtn
            // 
            this.sginBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.sginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(130)))), ((int)(((byte)(201)))));
            this.sginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sginBtn.BorderRadius = 0;
            this.sginBtn.ButtonText = "Sign In";
            this.sginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sginBtn.DisabledColor = System.Drawing.Color.Gray;
            this.sginBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sginBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.sginBtn.Iconimage = null;
            this.sginBtn.Iconimage_right = null;
            this.sginBtn.Iconimage_right_Selected = null;
            this.sginBtn.Iconimage_Selected = null;
            this.sginBtn.IconMarginLeft = 0;
            this.sginBtn.IconMarginRight = 0;
            this.sginBtn.IconRightVisible = true;
            this.sginBtn.IconRightZoom = 0D;
            this.sginBtn.IconVisible = true;
            this.sginBtn.IconZoom = 90D;
            this.sginBtn.IsTab = false;
            this.sginBtn.Location = new System.Drawing.Point(11, 251);
            this.sginBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sginBtn.Name = "sginBtn";
            this.sginBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.sginBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.sginBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.sginBtn.selected = false;
            this.sginBtn.Size = new System.Drawing.Size(209, 47);
            this.sginBtn.TabIndex = 14;
            this.sginBtn.Text = "Sign In";
            this.sginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sginBtn.Textcolor = System.Drawing.Color.White;
            this.sginBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sginBtn.Click += new System.EventHandler(this.signinBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.connectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(130)))), ((int)(((byte)(201)))));
            this.connectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectBtn.BorderRadius = 0;
            this.connectBtn.ButtonText = "Connect to User";
            this.connectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectBtn.DisabledColor = System.Drawing.Color.Gray;
            this.connectBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.connectBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.connectBtn.Iconimage = null;
            this.connectBtn.Iconimage_right = null;
            this.connectBtn.Iconimage_right_Selected = null;
            this.connectBtn.Iconimage_Selected = null;
            this.connectBtn.IconMarginLeft = 0;
            this.connectBtn.IconMarginRight = 0;
            this.connectBtn.IconRightVisible = true;
            this.connectBtn.IconRightZoom = 0D;
            this.connectBtn.IconVisible = true;
            this.connectBtn.IconZoom = 90D;
            this.connectBtn.IsTab = false;
            this.connectBtn.Location = new System.Drawing.Point(11, 308);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.connectBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.connectBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.connectBtn.selected = false;
            this.connectBtn.Size = new System.Drawing.Size(210, 49);
            this.connectBtn.TabIndex = 15;
            this.connectBtn.Text = "Connect to User";
            this.connectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectBtn.Textcolor = System.Drawing.Color.White;
            this.connectBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // allowConnectionBtn
            // 
            this.allowConnectionBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.allowConnectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(130)))), ((int)(((byte)(201)))));
            this.allowConnectionBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.allowConnectionBtn.BorderRadius = 0;
            this.allowConnectionBtn.ButtonText = "Allowing Connections";
            this.allowConnectionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.allowConnectionBtn.DisabledColor = System.Drawing.Color.Gray;
            this.allowConnectionBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.allowConnectionBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.allowConnectionBtn.Iconimage = null;
            this.allowConnectionBtn.Iconimage_right = null;
            this.allowConnectionBtn.Iconimage_right_Selected = null;
            this.allowConnectionBtn.Iconimage_Selected = null;
            this.allowConnectionBtn.IconMarginLeft = 0;
            this.allowConnectionBtn.IconMarginRight = 0;
            this.allowConnectionBtn.IconRightVisible = true;
            this.allowConnectionBtn.IconRightZoom = 0D;
            this.allowConnectionBtn.IconVisible = true;
            this.allowConnectionBtn.IconZoom = 90D;
            this.allowConnectionBtn.IsTab = false;
            this.allowConnectionBtn.Location = new System.Drawing.Point(12, 365);
            this.allowConnectionBtn.Name = "allowConnectionBtn";
            this.allowConnectionBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.allowConnectionBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.allowConnectionBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.allowConnectionBtn.selected = false;
            this.allowConnectionBtn.Size = new System.Drawing.Size(209, 48);
            this.allowConnectionBtn.TabIndex = 16;
            this.allowConnectionBtn.Text = "Allowing Connections";
            this.allowConnectionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.allowConnectionBtn.Textcolor = System.Drawing.Color.White;
            this.allowConnectionBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allowConnectionBtn.Click += new System.EventHandler(this.allowConnectionBtn_Click);
            // 
            // sessionStatusBtn
            // 
            this.sessionStatusBtn.AutoSize = true;
            this.sessionStatusBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.sessionStatusBtn.Location = new System.Drawing.Point(8, 485);
            this.sessionStatusBtn.Name = "sessionStatusBtn";
            this.sessionStatusBtn.Size = new System.Drawing.Size(0, 13);
            this.sessionStatusBtn.TabIndex = 17;
            // 
            // loginStatusBtn
            // 
            this.loginStatusBtn.AutoSize = true;
            this.loginStatusBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.loginStatusBtn.Location = new System.Drawing.Point(8, 456);
            this.loginStatusBtn.Name = "loginStatusBtn";
            this.loginStatusBtn.Size = new System.Drawing.Size(0, 13);
            this.loginStatusBtn.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(233, 507);
            this.Controls.Add(this.loginStatusBtn);
            this.Controls.Add(this.sessionStatusBtn);
            this.Controls.Add(this.allowConnectionBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.sginBtn);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.mnmzBtn);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.changePasswordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label changePasswordLabel;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button mnmzBtn;
        private System.Windows.Forms.PictureBox topBar;
        private System.Windows.Forms.PictureBox logoBox;
        private Bunifu.Framework.UI.BunifuFlatButton sginBtn;
        private Bunifu.Framework.UI.BunifuFlatButton connectBtn;
        private Bunifu.Framework.UI.BunifuFlatButton allowConnectionBtn;
        private System.Windows.Forms.Label sessionStatusBtn;
        private System.Windows.Forms.Label loginStatusBtn;
    }
}

