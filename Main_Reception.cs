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
using ClosedXML.Excel;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;


namespace CartrigeAltstar
{
    public partial class Main_Reception : Form
    {
        ContexAltstarContext db;








        public Main_Reception()
        {
            InitializeComponent();
            db = new ContexAltstarContext();

            db.Receptions.Load();
            db.Dispatches.Load();




            var ListCartrige = from lc in db.Cartriges
                               select lc.ModelCartrige;
        }




        //Список картриджей для Combobox 
        public static object MiGlobalFunction()
        {
            ContexAltstarContext db;
            db = new ContexAltstarContext();

            var ListCartrige = from lc in db.Cartriges
                               select lc.ModelCartrige;
            return ListCartrige.ToList();

        }

        //Список подразделений для Combobox 
        public static object MiGlobalFunction2()
        {
            ContexAltstarContext db;
            db = new ContexAltstarContext();

            var ListDivision = from ls in db.Subdivisions
                               select ls.division;
            return ListDivision.ToList();

        }



        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reception_Load(object sender, EventArgs e)
        {
            printRecept();

            var ListCartrigeFiltr = from lc in db.Cartriges
                                    select lc.ModelCartrige;
            comboBoxFiltrCartrige.DataSource = ListCartrigeFiltr.ToList();






        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.ShowDialog(this);
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            О_программе o_ = new О_программе();
            o_.ShowDialog();
        }

        public void printRecept() //отображение прием картриджа
        {

            dataGridView1.DataSource = db.Receptions.Local.ToBindingList();
            dataGridView2.DataSource = db.Dispatches.Local.ToBindingList();

        }



        //ADD INSERT ////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {


            ReceptionConfig receptioncfg = new ReceptionConfig();

            var ListCartrige = from lc in db.Cartriges
                               select lc.ModelCartrige;

            var ListDivision = from ls in db.Subdivisions
                               select ls.division;

            receptioncfg.comboBoxCartrige.DataSource = ListCartrige.ToList();
            receptioncfg.comboBoxDivision.DataSource = ListDivision.ToList();



            DialogResult result = receptioncfg.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;



            Reception reception = new Reception();


            reception.Date = receptioncfg.txtdate.Value;
            reception.Date_of_receipt = receptioncfg.comboBoxDivision.Text.ToString();
            reception.Cartrige = receptioncfg.comboBoxCartrige.Text.ToString();

            if (receptioncfg.rbEmpty.Checked)
            {
                reception.Status = receptioncfg.rbEmpty.Text;
            }
            if (receptioncfg.rbFull.Checked)
            {
                reception.Status = receptioncfg.rbFull.Text;
            }


            reception.Weight = Convert.ToDouble(receptioncfg.txtWeight.Text);

            db.Receptions.Add(reception);
            db.SaveChanges();
            MessageBox.Show("Картридж на приемку записан!!!!");
            dataGridView1.DataSource = null;
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            printRecept();


        }



        // update///////////////////////
        private void button2_Click(object sender, EventArgs e)
        {





            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id); //Find Index
                Reception receptionupdateModel = db.Receptions.Find(id); //нахождения индекса модели
                ReceptionConfig receptionConfigUpdateForm = new ReceptionConfig(); //екземпляяр класа формы
                //заполнения даты
                receptionConfigUpdateForm.txtdate.Text = receptionupdateModel.Date.ToString();
                //заполнение веса
                receptionConfigUpdateForm.txtWeight.Text = receptionupdateModel.Weight.ToString();

                // проверка и заполениия radioButton
                if (receptionupdateModel.Status == "Пустой")
                {
                    receptionConfigUpdateForm.rbFull.Checked = false;
                    receptionConfigUpdateForm.rbEmpty.Checked = true;

                }
                else
                {
                    receptionConfigUpdateForm.rbFull.Checked = true;
                    receptionConfigUpdateForm.rbEmpty.Checked = false;
                }

                //заполнения comboBoxCartrige
                receptionConfigUpdateForm.comboBoxCartrige.DataSource = MiGlobalFunction();

                int findIndexComboboxCartrige = receptionConfigUpdateForm.comboBoxCartrige.FindString(receptionupdateModel.Cartrige); //поиск индекса в comboBoxCartrige
                receptionConfigUpdateForm.comboBoxCartrige.SelectedIndex = findIndexComboboxCartrige;

                //заполнения comboBoxDivision
                receptionConfigUpdateForm.comboBoxDivision.DataSource = MiGlobalFunction2();
                int findIndexComboboxDivision = receptionConfigUpdateForm.comboBoxDivision.FindString(receptionupdateModel.Date_of_receipt); //поиск индекса в comboBoxDivision
                receptionConfigUpdateForm.comboBoxDivision.SelectedIndex = findIndexComboboxDivision;



                DialogResult result = receptionConfigUpdateForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;


                if (converted == false)
                    return;
                //заполнение полей обратно


                receptionupdateModel.Date = receptionConfigUpdateForm.txtdate.Value; //заполнения дати
                receptionupdateModel.Date_of_receipt = receptionConfigUpdateForm.comboBoxDivision.Text.ToString(); //заполнения подразделения
                receptionupdateModel.Cartrige = receptionConfigUpdateForm.comboBoxCartrige.Text.ToString(); //заполнения картриджа
                receptionupdateModel.Weight = Convert.ToDouble(receptionConfigUpdateForm.txtWeight.Text); //заполнения веса


                //заполнения статуса (Полный - Пустой)
                if (receptionConfigUpdateForm.rbEmpty.Checked)
                {
                    receptionupdateModel.Status = receptionConfigUpdateForm.rbEmpty.Text;
                }
                if (receptionConfigUpdateForm.rbFull.Checked)
                {
                    receptionupdateModel.Status = receptionConfigUpdateForm.rbFull.Text;
                }




                //подключения к состоянию обьявив его модифицированним
                db.Entry(receptionupdateModel).State = EntityState.Modified;
                db.SaveChanges();


                MessageBox.Show("Запись обновленна!!!!");
                dataGridView1.DataSource = null; //занулить датагрид
                this.dataGridView1.Update(); //обновить
                this.dataGridView1.Refresh(); //обновить
                printRecept(); //вивести по новой






            }



        }
        //Удалить
        private void button3_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;


                Reception receptionupdateModel = db.Receptions.Find(id); //нахождения индекса модели
                db.Receptions.Remove(receptionupdateModel);
                db.SaveChanges();
                MessageBox.Show("Запись Удаленна!!! ");
                dataGridView1.DataSource = null;
                this.dataGridView1.Update();
                this.dataGridView1.Refresh();
                printRecept(); //вивести по новой





            }





        }

        private void button4_Click(object sender, EventArgs e)
        {


            CartrigePlace ctpl = new CartrigePlace();

            var cp = from c1 in db.Compatibilities
                     select new
                     {
                         c1.id,

                         Модель = c1.CartrigePK.ModelCartrige,
                         Артикул = c1.CartrigePK.ArticleCartrige,
                         Подразделение = c1.SubdivisionPK.division

                     };

            ctpl.dataGridView1.DataSource = cp.ToList();


            ctpl.ShowDialog();



        }











        //2
    }

    //1
}
