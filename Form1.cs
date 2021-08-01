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

    //1



    public partial class Form1 : Form
    {

        //2

        public Form1()
        {
            InitializeComponent();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ContexAltstarContext db = new ContexAltstarContext())
            {
                db.Printers.Load();
                db.Subdivisions.Load();
                db.Cartriges.Load();
                db.Compatibilities.Load();



                var a = (from usr in db.Printers.Include(p => p.ModelPrinter) select usr);

                //  dataGridView1.DataSource = db.Subdivisions.Local.ToBindingList();


                var query = from p in db.Subdivisions
                            select new
                            {
                                p.Id,
                                подразделение = p.division,
                                адресс = p.address_part
                            };
                db.Subdivisions.Load();
                db.Printers.Load();
                var a1 = (from usr in db.Printers.Include(p => p.ModelPrinter) select usr);




                dataGridView1.DataSource = query.ToList();

                //   var query2 = from p in db.Printers
                //               select new
                //               {
                //                  p.Id,
                //                  p.ModelPrinter,
                //                  p.Article
                //
                //               };
                //
                //   dataGridView2.DataSource = query2.ToList();

                var cartige = from c in db.Cartriges
                              select new
                              {
                                  c.Id,
                                  модель_картриджа = c.ModelCartrige,
                                  дата_покупки = c.purchase_date


                              };
                dataGridView2.DataSource = cartige.ToList();


                var cp = from c in db.Compatibilities
                         select new
                         {
                             c.id,
                             c.PrinterPK.ModelPrinter,
                             c.CartrigePK.ModelCartrige,
                             c.SubdivisionPK.division
                             
                         };

                dataGridView4.DataSource = cp.ToList();


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (ContexAltstarContext db = new ContexAltstarContext())
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int ids = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out ids);
                    if (converted == false)
                        return;



                    Subdivision sb = db.Subdivisions.Find(ids);

                    db.Entry(sb).Collection("Printers").Load();
                    listBox1.DataSource = sb.Printers.ToList();
                    listBox1.DisplayMember = "Id";



                    var t = from o in sb.Printers
                            select new
                            {
                                АРТИКУЛ = o.Article,
                                МОДЕЛЬ = o.ModelPrinter
                            };


                    dataGridView3.DataSource = t.ToList();





                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                using (ContexAltstarContext db = new ContexAltstarContext())
                {
                    int index = dataGridView2.SelectedRows[0].Index;
                    int ids = 0;
                    bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out ids);
                    if (converted == false)
                        return;


                    Cartrige ct = db.Cartriges.Find(ids);
                    db.Entry(ct).Collection("Printers").Load();
                    listBox2.DataSource = ct.Printers.ToList();
                    listBox2.DisplayMember = "ModelPrinter";

                }
            }




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(this);
        }


        //2
    }



    //1
}
