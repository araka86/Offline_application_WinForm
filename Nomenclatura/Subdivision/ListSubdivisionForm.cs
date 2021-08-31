using CartrigeAltstar.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CartrigeAltstar
{


    public partial class ListSubdivisionForm : Form
    {

        ContexAltstarContext db;

        public ListSubdivisionForm()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
            db.Subdivisions.Load();
        }


        public void ShowSubdivision()
        {
            var sub = from r in db.Subdivisions
                      select new
                      {
                          iD = r.Id,
                          Подразделения = r.division,
                          Адресс = r.address_part
                      };
            dataGridViewListSubdivision.DataSource = sub.ToList();
            dataGridViewListSubdivision.Columns[0].Width = 45;
        }


        private void ListSubdivisionForm_Load(object sender, EventArgs e)
        {
            ShowSubdivision();
        //   PropertyInfo verticalOffset = dataGridViewListSubdivision.GetType().GetProperty("VerticalOffset", BindingFlags.NonPublic | BindingFlags.Instance);
        //   verticalOffset.SetValue(this.dataGridViewListSubdivision, 10, null);
        }


        //Add Subdivision
        private void button6_Click(object sender, EventArgs e)
        {


            //Add подразделения


            AddSubdivision addSubdivisionForm = new AddSubdivision();


            DialogResult result = addSubdivisionForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;




            Subdivision subdivisionModel = new Subdivision();
            subdivisionModel.division = addSubdivisionForm.txtModelDivision.Text;
            subdivisionModel.address_part = addSubdivisionForm.txtStreet.Text;
            db.Subdivisions.Add(subdivisionModel);



            db.SaveChanges();

            MessageBox.Show("Новое подразделение добавленно ");
            dataGridViewListSubdivision.DataSource = null;
            this.dataGridViewListSubdivision.Update();
            this.dataGridViewListSubdivision.Refresh();
            ShowSubdivision();



        }

        //DELETE Subdivision
        private void button7_Click(object sender, EventArgs e)
        {


            if (dataGridViewListSubdivision.SelectedRows.Count > 0)
            {
                int index = dataGridViewListSubdivision.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewListSubdivision[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Subdivision subdivisionModel = db.Subdivisions.Find(id);
                db.Subdivisions.Remove(subdivisionModel);
                db.SaveChanges();
                MessageBox.Show("Подразделение Удаленно!!! ");
                dataGridViewListSubdivision.DataSource = null;
                this.dataGridViewListSubdivision.Update();
                this.dataGridViewListSubdivision.Refresh();
                ShowSubdivision();


            }

        }


        //UPDATE Subdivision
        private void button8_Click(object sender, EventArgs e)
        {


            if (dataGridViewListSubdivision.SelectedRows.Count > 0)
            {
                int index = dataGridViewListSubdivision.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewListSubdivision[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                //екземпляр Формы
                AddSubdivision updateSubdivisionForm = new AddSubdivision();

                //заполнение полей
                Subdivision subdivisionModel = db.Subdivisions.Find(id);
                updateSubdivisionForm.txtModelDivision.Text = subdivisionModel.division;
                updateSubdivisionForm.txtStreet.Text = subdivisionModel.address_part;


                //откритие диалогового окна AddCartrige
                DialogResult result = updateSubdivisionForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                //
                subdivisionModel.division = updateSubdivisionForm.txtModelDivision.Text;
                subdivisionModel.address_part = updateSubdivisionForm.txtStreet.Text;


                //подключения к состоянию обьявив его модифицированним
                db.Entry(subdivisionModel).State = EntityState.Modified;
                db.SaveChanges();


                MessageBox.Show("Подразделение Обновленно!! ");
                dataGridViewListSubdivision.DataSource = null;
                this.dataGridViewListSubdivision.Update();
                this.dataGridViewListSubdivision.Refresh();
                ShowSubdivision();

            }

        }

        //EXPORT to EXCEL

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
            ExcelWorkSheet.Name = "Подразделения -  " + curTime.ToShortDateString().ToString(); //Название листа (вкладки снизу)
            object[,] d = new object[dataGridViewListSubdivision.RowCount, dataGridViewListSubdivision.ColumnCount];
            for (int i = 1; i < dataGridViewListSubdivision.Columns.Count + 1; i++)
            {

                ExcelWorkSheet.Cells[1, i] = dataGridViewListSubdivision.Columns[i - 1].HeaderText;

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

            for (int i = 0; i < dataGridViewListSubdivision.Rows.Count; i++) //отступ вниз 1
            {
                for (int j = 0; j < dataGridViewListSubdivision.Columns.Count; j++)
                {
                    d[i, j] = dataGridViewListSubdivision.Rows[i].Cells[j].Value.ToString();
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
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridViewListSubdivision.RowCount - 1, leftCol + dataGridViewListSubdivision.ColumnCount - 1];

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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Sort Id
        private void button2_Click(object sender, EventArgs e)
        {
            var sub = from r in db.Subdivisions
                      select new
                      {
                          iD = r.Id,
                          Подразделения = r.division,
                          Адресс = r.address_part
                      };
            dataGridViewListSubdivision.DataSource = sub.OrderBy(s=>s.iD).ToList();
            dataGridViewListSubdivision.Columns[0].Width = 45;

        }
        //Sort division
        private void button3_Click(object sender, EventArgs e)
        {

            var sub = from r in db.Subdivisions
                      select new
                      {
                          iD = r.Id,
                          Подразделения = r.division,
                          Адресс = r.address_part
                      };
            dataGridViewListSubdivision.DataSource = sub.OrderBy(s => s.Подразделения).ToList();
            dataGridViewListSubdivision.Columns[0].Width = 45;

        }
        //Sort Adddress
        private void button4_Click(object sender, EventArgs e)
        {
            var sub = from r in db.Subdivisions
                      select new
                      {
                          iD = r.Id,
                          Подразделения = r.division,
                          Адресс = r.address_part
                      };
            dataGridViewListSubdivision.DataSource = sub.OrderBy(s => s.Адресс).ToList();
            dataGridViewListSubdivision.Columns[0].Width = 45;
        }
    }
}
