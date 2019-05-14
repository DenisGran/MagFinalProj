using System;
using System.Windows.Forms;

namespace Desktop_Viewer
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainMenuForm.ChangePass(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Password Change Succesful");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password Change Failed \nWrong Password");
            }
        }
    }
}
