using CartrigeAltstar.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CartrigeAltstar
{
    public partial class ListSettingPinterForm : Form
    {
        public string CultureDefine;
        private string UkrainCulture;
        private string RussianCulture;
        private string EngCulture;
        public ResourceManager resourceManager;
        public DateTime dateTime;
        ContexAltstarContext db;

        public ListSettingPinterForm()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
            db.Printers.Load();
            UkrainCulture = "uk-UA";
            RussianCulture = "ru-RU";
            EngCulture = "en";

            if (CultureDefine == UkrainCulture)
            {
                // Создаем новый объект resourceManager, извлекающий из сборки 
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langUA", Assembly.GetExecutingAssembly());
            }
            else if (CultureDefine == RussianCulture)
            {
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langRU", Assembly.GetExecutingAssembly());
            }
            else
            {
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langEN", Assembly.GetExecutingAssembly());
            }



        }

        private void ListSettingPinterForm_Load(object sender, EventArgs e) => PrintPrinter();
        

        

        //------------------------Вивод Принтеров----------------------------
        public void PrintPrinter()
        {

          

            var data = db.Printers.Local.ToBindingList();
            dataGridViewListPrinter.DataSource = data;
            dataGridViewListPrinter.Columns["SubdivisionId"].Visible = false;
            dataGridViewListPrinter.Columns["CartrigeId"].Visible = false;
            dataGridViewListPrinter.Columns["CartrigePK"].Visible = false;
            dataGridViewListPrinter.Columns["SubdivisioPK"].Visible = false;
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

            MessageBox.Show(resourceManager.GetString("AddNewPrinterMsgBox"));
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


                MessageBox.Show(resourceManager.GetString("DelPrinterMsgBox"));
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


                MessageBox.Show(resourceManager.GetString("UpdatePrinterMsgBox"));
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
            ExcelWorkBook = ExcelApp.Workbooks.Add(Missing.Value); //Добавить рабочую книгу
            ExcelApp.DisplayAlerts = false; //Отключить отображение окон с сообщениями
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1); //Получаем первый лист документа (счет начинается с 1) (переключение междк листами)

            var datenow = curTime.ToShortDateString().ToString();
            datenow = datenow.Replace("/", ".");



            ExcelWorkSheet.Name = $"{resourceManager.GetString("printersList")} - {datenow} ";      //update .net6 


            object[,] d = new object[dataGridViewListPrinter.RowCount, dataGridViewListPrinter.ColumnCount];

            for (int i = 1; i < dataGridViewListPrinter.Columns.Count-3; i++) // +1del cols Header
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
            for (int i = 0; i < dataGridViewListPrinter.Rows.Count -1; i++) //отступ вниз -1
            {
                for (int j = 0; j < dataGridViewListPrinter.Columns.Count -2 ; j++) //cols Body (data) -1
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
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridViewListPrinter.RowCount - 1, leftCol + dataGridViewListPrinter.ColumnCount - 5]; //cols body border RowCount - 2 ColumnCount - 2

                Excel.Range range = ExcelWorkSheet.get_Range(leftTop, rightBottom);
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
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //all column center
                }

            }

        }



    }
}
