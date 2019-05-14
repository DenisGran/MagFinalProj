using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Viewer
{
    public partial class ConnectionRequestForm : Form
    {
        public static string requestingUid = "Unknown";

        public ConnectionRequestForm(string requestingUID)
        {
            InitializeComponent();
            requestingUid = requestingUID;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            MainMenuForm.isConnectedToUser = true;
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
