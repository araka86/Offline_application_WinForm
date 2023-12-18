using System;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class О_программе : Form
    {
        public О_программе()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        

            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://altstar.com.ua");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
