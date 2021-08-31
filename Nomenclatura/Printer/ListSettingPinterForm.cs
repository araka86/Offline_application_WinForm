using CartrigeAltstar.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
      //     PropertyInfo verticalOffset = dataGridViewListPrinter.GetType().GetProperty("VerticalOffset", BindingFlags.NonPublic | BindingFlags.Instance);
      //     verticalOffset.SetValue(this.dataGridViewListPrinter, 10, null);

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

        private void button18_Click(object sender, EventArgs e)
        {
            DateTime curTime = DateTime.Now; // Current Data
            Excel.Application ExcelApp = new Excel.Application(); //Объявляем приложение
            Excel.Workbook ExcelWorkBook; //инициализация рабочей книги
            Excel.Worksheet ExcelWorkSheet; //инициализация рабочего листа
            Excel.Range ExecelRange; //Переменная диапазона
            ExcelApp.SheetsInNewWorkbook = 2; //Количество листов в рабочей книге
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value); //Добавить рабочую книгу
            ExcelApp.DisplayAlerts = false; //Отключить отображение окон с сообщениями
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1); //Получаем первый лист документа (счет начинается с 1) (переключение междк листами)
            ExcelWorkSheet.Name = "Принтеры -  " + curTime.ToShortDateString().ToString(); //Название листа (вкладки снизу)
            object[,] d = new object[dataGridViewListPrinter.RowCount, dataGridViewListPrinter.ColumnCount];
            for (int i = 1; i < dataGridViewListPrinter.Columns.Count + 1; i++)
            {

                ExcelWorkSheet.Cells[1, i] = dataGridViewListPrinter.Columns[i - 1].HeaderText;
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
            for (int i = 0; i < dataGridViewListPrinter.Rows.Count; i++) //отступ вниз 1
            {
                for (int j = 0; j < dataGridViewListPrinter.Columns.Count; j++)
                {
                    d[i, j] = dataGridViewListPrinter.Rows[i].Cells[j].Value.ToString();
                }
            }
            Fill(2, 1, d);
            ExcelApp.Visible = true; //Отобразить Excel
            //Заполнение строк
            void Fill(int topRow, int leftCol, object[,] data)
            {
                int rows = data.GetUpperBound(0) + 1;
                int cols = data.GetUpperBound(1) + 1;

                Excel.Worksheet sheet = (Excel.Worksheet)ExcelApp.ActiveSheet;

                object leftTop = ExcelWorkSheet.Cells[topRow, leftCol];
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridViewListPrinter.RowCount - 1, leftCol + dataGridViewListPrinter.ColumnCount - 1];

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
                object[] border = new object[] { Excel.XlBordersIndex.xlEdgeLeft, //Лево
                                                Excel.XlBordersIndex.xlEdgeTop, //Верх
                                                Excel.XlBordersIndex.xlEdgeBottom, //Низ
                                                Excel.XlBordersIndex.xlEdgeRight, //Право
                                                Excel.XlBordersIndex.xlInsideVertical, //Вертикаль
                                                Excel.XlBordersIndex.xlInsideHorizontal}; //Горизонталь

                for (int i = 0; i < border.Length; i++)
                {
                    range.Borders[(Excel.XlBordersIndex)border[i]].LineStyle = Excel.XlLineStyle.xlContinuous; //Стиль
                    range.Borders[(Excel.XlBordersIndex)border[i]].Weight = Excel.XlBorderWeight.xlThin; //Толщина
                    range.Borders[(Excel.XlBordersIndex)border[i]].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                }

            }

        }

      

        //Sort Id
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewListPrinter.DataSource = null;

            var pr = from p in db.Printers
                     select new
                     {
                         p.Id,
                         Модель = p.ModelPrinter,
                         Артикул = p.Article,
                         Дата_покуки = p.DateTimes

                     };


            dataGridViewListPrinter.DataSource = pr.OrderBy(d => d.Id).ToList();
            dataGridViewListPrinter.Columns[0].Width = 45;
        }
        //sort Model Printer
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridViewListPrinter.DataSource = null;
            var pr = from p in db.Printers
                     select new
                     {
                         p.Id,
                         Модель = p.ModelPrinter,
                         Артикул = p.Article,
                         Дата_покуки = p.DateTimes

                     };

           
            dataGridViewListPrinter.DataSource = pr.OrderBy(d => d.Модель).ToList();
            dataGridViewListPrinter.Columns[0].Width = 45;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dataGridViewListPrinter.DataSource = null;

            var pr = from p in db.Printers
                     select new
                     {
                         p.Id,
                         Модель = p.ModelPrinter,
                         Артикул = p.Article,
                         Дата_покуки = p.DateTimes

                     };


            dataGridViewListPrinter.DataSource = pr.OrderBy(d => d.Артикул).ToList();
            dataGridViewListPrinter.Columns[0].Width = 45;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridViewListPrinter.DataSource = null;

            var pr = from p in db.Printers
                     select new
                     {
                         p.Id,
                         Модель = p.ModelPrinter,
                         Артикул = p.Article,
                         Дата_покуки = p.DateTimes

                     };


            dataGridViewListPrinter.DataSource = pr.OrderBy(d => d.Дата_покуки).ToList();
            dataGridViewListPrinter.Columns[0].Width = 45;
        }
    }
}
