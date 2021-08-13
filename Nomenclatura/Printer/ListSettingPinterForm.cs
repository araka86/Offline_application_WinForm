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
    public partial class ListSettingPinterForm : Form
    {

        ContexAltstarContext db;

        public ListSettingPinterForm()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
            db.Printers.Load();
        }

        private void ListSettingPinterForm_Load(object sender, EventArgs e)
        {
            PrintPrinter();
           
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

            dataGridViewListPrinter.DataSource = pr.ToList();
            dataGridViewListPrinter.Columns[0].Width = 45;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }




        //////////////////////Insert (ADD) Printers////////////////////////
        private void button6_Click(object sender, EventArgs e)
        {


            
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
            dataGridViewListPrinter.DataSource = null;
            this.dataGridViewListPrinter.Update();
            this.dataGridViewListPrinter.Refresh();
            PrintPrinter();



        }


        /////// Delete/////////////////////////////////////////////
        private void button7_Click(object sender, EventArgs e)
        {



           
            if (dataGridViewListPrinter.SelectedRows.Count > 0)
            {
                int index = dataGridViewListPrinter.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewListPrinter[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Printer printerdel = db.Printers.Find(id);
                db.Printers.Remove(printerdel);
                db.SaveChanges();
                MessageBox.Show("Принтер Удален ");
                dataGridViewListPrinter.DataSource = null;
                this.dataGridViewListPrinter.Update();
                this.dataGridViewListPrinter.Refresh();
                PrintPrinter();


            }



        }

        private void button8_Click(object sender, EventArgs e)
        {






            // update
            if (dataGridViewListPrinter.SelectedRows.Count > 0)
            {
                int index = dataGridViewListPrinter.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewListPrinter[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                //заполнение полей
                Subdivision s = new Subdivision();
                Printer printerUpdate = db.Printers.Find(id);
                AddPrinter update = new AddPrinter();
                update.txtDatetime.Text = printerUpdate.DateTimes.ToString();
                update.txtModelPrinter.Text = printerUpdate.ModelPrinter;
                update.txtArticle.Text = printerUpdate.Article;


                s = printerUpdate.SubdivisioPK; //




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
                dataGridViewListPrinter.DataSource = null;
                this.dataGridViewListPrinter.Update();
                this.dataGridViewListPrinter.Refresh();
                PrintPrinter();







            }
        }
    }
}
