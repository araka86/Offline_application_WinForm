using CartrigeAltstar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class Reception : Form
    {
        ContexAltstarContext db;
        public Reception()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reception_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
