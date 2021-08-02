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
    public partial class FormAddInfoService : Form
    {

        
        public FormAddInfoService()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

         

        }

        private void FormAddInfoService_Load(object sender, EventArgs e)
        {
            using (ContexAltstarContext db = new ContexAltstarContext()) 
            
            
            {




                var r = from w in db.Cartriges select w.ModelCartrige ;

                comboBoxCartrige.DataSource = r.ToList();
       
      //     List<Cartrige> cartriges = db.Cartriges.ToList();
      //    comboBoxCartrige.DataSource = cartriges;
      //    comboBoxCartrige.ValueMember = "Id";
      //    comboBoxCartrige.DisplayMember = "ModelCartrige";


            }
            
        }

        private void okAdd_Click(object sender, EventArgs e)
        {

            using(ContexAltstarContext db = new ContexAltstarContext()) 
            {



                InfoService infserv = new InfoService();
                infserv.DateTime = txtDate.Text;


                var a = comboBoxCartrige.SelectedItem.ToString();
                infserv.Cartriges = a;


                infserv.TypeService = txtype.Text;
                db.infoServices.Add(infserv);
                db.SaveChanges();

                


            }
            
          

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
