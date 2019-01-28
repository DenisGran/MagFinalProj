namespace Samung_Alpha
{
    partial class Form6
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
            this.thisUserLabel = new System.Windows.Forms.Label();
            this.serverInformationLabel = new System.Windows.Forms.Label();
            this.yourInformationLbl = new System.Windows.Forms.Label();
            this.serverIPLbl = new System.Windows.Forms.Label();
            this.serverPortLbl = new System.Windows.Forms.Label();
            this.statusTitleText = new System.Windows.Forms.Label();
            this.actualStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // thisUserLabel
            // 
            this.thisUserLabel.AutoSize = true;
            this.thisUserLabel.Location = new System.Drawing.Point(12, 54);
            this.thisUserLabel.Name = "thisUserLabel";
            this.thisUserLabel.Size = new System.Drawing.Size(47, 13);
            this.thisUserLabel.TabIndex = 0;
            this.thisUserLabel.Text = "You are:";
            // 
            // serverInformationLabel
            // 
            this.serverInformationLabel.AutoSize = true;
            this.serverInformationLabel.Location = new System.Drawing.Point(444, 13);
            this.serverInformationLabel.Name = "serverInformationLabel";
            this.serverInformationLabel.Size = new System.Drawing.Size(96, 13);
            this.serverInformationLabel.TabIndex = 1;
            this.serverInformationLabel.Text = "Server Information:";
            // 
            // yourInformationLbl
            // 
            this.yourInformationLbl.AutoSize = true;
            this.yourInformationLbl.Location = new System.Drawing.Point(13, 13);
            this.yourInformationLbl.Name = "yourInformationLbl";
            this.yourInformationLbl.Size = new System.Drawing.Size(58, 13);
            this.yourInformationLbl.TabIndex = 2;
            this.yourInformationLbl.Text = "About you:";
            // 
            // serverIPLbl
            // 
            this.serverIPLbl.AutoSize = true;
            this.serverIPLbl.Location = new System.Drawing.Point(444, 54);
            this.serverIPLbl.Name = "serverIPLbl";
            this.serverIPLbl.Size = new System.Drawing.Size(52, 13);
            this.serverIPLbl.TabIndex = 3;
            this.serverIPLbl.Text = "127.0.0.1";
            // 
            // serverPortLbl
            // 
            this.serverPortLbl.AutoSize = true;
            this.serverPortLbl.Location = new System.Drawing.Point(575, 54);
            this.serverPortLbl.Name = "serverPortLbl";
            this.serverPortLbl.Size = new System.Drawing.Size(13, 13);
            this.serverPortLbl.TabIndex = 4;
            this.serverPortLbl.Text = "0";
            // 
            // statusTitleText
            // 
            this.statusTitleText.AutoSize = true;
            this.statusTitleText.Location = new System.Drawing.Point(223, 13);
            this.statusTitleText.Name = "statusTitleText";
            this.statusTitleText.Size = new System.Drawing.Size(40, 13);
            this.statusTitleText.TabIndex = 5;
            this.statusTitleText.Text = "Status:";
            // 
            // actualStatusLabel
            // 
            this.actualStatusLabel.AutoSize = true;
            this.actualStatusLabel.Location = new System.Drawing.Point(223, 54);
            this.actualStatusLabel.Name = "actualStatusLabel";
            this.actualStatusLabel.Size = new System.Drawing.Size(56, 13);
            this.actualStatusLabel.TabIndex = 6;
            this.actualStatusLabel.Text = "-STATUS-";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 353);
            this.Controls.Add(this.actualStatusLabel);
            this.Controls.Add(this.statusTitleText);
            this.Controls.Add(this.serverPortLbl);
            this.Controls.Add(this.serverIPLbl);
            this.Controls.Add(this.yourInformationLbl);
            this.Controls.Add(this.serverInformationLabel);
            this.Controls.Add(this.thisUserLabel);
            this.Name = "Form6";
            this.Text = "Connecting...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form6_FormClosing);
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label thisUserLabel;
        private System.Windows.Forms.Label serverInformationLabel;
        private System.Windows.Forms.Label yourInformationLbl;
        private System.Windows.Forms.Label serverIPLbl;
        private System.Windows.Forms.Label serverPortLbl;
        private System.Windows.Forms.Label statusTitleText;
        private System.Windows.Forms.Label actualStatusLabel;
    }
}