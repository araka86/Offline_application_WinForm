using CartrigeAltstar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class CartrigePlace : Form
    {
        ContexAltstarContext db;
        public CartrigePlace()
        {
            InitializeComponent();

            db = new ContexAltstarContext();

            db.Receptions.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CartrigeSubdivision cartrigeSubdivisionForm = new CartrigeSubdivision(); //екземпляр формы


           
               var crt = from ct1 in db.Cartriges select (ct1.ArticleCartrige);
               var div = from dv in db.Subdivisions select (dv.division);
           
           
               cartrigeSubdivisionForm.comboBoxSub.DataSource = div.ToList();
               cartrigeSubdivisionForm.comboBoxCartrige.DataSource = crt.ToList();




                 DialogResult result = cartrigeSubdivisionForm.ShowDialog(this);
                 if (result == DialogResult.Cancel)
                     return;
            




        }
    }
}
