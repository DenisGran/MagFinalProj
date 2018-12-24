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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.sginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loginStatusBtn = new System.Windows.Forms.Label();
            this.sessionStatusBtn = new System.Windows.Forms.Label();
            this.changePasswordLabel = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.mnmzBtn = new System.Windows.Forms.Button();
            this.topBar = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.loadingGifBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGifBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(246, 272);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(123, 43);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.TabStop = false;
            this.connectBtn.Text = "Connect to user";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // sginBtn
            // 
            this.sginBtn.Location = new System.Drawing.Point(246, 224);
            this.sginBtn.Name = "sginBtn";
            this.sginBtn.Size = new System.Drawing.Size(123, 42);
            this.sginBtn.TabIndex = 2;
            this.sginBtn.TabStop = false;
            this.sginBtn.Text = "Sign In";
            this.sginBtn.UseVisualStyleBackColor = true;
            this.sginBtn.Click += new System.EventHandler(this.signinBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(532, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alpha";
            // 
            // loginStatusBtn
            // 
            this.loginStatusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginStatusBtn.Location = new System.Drawing.Point(9, 347);
            this.loginStatusBtn.Name = "loginStatusBtn";
            this.loginStatusBtn.Size = new System.Drawing.Size(586, 23);
            this.loginStatusBtn.TabIndex = 4;
            this.loginStatusBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sessionStatusBtn
            // 
            this.sessionStatusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionStatusBtn.Location = new System.Drawing.Point(9, 376);
            this.sessionStatusBtn.Name = "sessionStatusBtn";
            this.sessionStatusBtn.Size = new System.Drawing.Size(586, 23);
            this.sessionStatusBtn.TabIndex = 5;
            this.sessionStatusBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // changePasswordLabel
            // 
            this.changePasswordLabel.AutoSize = true;
            this.changePasswordLabel.Location = new System.Drawing.Point(12, 210);
            this.changePasswordLabel.Name = "changePasswordLabel";
            this.changePasswordLabel.Size = new System.Drawing.Size(93, 13);
            this.changePasswordLabel.TabIndex = 6;
            this.changePasswordLabel.Text = "Change Password";
            this.changePasswordLabel.Click += new System.EventHandler(this.newPasswordLabel_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(567, 4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(30, 25);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // mnmzBtn
            // 
            this.mnmzBtn.Location = new System.Drawing.Point(533, 4);
            this.mnmzBtn.Name = "mnmzBtn";
            this.mnmzBtn.Size = new System.Drawing.Size(30, 25);
            this.mnmzBtn.TabIndex = 8;
            this.mnmzBtn.Text = "_";
            this.mnmzBtn.UseVisualStyleBackColor = true;
            this.mnmzBtn.Click += new System.EventHandler(this.mnmzBtn_Click);
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.topBar.Location = new System.Drawing.Point(0, -6);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(610, 40);
            this.topBar.TabIndex = 9;
            this.topBar.TabStop = false;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barPctr_MouseDown);
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingLabel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.loadingLabel.Location = new System.Drawing.Point(15, 331);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(56, 15);
            this.loadingLabel.TabIndex = 10;
            this.loadingLabel.Text = "Loading...";
            this.loadingLabel.UseWaitCursor = true;
            // 
            // loadingGifBox
            // 
            this.loadingGifBox.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.loadingGifBox.Image = global::Samung_Alpha.Properties.Resources.loadingGif;
            this.loadingGifBox.Location = new System.Drawing.Point(31, 288);
            this.loadingGifBox.Name = "loadingGifBox";
            this.loadingGifBox.Size = new System.Drawing.Size(40, 40);
            this.loadingGifBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingGifBox.TabIndex = 11;
            this.loadingGifBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 405);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.loadingGifBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.mnmzBtn);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.changePasswordLabel);
            this.Controls.Add(this.sessionStatusBtn);
            this.Controls.Add(this.loginStatusBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sginBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Samung";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingGifBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button sginBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label loginStatusBtn;
        private System.Windows.Forms.Label sessionStatusBtn;
        private System.Windows.Forms.Label changePasswordLabel;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button mnmzBtn;
        private System.Windows.Forms.PictureBox topBar;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.PictureBox loadingGifBox;
    }
}

