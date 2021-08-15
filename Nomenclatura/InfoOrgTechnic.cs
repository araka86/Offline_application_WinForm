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
   
    public partial class InfoOrgTechnic : Form
    {
          ContexAltstarContext db;
        public InfoOrgTechnic()
        {
            InitializeComponent();
            db = new ContexAltstarContext();


          
        }

        private void InfoOrgTechnic_Load(object sender, EventArgs e)
        {
            db.Printers.Load();
            db.Subdivisions.Load();
            db.Cartriges.Load();
            db.Compatibilities.Load();





            var queryPrinter = from p in db.Printers
                        select new
                        {
                            p.Id,
                            Принтер = p.ModelPrinter,
                            Артикул = p.Article
                        };

            var queryCartrige = from p in db.Cartriges
                               select new
                               {
                                   p.Id,
                                   Картридж = p.ModelCartrige,
                                   Артикул = p.ArticleCartrige
                               };


            db.Subdivisions.Load();
            db.Printers.Load();
            var a1 = (from usr in db.Printers.Include(p => p.ModelPrinter) select usr);
            dataGridView1.DataSource = queryPrinter.ToList();
            dataGridView2.DataSource = queryCartrige.ToList();
            dataGridView2.Columns[0].Width = 45;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;


            Printer sb = db.Printers.Find(ids);

            db.Entry(sb).Reference("SubdivisioPK").Load();

            if(listBox1.Items.Count != 0) 
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(sb.SubdivisioPK.division);
                listBox1.DisplayMember = "Id";
            }
            else 
            {
                listBox1.Items.Add(sb.SubdivisioPK.division);
                listBox1.DisplayMember = "Id";
            }
           

        }


        private void button4_Click_1(object sender, EventArgs e)
        {

            int index = dataGridView2.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;



            Cartrige cartrige = db.Cartriges.Find(ids);

            db.Entry(cartrige).Collection("Printers").Load();


            List<Cartrige> parts = new List<Cartrige>();


            parts.Add(cartrige);

            var r = from b in cartrige.Printers
                    select new 
            {

                b.Id,
                b.ModelPrinter,
                b.Article
                
            };
                    

            dataGridView3.DataSource = r.ToList();

     //       listBox2.DataSource = cartrige.Printers.ToList();
     //
     //       listBox2.DisplayMember = "ModelPrinter";
     //

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;


            AddI_Del_infoOrgTehnic addI_Del_InfoOrgTehnicForm = new AddI_Del_infoOrgTehnic();
        

            Cartrige cartrigeAdd = db.Cartriges.Find(ids);

            addI_Del_InfoOrgTehnicForm.textBoxCartrige.Text = cartrigeAdd.ModelCartrige;
            addI_Del_InfoOrgTehnicForm.textBoxArticleCartige.Text = cartrigeAdd.ArticleCartrige;

            var printerAdd = from a in db.Printers select new 
            {
                a.Id,
                a.ModelPrinter,
                a.Article
            };


            addI_Del_InfoOrgTehnicForm.comboBoxPrinter.DataSource = printerAdd.ToList();



            DialogResult result = addI_Del_InfoOrgTehnicForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

        }
    }
}
