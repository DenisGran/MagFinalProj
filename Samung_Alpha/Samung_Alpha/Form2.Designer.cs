namespace Samung_Alpha
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.waitingForAnswerGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.waitingForAnswerGif)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect to user";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(187, 60);
            this.textBox1.MaxLength = 12;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "XX123456XXXX";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "USER ID";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(187, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // waitingLabel
            // 
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.BackColor = System.Drawing.Color.Transparent;
            this.waitingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLabel.Location = new System.Drawing.Point(151, 142);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.Size = new System.Drawing.Size(163, 16);
            this.waitingLabel.TabIndex = 7;
            this.waitingLabel.Text = "Waiting for response...";
            this.waitingLabel.Visible = false;
            // 
            // waitingForAnswerGif
            // 
            this.waitingForAnswerGif.BackColor = System.Drawing.Color.Transparent;
            this.waitingForAnswerGif.Image = global::Samung_Alpha.Properties.Resources.smallloadinggif;
            this.waitingForAnswerGif.Location = new System.Drawing.Point(187, 80);
            this.waitingForAnswerGif.Name = "waitingForAnswerGif";
            this.waitingForAnswerGif.Size = new System.Drawing.Size(75, 38);
            this.waitingForAnswerGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.waitingForAnswerGif.TabIndex = 8;
            this.waitingForAnswerGif.TabStop = false;
            this.waitingForAnswerGif.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(431, 166);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.waitingForAnswerGif);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to user";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.waitingForAnswerGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label waitingLabel;
        private System.Windows.Forms.PictureBox waitingForAnswerGif;
    }
}