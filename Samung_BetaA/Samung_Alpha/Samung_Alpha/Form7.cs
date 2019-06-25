using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Viewer
{
    public partial class Form7 : Form
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        

        public delegate void ChangeLabelDelegate(int x, int y);

        public void ChangeLabel(int x, int y)
        {
            this.label1.Text = (x.ToString() + "," + y.ToString());
        }

        int x;
        int y;
        string key;

        public Form7()
        {
            InitializeComponent();/*
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Label.CheckForIllegalCrossThreadCalls = false;
            label2.Text = "";
            Thread t = new Thread(new ThreadStart(TrackMouse));
            t.Start();*/
        }



        private void Form6_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Clip = this.Bounds;
        }

        public void TrackMouse()
        {

            ChangeLabelDelegate del = new ChangeLabelDelegate(ChangeLabel);
            while(true)
            {
                x = Cursor.Position.X;
                y = Cursor.Position.Y;
                Cursor.Position = new Point(0,0);
            }
        }

        public void KeyboardPress()
        {
            SendKeys.SendWait(("{"+key+"}"));
        }

        public void MouseMove()
        {
            Cursor.Position = new Point(x,y);
        }

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F7)
            {
                this.Close();
            }
            else
            {
                key = e.KeyData.ToString();
                label2.Text = e.KeyData.ToString();
            }
        }
    }
}
