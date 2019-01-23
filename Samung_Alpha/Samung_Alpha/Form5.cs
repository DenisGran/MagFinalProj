using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha
{
    public partial class Form5 : Form
    {
        public static string requestingUid = "Unknown";
        public static string un1;

        public Form5(string requestingUID)
        {
            
            
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Form1.isConnectedToUser = true;
            Form1.sendToServer("con,"+requestingUid);
            MessageBox.Show("You are now connected to user " + requestingUid);
            this.Close();
        }

        private void rejBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            fromUserLabel.Text = requestingUid;
        }
    }
}
