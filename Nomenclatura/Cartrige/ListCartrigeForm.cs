using CartrigeAltstar.Model;
using CartrigeAltstar.Nomenclatura.Cartrige;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CartrigeAltstar
{
    public partial class ListCartrigeForm : Form
    {
        public string CultureDefine;
        private string UkrainCulture;
        private string RussianCulture;
        private string EngCulture;
        public ResourceManager resourceManager;
        public DateTime dateTime;
        ContexAltstarContext db;
       

        public ListCartrigeForm()
        {
            InitializeComponent();
         
            db = new ContexAltstarContext();
            db.Cartriges.Load();

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

        public void PrintCartrige()
        {

          
                var data = db.Cartriges.Local.ToBindingList();
                // Bind the BindingList to the DataGridView control.
                dataGridViewListCartrige.DataSource = data;
                dataGridViewListCartrige.Columns["Printers"].Visible = false;
                dataGridViewListCartrige.Columns[1].HeaderText= resourceManager.GetString("Cartrige");
                dataGridViewListCartrige.Columns[2].HeaderText= resourceManager.GetString("Article");
                dataGridViewListCartrige.Columns[3].HeaderText= resourceManager.GetString("Data");
                dataGridViewListCartrige.Columns[0].Width = 45;

            

        }


        private void ListCartrigeForm_Load(object sender, EventArgs e) => PrintCartrige();
       
        


        //Add Cartrige
        private void btnAddCartrige_Click(object sender, EventArgs e)
        {


            AddCartriges addctrgFrm = new AddCartriges();

         
            DialogResult result = addctrgFrm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;


            Cartrige cartrigeModel = new Cartrige();

           
                cartrigeModel.purchase_date = addctrgFrm.txtDatetimeCartrige.Value;
                cartrigeModel.ModelCartrige = addctrgFrm.txtModelCartrige.Text;
                cartrigeModel.ArticleCartrige = addctrgFrm.txtArticleCartrige.Text;
            //Check
            if (addctrgFrm.txtModelCartrige.Text != "" && addctrgFrm.txtArticleCartrige.Text != "")
            {
                db.Cartriges.Add(cartrigeModel);

                db.SaveChanges();



                MessageBox.Show(resourceManager.GetString("AddNewCartrigeMsgBox"));
                dataGridViewListCartrige.DataSource = null;
                this.dataGridViewListCartrige.Update();
                this.dataGridViewListCartrige.Refresh();
                PrintCartrige();
            }
            else 
            {
                MessageBox.Show("Please Provide Details!");
            }

        }

        //Delete Cartrige
        private void btnDellCartrige_Click(object sender, EventArgs e)
        {

            // Delete Cartrige
            if (dataGridViewListCartrige.SelectedRows.Count > 0)
            {
                int index = dataGridViewListCartrige.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dataGridViewListCartrige[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Cartrige cartrigeDel = db.Cartriges.Find(id);
                db.Cartriges.Remove(cartrigeDel);
                db.SaveChanges();
                
                dataGridViewListCartrige.DataSource = null;
                this.dataGridViewListCartrige.Update();
                this.dataGridViewListCartrige.Refresh();
                MessageBox.Show("Картридж Удален ");
                PrintCartrige();
                

            }


        }
        //UPDATE Cartrige
        private void btnUpdateCartrige_Click(object sender, EventArgs e)
        {



            // update Cartrige
            if (dataGridViewListCartrige.SelectedRows.Count > 0)
            {
                int index = dataGridViewListCartrige.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewListCartrige[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                //екземпляр Формы
                AddCartriges updateCartrigeForm = new AddCartriges();

                //заполнение полей
                Cartrige cartrigeUpdate = db.Cartriges.Find(id);
                updateCartrigeForm.txtDatetimeCartrige.Text = cartrigeUpdate.purchase_date.ToString();
                updateCartrigeForm.txtModelCartrige.Text = cartrigeUpdate.ModelCartrige;
                updateCartrigeForm.txtArticleCartrige.Text = cartrigeUpdate.ArticleCartrige;

                //откритие диалогового окна AddCartrige
                DialogResult result = updateCartrigeForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                //
                cartrigeUpdate.purchase_date = updateCartrigeForm.txtDatetimeCartrige.Value;
                cartrigeUpdate.ModelCartrige = updateCartrigeForm.txtModelCartrige.Text;
                cartrigeUpdate.ArticleCartrige = updateCartrigeForm.txtArticleCartrige.Text;


                //подключения к состоянию обьявив его модифицированним
                db.Entry(cartrigeUpdate).State = EntityState.Modified;
                db.SaveChanges();


                MessageBox.Show("Картридж Обновлен ");
                dataGridViewListCartrige.DataSource = null;
                this.dataGridViewListCartrige.Update();
                this.dataGridViewListCartrige.Refresh();
                PrintCartrige();

            }

        }
        //Export to Exel cartridges
        private void btnExportCartroge_Click(object sender, EventArgs e)
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
            var datenow = curTime.ToShortDateString().ToString();
            datenow = datenow.Replace("/", ".");

            ExcelWorkSheet.Name = $"Крартриджи - {resourceManager.GetString("printReceptExel")} "; //Название листа (вкладки снизу)

            object[,] d = new object[dataGridViewListCartrige.RowCount, dataGridViewListCartrige.ColumnCount];

            for (int i = 1; i < dataGridViewListCartrige.Columns.Count ; i++) //cols Header
            {

                ExcelWorkSheet.Cells[1, i] = dataGridViewListCartrige.Columns[i - 1].HeaderText;
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

            for (int i = 0; i < dataGridViewListCartrige.Rows.Count -1; i++) //отступ вниз 1
            {
                for (int j = 0; j < dataGridViewListCartrige.Columns.Count - 1; j++) //cols Body (data)
                {
                    d[i, j] = dataGridViewListCartrige.Rows[i].Cells[j].Value.ToString();
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
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridViewListCartrige.RowCount - 2, leftCol + dataGridViewListCartrige.ColumnCount - 2]; //cols body border

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

        private void btnClosed_Click(object sender, EventArgs e) => Close();
        
     
    
    
      
    }
}
