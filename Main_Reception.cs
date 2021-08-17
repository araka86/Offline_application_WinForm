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
using CartrigeAltstar.Nomenclatura.Cartrige;
using SortOrder = System.Windows.Forms.SortOrder;

namespace CartrigeAltstar
{
    public partial class Main_Reception : Form
    {
        ContexAltstarContext db;








        public Main_Reception()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
            db.Subdivisions.Load();
            db.Compatibilities.Load();




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

        public object ForFiltrCartrige()
        {
            var ListCartrigeFiltr = from lc in db.Cartriges
                                    select lc.ModelCartrige;

            return ListCartrigeFiltr.ToList();
        }

        private void Reception_Load(object sender, EventArgs e)
        {
            printRecept();
            PrintDispatch();


            //     dataGridView2.Columns[0].Width = 65;







            //    db.Receptions.Load();
            //   dataGridView1.DataSource = db.Receptions.Local.ToBindingList();

            //    dataGridView1.Columns[0].Width = 45;

            comboBoxFiltrCartrige.DataSource = ForFiltrCartrige();
            comboBoxFiltrDispath.DataSource = ForFiltrCartrige();


            //

            //   
            //

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

            var dataReception = from r in db.Receptions
                                select new
                                {
                                    ID = r.id,
                                    Дата = r.Дата,
                                    Картридж = r.Картридж,
                                    Статус = r.Статус,
                                    Вес = r.Вес,
                                    Подразделения = r.Подразделения
                                };





            //   dataGridView1.DataSource = dataReception.ToArray();



            db.Receptions.Load();

            dataGridView1.DataSource = db.Receptions.Local.ToBindingList();
            //   dataGridView2.DataSource = db.Dispatches.Local.ToBindingList();


            dataGridView1.Columns[0].Width = 65;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 240;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;




        }

        public void PrintDispatch()
        {

            var datadispath = from d in db.Dispatches
                              select new
                              {
                                  ID = d.id,
                                  Дата = d.Дата,
                                  Картридж = d.Картридж,
                                  Заметки = d.Заметки,
                                  Вес = d.Вес,
                                  Подразделения = d.Подразделения
                              };



            //  dataGridView2.DataSource = datadispath.ToList();
            dataGridView2.DataSource = db.Dispatches.Local.ToBindingList();
            //
            dataGridView2.Columns[0].Width = 65;


            dataGridView2.Columns[1].Width = 220;
            dataGridView2.Columns[2].Width = 240;
            dataGridView2.Columns[3].Width = 200;
            dataGridView2.Columns[4].Width = 200;
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



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


            reception.Дата = receptioncfg.txtdate.Value;
            reception.Подразделения = receptioncfg.comboBoxDivision.Text.ToString();
            reception.Картридж = receptioncfg.comboBoxCartrige.Text.ToString();

            if (receptioncfg.rbEmpty.Checked)
            {
                reception.Статус = receptioncfg.rbEmpty.Text;
            }
            if (receptioncfg.rbFull.Checked)
            {
                reception.Статус = receptioncfg.rbFull.Text;
            }


            reception.Вес = Convert.ToDouble(receptioncfg.txtWeight.Text);

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
                receptionConfigUpdateForm.txtdate.Text = receptionupdateModel.Дата.ToString();
                //заполнение веса
                receptionConfigUpdateForm.txtWeight.Text = receptionupdateModel.Вес.ToString();

                // проверка и заполениия radioButton
                if (receptionupdateModel.Статус == "Пустой")
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

                int findIndexComboboxCartrige = receptionConfigUpdateForm.comboBoxCartrige.FindString(receptionupdateModel.Картридж); //поиск индекса в comboBoxCartrige
                receptionConfigUpdateForm.comboBoxCartrige.SelectedIndex = findIndexComboboxCartrige;

                //заполнения comboBoxDivision
                receptionConfigUpdateForm.comboBoxDivision.DataSource = MiGlobalFunction2();
                int findIndexComboboxDivision = receptionConfigUpdateForm.comboBoxDivision.FindString(receptionupdateModel.Подразделения); //поиск индекса в comboBoxDivision
                receptionConfigUpdateForm.comboBoxDivision.SelectedIndex = findIndexComboboxDivision;



                DialogResult result = receptionConfigUpdateForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;


                if (converted == false)
                    return;
                //заполнение полей обратно


                receptionupdateModel.Дата = receptionConfigUpdateForm.txtdate.Value; //заполнения дати
                receptionupdateModel.Подразделения = receptionConfigUpdateForm.comboBoxDivision.Text.ToString(); //заполнения подразделения
                receptionupdateModel.Картридж = receptionConfigUpdateForm.comboBoxCartrige.Text.ToString(); //заполнения картриджа
                receptionupdateModel.Вес = Convert.ToDouble(receptionConfigUpdateForm.txtWeight.Text); //заполнения веса


                //заполнения статуса (Полный - Пустой)
                if (receptionConfigUpdateForm.rbEmpty.Checked)
                {
                    receptionupdateModel.Статус = receptionConfigUpdateForm.rbEmpty.Text;
                }
                if (receptionConfigUpdateForm.rbFull.Checked)
                {
                    receptionupdateModel.Статус = receptionConfigUpdateForm.rbFull.Text;
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
            //      string takeValue = comboBoxFiltrCartrige.SelectedItem.ToString();



            //      var ctt = db.Cartriges.Single(t => t.ModelCartrige.StartsWith(takeValue)); // нахождения ВСЕХ ЗНАЧЕНИЙ в одной  СТРОКИ!!!!!!!!!!!!!!
            //     label1Article.Text = ctt.ArticleCartrige;
        }



        //SUBMIT FILTR
        private void button8_Click(object sender, EventArgs e)
        {


            string searchValue = comboBoxFiltrCartrige.SelectedItem.ToString();




            var ctt = from u in db.Receptions.Where(p => p.Картридж == searchValue) select u;


            dataGridView1.DataSource = null;
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            dataGridView1.DataSource = ctt.ToList();






            //
            //         for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //         {
            //             foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
            //             {
            //
            //                 if( cell.Value.ToString().Contains(searchValue)) 
            //                 {
            //
            //                   
            //                 }
            //
            //
            //                    
            //             }
            //         }

            //
            //        dataGridView1.ClearSelection();
            //        var targetText = searchValue;
            //        if (targetText != String.Empty)
            //        {
            //            foreach (DataGridViewRow row in dataGridView1.Rows)
            //            {
            //                if (!row.IsNewRow && row.Cells["Cartrige"].Value != null && row.Cells["Cartrige"].Value.ToString().Contains(targetText))
            //                {
            //                    row.Selected = true;
            //                  dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
            //
            //                    
            //                    //   break;  // remove this if you want to select all the rows that contain the text
            //
            //                   
            //
            //                }
            //               
            //            }
            //        }






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

        private void resetFiltr_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            printRecept();

        }

        private void button7_Click(object sender, EventArgs e)
        {


            DateTime curTime = DateTime.Now; // Current Data

            Excel.Application ExcelApp = new Excel.Application(); //Объявляем приложение

            Workbook ExcelWorkBook; //инициализация рабочей книги
            Worksheet ExcelWorkSheet; //инициализация рабочего листа
            Range ExecelRange; //Переменная диапазона

            ExcelApp.SheetsInNewWorkbook = 2; //Количество листов в рабочей книге

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value); //Добавить рабочую книгу

            ExcelApp.DisplayAlerts = false; //Отключить отображение окон с сообщениями

            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1); //Получаем первый лист документа (счет начинается с 1) (переключение междк листами)


            ExcelWorkSheet.Name = "Приемка -  " + curTime.ToShortDateString().ToString(); //Название листа (вкладки снизу)

            object[,] d = new object[dataGridView1.RowCount, dataGridView1.ColumnCount];


            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {

                ExcelWorkSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;




                ExcelWorkSheet.Cells[1, i].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 2;
                ExcelWorkSheet.Cells[1, i].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2;
                ExcelWorkSheet.Cells[1, i].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 2;
                ExcelWorkSheet.Cells[1, i].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 4;

                ExecelRange = (Excel.Range)ExcelWorkSheet.Cells[1, i];
                ExecelRange.Cells.Font.Size = 14;
                ExecelRange.Cells.Font.Bold = 500;
                ExecelRange.Cells.Font.Color = Color.Brown;

            }


            //DATA (Fill)

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) //отступ вниз 1
            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    d[i, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }


            Fill(2, 1, d);

            ExcelApp.Visible = true; //Отобразить Excel


            //Заполнение строк
            void Fill(int topRow, int leftCol, object[,] data)
            {
                int rows = data.GetUpperBound(0) + 1;
                int cols = data.GetUpperBound(1) + 1;

                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.ActiveSheet;

                object leftTop = ExcelWorkSheet.Cells[topRow, leftCol];
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridView1.RowCount - 1, leftCol + dataGridView1.ColumnCount - 1];

                Microsoft.Office.Interop.Excel.Range range = ExcelWorkSheet.get_Range(leftTop, rightBottom);
                range.Value2 = data;
                setStyle(range);

            }


            //Прорисовка  (оформление) документа
            void setStyle(Excel.Range range)
            {
                range.EntireColumn.AutoFit();
                range.EntireRow.AutoFit();
                //отрисовка линий для excel документа
                object[] border = new object[] {XlBordersIndex.xlEdgeLeft, //Лево
                                                XlBordersIndex.xlEdgeTop, //Верх
                                                XlBordersIndex.xlEdgeBottom, //Низ
                                                XlBordersIndex.xlEdgeRight, //Право
                                                XlBordersIndex.xlInsideVertical, //Вертикаль
                                                XlBordersIndex.xlInsideHorizontal}; //Горизонталь

                for (int i = 0; i < border.Length; i++)
                {
                    range.Borders[(Excel.XlBordersIndex)border[i]].LineStyle = Excel.XlLineStyle.xlContinuous; //Стиль
                    range.Borders[(Excel.XlBordersIndex)border[i]].Weight = Excel.XlBorderWeight.xlThin; //Толщина
                    range.Borders[(Excel.XlBordersIndex)border[i]].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                }

            }
        }





        private void btnPrinterShow_Click(object sender, EventArgs e)
        {
            ListSettingPinterForm listSettingPinterForm = new ListSettingPinterForm();

            listSettingPinterForm.Show();

        }

        private void btnCartrigeShow_Click(object sender, EventArgs e)
        {

            ListCartrigeForm listCartrigeForm = new ListCartrigeForm();

            listCartrigeForm.Show();


        }

        private void button13_Click(object sender, EventArgs e)
        {


            comboBoxFiltrCartrige.DataSource = null;
            comboBoxFiltrCartrige.DataSource = ForFiltrCartrige();



        }

        private void btnDivisionShow_Click(object sender, EventArgs e)
        {
            ListSubdivisionForm listSubdivisionForm = new ListSubdivisionForm();
            listSubdivisionForm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            InfoOrgTechnic infoOrgTechnic = new InfoOrgTechnic();

            infoOrgTechnic.ShowDialog();
        }




        //добавления для отправки
        private void button9_Click(object sender, EventArgs e)
        {



            DispatchConfig dispatchConfigForm = new DispatchConfig();


            //  var ListCartrige = from lc in db.Cartriges
            //                     select lc.ModelCartrige;
            //

            var ListCartrige = from lc in db.Cartriges
                               select new
                               {
                                  Модель = lc.ModelCartrige,
                                  Артикул = lc.ArticleCartrige
                               };


            var p = ListCartrige.ToList();
            string[] sdata = new string[p.Count];
            //изменяем знаки
            for (int i = 0; i < p.Count; i++)
            {

                sdata[i] = p[i].ToString().Replace('}', ')').Replace('{', '(');

            }
            dispatchConfigForm.comboBoxCartrige.DataSource = sdata.ToList();








            var ListDivision = from ls in db.Subdivisions
                               select ls.division;

          //  dispatchConfigForm.comboBoxCartrige.DataSource = ListCartrige.ToList();
            dispatchConfigForm.comboBoxDivision.DataSource = ListDivision.ToList();



            DialogResult result = dispatchConfigForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;



            Dispatch dispatchModel = new Dispatch();



            dispatchModel.Дата = dispatchConfigForm.txtdate.Value; // дата отправки
            dispatchModel.Подразделения = dispatchConfigForm.comboBoxDivision.Text.ToString(); //подразделение
            dispatchModel.Картридж = dispatchConfigForm.comboBoxCartrige.Text.ToString(); // картридж
            dispatchModel.Заметки = dispatchConfigForm.txtZametki.Text.ToString(); //Заметки

            dispatchModel.Вес = Convert.ToDouble(dispatchConfigForm.txtWeight.Text); //Вес

            db.Dispatches.Add(dispatchModel);
            db.SaveChanges();
            MessageBox.Show("Картридж на отправку записан!!!!");
            dataGridView2.DataSource = null;
            this.dataGridView2.Update();
            this.dataGridView2.Refresh();
            PrintDispatch();




        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Ascending);


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //UPDATE DISPATCH
        private void button10_Click(object sender, EventArgs e)
        {



            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id); //Find Index
                Dispatch dispatchUpdateModel = db.Dispatches.Find(id); //нахождения индекса модели
                DispatchConfig dispatchnConfigUpdateForm = new DispatchConfig(); //екземпляяр класа формы
                //заполнения даты
                dispatchnConfigUpdateForm.txtdate.Text = dispatchUpdateModel.Дата.ToString();
                //заполнение веса
                dispatchnConfigUpdateForm.txtWeight.Text = dispatchUpdateModel.Вес.ToString();

                dispatchnConfigUpdateForm.txtZametki.Text = dispatchUpdateModel.Заметки.ToString();


                //заполнения comboBoxCartrige
                dispatchnConfigUpdateForm.comboBoxCartrige.DataSource = MiGlobalFunction();

                int findIndexComboboxCartrige = dispatchnConfigUpdateForm.comboBoxCartrige.FindString(dispatchUpdateModel.Картридж); //поиск индекса в comboBoxCartrige
                dispatchnConfigUpdateForm.comboBoxCartrige.SelectedIndex = findIndexComboboxCartrige;

                //заполнения comboBoxDivision
                dispatchnConfigUpdateForm.comboBoxDivision.DataSource = MiGlobalFunction2();
                int findIndexComboboxDivision = dispatchnConfigUpdateForm.comboBoxDivision.FindString(dispatchUpdateModel.Подразделения); //поиск индекса в comboBoxDivision
                dispatchnConfigUpdateForm.comboBoxDivision.SelectedIndex = findIndexComboboxDivision;



                DialogResult result = dispatchnConfigUpdateForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;


                if (converted == false)
                    return;
                //заполнение полей обратно


                dispatchUpdateModel.Дата = dispatchnConfigUpdateForm.txtdate.Value; //заполнения дати
                dispatchUpdateModel.Подразделения = dispatchnConfigUpdateForm.comboBoxDivision.Text.ToString(); //заполнения подразделения
                dispatchUpdateModel.Картридж = dispatchnConfigUpdateForm.comboBoxCartrige.Text.ToString(); //заполнения картриджа
                dispatchUpdateModel.Вес = Convert.ToDouble(dispatchnConfigUpdateForm.txtWeight.Text); //заполнения веса

                dispatchUpdateModel.Заметки = dispatchnConfigUpdateForm.txtZametki.Text;





                //подключения к состоянию обьявив его модифицированним
                db.Entry(dispatchUpdateModel).State = EntityState.Modified;
                db.SaveChanges();


                MessageBox.Show("Запись обновленна!!!!");
                dataGridView2.DataSource = null; //занулить датагрид
                this.dataGridView2.Update(); //обновить
                this.dataGridView2.Refresh(); //обновить
                PrintDispatch(); //вивести по новой



            }





        }
        //DELETE DISPATCH DATA
        private void button11_Click(object sender, EventArgs e)
        {


            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;


                Dispatch dispatchupdateModel = db.Dispatches.Find(id); //нахождения индекса модели
                db.Dispatches.Remove(dispatchupdateModel);
                db.SaveChanges();
                MessageBox.Show("Запись Удаленна!!! ");
                dataGridView2.DataSource = null;
                this.dataGridView2.Update();
                this.dataGridView2.Refresh();
                PrintDispatch(); //вивести по новой




            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string searchValue = comboBoxFiltrCartrige.SelectedItem.ToString();




            var ctt = from u in db.Dispatches.Where(p => p.Картридж == searchValue) select u;


            dataGridView2.DataSource = null;
            this.dataGridView2.Update();
            this.dataGridView2.Refresh();
            dataGridView2.DataSource = ctt.ToList();
            dataGridView2.Columns[0].Width = 65;


            dataGridView2.Columns[1].Width = 220;
            dataGridView2.Columns[2].Width = 240;
            dataGridView2.Columns[3].Width = 200;
            dataGridView2.Columns[4].Width = 200;
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        //сбросить фильтра
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            this.dataGridView2.Update();
            this.dataGridView2.Refresh();
            PrintDispatch();
        }

        //EXPORT EXCEL
        private void button15_Click(object sender, EventArgs e)
        {



            DateTime curTime = DateTime.Now; // Current Data

            Excel.Application ExcelApp = new Excel.Application(); //Объявляем приложение

            Workbook ExcelWorkBook; //инициализация рабочей книги
            Worksheet ExcelWorkSheet; //инициализация рабочего листа
            Range ExecelRange; //Переменная диапазона

            ExcelApp.SheetsInNewWorkbook = 2; //Количество листов в рабочей книге

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value); //Добавить рабочую книгу

            ExcelApp.DisplayAlerts = false; //Отключить отображение окон с сообщениями

            ExcelWorkSheet = (Worksheet)ExcelWorkBook.Worksheets.get_Item(1); //Получаем первый лист документа (счет начинается с 1) (переключение междк листами)


            ExcelWorkSheet.Name = "Отправка-  " + curTime.ToShortDateString().ToString(); //Название листа (вкладки снизу)

            object[,] d = new object[dataGridView2.RowCount, dataGridView2.ColumnCount];


            for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
            {

                ExcelWorkSheet.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;




                ExcelWorkSheet.Cells[1, i].Borders[XlBordersIndex.xlEdgeRight].Weight = 2;
                ExcelWorkSheet.Cells[1, i].Borders[XlBordersIndex.xlEdgeTop].Weight = 2;
                ExcelWorkSheet.Cells[1, i].Borders[XlBordersIndex.xlEdgeLeft].Weight = 2;
                ExcelWorkSheet.Cells[1, i].Borders[XlBordersIndex.xlEdgeBottom].Weight = 4;

                ExecelRange = (Excel.Range)ExcelWorkSheet.Cells[1, i];
                ExecelRange.Cells.Font.Size = 14;
                ExecelRange.Cells.Font.Bold = 500;
                ExecelRange.Cells.Font.Color = Color.Brown;

            }


            //DATA (Fill)

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) //отступ вниз 1
            {

                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {

                    d[i, j] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                }
            }


            Fill(2, 1, d);

            ExcelApp.Visible = true; //Отобразить Excel


            //Заполнение строк
            void Fill(int topRow, int leftCol, object[,] data)
            {
                int rows = data.GetUpperBound(0) + 1;
                int cols = data.GetUpperBound(1) + 1;

                Worksheet sheet = (Worksheet)ExcelApp.ActiveSheet;

                object leftTop = ExcelWorkSheet.Cells[topRow, leftCol];
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridView2.RowCount - 1, leftCol + dataGridView2.ColumnCount - 1];

                Range range = ExcelWorkSheet.get_Range(leftTop, rightBottom);
                range.Value2 = data;
                setStyle(range);

            }


            //Прорисовка  (оформление) документа
            void setStyle(Excel.Range range)
            {
                range.EntireColumn.AutoFit();
                range.EntireRow.AutoFit();
                //отрисовка линий для excel документа
                object[] border = new object[] {XlBordersIndex.xlEdgeLeft, //Лево
                                                XlBordersIndex.xlEdgeTop, //Верх
                                                XlBordersIndex.xlEdgeBottom, //Низ
                                                XlBordersIndex.xlEdgeRight, //Право
                                                XlBordersIndex.xlInsideVertical, //Вертикаль
                                                XlBordersIndex.xlInsideHorizontal}; //Горизонталь

                for (int i = 0; i < border.Length; i++)
                {
                    range.Borders[(XlBordersIndex)border[i]].LineStyle = XlLineStyle.xlContinuous; //Стиль
                    range.Borders[(XlBordersIndex)border[i]].Weight = XlBorderWeight.xlThin; //Толщина
                    range.Borders[(XlBordersIndex)border[i]].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                }

            }



        }





        //2
    }

    //1
}
