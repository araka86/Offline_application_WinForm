using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CartrigeAltstar.Model;
using System.Data.SqlClient;
using System.Collections;

namespace CartrigeAltstar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            using (ContexAltstarContext db = new ContexAltstarContext())
            {

                db.infoServices.Load();


                dataGridView3.DataSource = db.infoServices.Local.ToBindingList();




            }




            }

        private void button1_Click(object sender, EventArgs e)
        {

            using (ContexAltstarContext db = new ContexAltstarContext())
            {

                FormAddInfoService formAddInfService = new FormAddInfoService();

                db.infoServices.Load();

                formAddInfService.dataGridView1.DataSource = db.infoServices.Local.ToBindingList();


                





                formAddInfService.ShowDialog(this);



            }





                
        }
    }
}
