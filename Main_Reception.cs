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

        //візвать форму перещения картриджа
        private void button4_Click(object sender, EventArgs e)
        {

            CartrigePlace ctpl = new CartrigePlace(); // екземпляр формы CartrigePlace


            var cp = from c1 in db.Compatibilities
                     select new
                     {
                         c1.id,
                         Модель = c1.CartrigePK.ModelCartrige,
                         Артикул = c1.CartrigePK.ArticleCartrige,
                         Подразделение = c1.SubdivisionPK.division

                     };

            ctpl.dataGridView1.DataSource = cp.ToList(); //внесение данных в dataGridView1


            ctpl.Show(this); // вызов формы



        }


        //обработчик собитий, при выборе значений - виберается и его артикул, который записиввается в лейбл
        private void comboBoxFiltrCartrige_SelectedIndexChanged(object sender, EventArgs e)
        {
            string takeValue = comboBoxFiltrCartrige.SelectedItem.ToString();
            var ctt = db.Cartriges.Single(t => t.ModelCartrige.StartsWith(takeValue)); // нахождения ВСЕХ ЗНАЧЕНИЙ в одной  СТРОКИ!!!!!!!!!!!!!!
            label1Article.Text = ctt.ArticleCartrige;
        }

        private void button8_Click(object sender, EventArgs e)
        {


            string searchValue = comboBoxFiltrCartrige.SelectedItem.ToString();


            string[] data = new string[dataGridView1.Rows.Count];



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {

                    if( cell.Value.ToString().Contains(searchValue)) 
                    {

                        data[i] += cell.Value;
                    }


                       
                }
            }


            dataGridView1.ClearSelection();
            var targetText = searchValue;
            if (targetText != String.Empty)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Cartrige"].Value != null && row.Cells["Cartrige"].Value.ToString().Contains(targetText))
                    {
                        row.Selected = true;
                      dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

                        
                        //   break;  // remove this if you want to select all the rows that contain the text

                       

                    }
                   
                }
            }






            //      try
            //      {
            //          bool valueResult = false;
            //          foreach (DataGridViewRow row in dataGridView1.Rows)
            //          {
            //              for (int i = 0; i < row.Cells.Count; i++)
            //              {
            //                  if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().Equals(searchValue))
            //                  {
            //                      var rowIndex = row.Cells[i].Value;
            //
            //
            //
            //                      DataGridViewRow rows = (DataGridViewRow)row.Cells[i].Value;
            //
            //
            //
            //
            //
            //                      //      dataGridView1.DataSource = null;
            //                      //      this.dataGridView1.Update();
            //                      //      this.dataGridView1.Refresh();
            //                      //      printRecept();
            //                      //
            //
            //                      //
            //                      //      object  ss = dataGridView1.SelectedRows[rowIndex];
            //                      //      dataGridView1.Rows[rowIndex].Selected = true;
            //                      //      valueResult = true;
            //                      //      break;
            //                  }
            //              }
            //
            //          }
            //          if (!valueResult)
            //          {
            //              MessageBox.Show("Unable to find " + "Not Found");
            //              return;
            //          }
            //      }
            //      catch (Exception exc)
            //      {
            //          MessageBox.Show(exc.Message);
            //      }
            //
            //


        }









        //2
    }

    //1
}
