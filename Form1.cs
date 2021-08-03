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
        ContexAltstarContext db;




        public Form1()
        {
            InitializeComponent();

            db = new ContexAltstarContext();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ContexAltstarContext db = new ContexAltstarContext())
            {
                db.Printers.Load();
                db.Subdivisions.Load();
                db.Cartriges.Load();
                db.Compatibilities.Load();

                //список принтеров

                PrintPrinter();



                //список картриджей


                PrintCartrige();

                //список подразделений


                dataGridView7.DataSource = db.Subdivisions.Local.ToBindingList();

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

        //------------------------Вивод Принтеров----------------------------
        public void PrintPrinter()
        {

            var pr = from p in db.Printers
                     select new
                     {
                         p.Id,
                         Модель = p.ModelPrinter,
                         Артикул = p.Article,
                         Дата_покуки = p.DateTimes
                     };

            dataGridView5.DataSource = pr.ToList();
        }

        //------------------------Вивод Картриджей----------------------------




        public void PrintCartrige() 
        {
            var crt = from c in db.Cartriges
                      select new
                      {
                          c.Id,
                          c.ModelCartrige,
                          c.ArticleCartrige,
                          c.purchase_date
                      };
            dataGridView6.DataSource = crt.ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {


            //Insert (ADD) Printers
            AddPrinter add = new AddPrinter();


            DialogResult result = add.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;




            Printer printer = new Printer();
            printer.DateTimes = add.txtDatetime.Value;
            printer.ModelPrinter = add.txtModelPrinter.Text;
            printer.Article = add.txtArticle.Text;

            db.Printers.Add(printer);

            db.SaveChanges();

            MessageBox.Show("Новый принтер добавлен ");
            dataGridView5.DataSource = null;
            this.dataGridView5.Update();
            this.dataGridView5.Refresh();
            PrintPrinter();





        }

        private void button7_Click(object sender, EventArgs e)
        {


            // Delete
            if (dataGridView5.SelectedRows.Count > 0)
            {
                int index = dataGridView5.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView5[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Printer printerdel = db.Printers.Find(id);
                db.Printers.Remove(printerdel);
                db.SaveChanges();
                MessageBox.Show("Принтер Удален ");
                dataGridView5.DataSource = null;
                this.dataGridView5.Update();
                this.dataGridView5.Refresh();
                PrintPrinter();


            }


        }

        private void button8_Click(object sender, EventArgs e)
        {

            // update
            if (dataGridView6.SelectedRows.Count > 0)
            {
                int index = dataGridView5.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView5[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                //заполнение полей
                Printer printerUpdate = db.Printers.Find(id);
                AddPrinter update = new AddPrinter();
                update.txtDatetime.Text = printerUpdate.DateTimes.ToString();
                update.txtModelPrinter.Text = printerUpdate.ModelPrinter;
                update.txtArticle.Text = printerUpdate.Article;

                //откритие диалогового окна AddPrinter
                DialogResult result = update.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;


                printerUpdate.DateTimes = update.txtDatetime.Value;
                printerUpdate.ModelPrinter = update.txtModelPrinter.Text;
                printerUpdate.Article = update.txtArticle.Text;



                db.Entry(printerUpdate).State = EntityState.Modified;
                db.SaveChanges();


                MessageBox.Show("Принтер Обновлен ");
                dataGridView5.DataSource = null;
                this.dataGridView5.Update();
                this.dataGridView5.Refresh();
                PrintPrinter();



            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Add Cartrige


            AddCartrige addctrgFrm = new AddCartrige();


            DialogResult result = addctrgFrm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;




            Cartrige cartrigeModel = new Cartrige();
            cartrigeModel.purchase_date = addctrgFrm.txtData.Value;
            cartrigeModel.ModelCartrige = addctrgFrm.txtModelCartrige.Text;
            cartrigeModel.ArticleCartrige = addctrgFrm.txtArticle.Text;

            db.Cartriges.Add(cartrigeModel);

            db.SaveChanges();

            MessageBox.Show("Новый картридж добавлен ");
            dataGridView6.DataSource = null;
            this.dataGridView6.Update();
            this.dataGridView6.Refresh();
            PrintCartrige();




        }

        private void button10_Click(object sender, EventArgs e)
        {


            // Delete Cartrige
            if (dataGridView6.SelectedRows.Count > 0)
            {
                int index = dataGridView6.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView6[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Cartrige cartrigeDel = db.Cartriges.Find(id);
                db.Cartriges.Remove(cartrigeDel);
                db.SaveChanges();
                MessageBox.Show("Картридж Удален ");
                dataGridView6.DataSource = null;
                this.dataGridView6.Update();
                this.dataGridView6.Refresh();
                PrintCartrige();


            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // update Cartrige
            if (dataGridView6.SelectedRows.Count > 0)
            {
                int index = dataGridView6.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView6[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                //екземпляр Формы
                AddCartrige updateCartrigeForm = new AddCartrige();

                //заполнение полей
                Cartrige cartrigeUpdate = db.Cartriges.Find(id);
                updateCartrigeForm.txtData.Text = cartrigeUpdate.purchase_date.ToString();
                updateCartrigeForm.txtModelCartrige.Text = cartrigeUpdate.ModelCartrige;
                updateCartrigeForm.txtArticle.Text = cartrigeUpdate.ArticleCartrige;

                //откритие диалогового окна AddCartrige
                DialogResult result = updateCartrigeForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                //
                cartrigeUpdate.purchase_date = updateCartrigeForm.txtData.Value;
                cartrigeUpdate.ModelCartrige = updateCartrigeForm.txtModelCartrige.Text;
                cartrigeUpdate.ArticleCartrige = updateCartrigeForm.txtArticle.Text;


                //подключения к состоянию обьявив его модифицированним
                db.Entry(cartrigeUpdate).State = EntityState.Modified;
                db.SaveChanges();


                MessageBox.Show("Картридж Обновлен ");
                dataGridView6.DataSource = null;
                this.dataGridView6.Update();
                this.dataGridView6.Refresh();
                PrintCartrige();

            }



            }


        //2
    }



    //1
}
