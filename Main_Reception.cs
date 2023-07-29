using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using CartrigeAltstar.Model;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Resources;

using System.Globalization;
//Простір, використовуваний для роботи з файлами ресурсів .resx,
using System.Reflection;

namespace CartrigeAltstar
{
    public partial class Main_Reception : Form
    {
        ContexAltstarContext db;
        //Переменная выбора, необходимая для определения культуры 
        public string CultureDefine;
        //Переменная для хранения английской культуры
        private string UkrainCulture;
        //Переменная для русской культуры.
        private string RussianCulture;
        private string EngCulture;
        //Создаем экземпляр resourceManager класса ResourceManager
        public ResourceManager resourceManager;
        public DateTime dateTime;




        public Main_Reception(string FormCulture = "en")
        {

            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            CultureDefine = FormCulture;
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

            db = new ContexAltstarContext();
            db.Subdivisions.Load();

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


        public string[] ForCartrigeArticleComboboxCUT()
        {
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

                //     sdata[i] = p[i].ToString().Replace('}', ')').Replace('{', '(');

                sdata[i] = p[i].ToString().Trim(new char[] { '{', '}' });


            }
            return sdata;

        }
        public string[] ForCartrigeArticleComboboxFull()
        {
            var ListCartrige = from lc in db.Cartriges
                               select new
                               {
                                   Model = lc.ModelCartrige,
                                   Article = lc.ArticleCartrige
                               };


            var p = ListCartrige.ToList();
            string[] sdata = new string[p.Count];
            //изменяем знаки
            for (int i = 0; i < p.Count; i++)
            {

                sdata[i] = p[i].ToString().Replace('}', ')').Replace('{', '(');



            }
            return sdata;

        }



        private void Reception_Load(object sender, EventArgs e)
        {
            printRecept();      //reception
            PrintDispatch();    //sending

            //Fill Filter
            comboBoxFiltrCartrige.DataSource = ForCartrigeArticleComboboxCUT().ToList();
            comboBoxFiltrDispath.DataSource = ForCartrigeArticleComboboxCUT().ToList();

            comboBoxDepertment.DataSource =  db.Subdivisions.Select(x=>x.division).ToArray();
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

        public void printRecept(int cntMonth = -2) // reception
        {

            dataGridView1.Columns.Clear();

            
            if (cntMonth != 0)
            {
               dateTime = DateTime.Now.AddMonths(cntMonth);
               dataGridView1.DataSource = db.Receptions.Where(x => x.Дата >= dateTime).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Receptions.ToList();
            }
               

           
            dataGridView1.Columns[0].Width = 65;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[1].HeaderText = resourceManager.GetString("Data");
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[2].HeaderText = resourceManager.GetString("Cartrige");
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[3].HeaderText = resourceManager.GetString("Weight");
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[4].HeaderText = resourceManager.GetString("Status");
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].HeaderText = resourceManager.GetString("Subivision");

        }

        public void PrintDispatch(int cntMonth = -2) //Dispatches 
        {


            if (cntMonth != 0)
            {
                dateTime = DateTime.Now.AddMonths(cntMonth);
                dataGridView2.DataSource = db.Dispatches.Where(x => x.Дата >= dateTime).ToList();
            }
            else
            {
                dataGridView2.DataSource = db.Dispatches.ToList();
            }

           
            dataGridView2.Columns[0].Width = 65;
            dataGridView2.Columns[1].Width = 220;
            dataGridView2.Columns[1].HeaderText = resourceManager.GetString("Data");
            dataGridView2.Columns[2].Width = 300;
            dataGridView2.Columns[2].HeaderText = resourceManager.GetString("Cartrige");
            dataGridView2.Columns[3].Width = 200;
            dataGridView2.Columns[3].HeaderText = resourceManager.GetString("Notes");
            dataGridView2.Columns[4].Width = 200;
            dataGridView2.Columns[4].HeaderText = resourceManager.GetString("Weight");
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[5].HeaderText = resourceManager.GetString("Subivision");
        }


        //ADD INSERT ////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {

            ReceptionConfig receptioncfg = new ReceptionConfig();

            var ListCartrige = from lc in db.Cartriges
                               select lc.ModelCartrige;

            var ListDivision = from ls in db.Subdivisions
                               select ls.division;

            receptioncfg.comboBoxCartrige.DataSource = ForCartrigeArticleComboboxFull().ToList();
            receptioncfg.comboBoxDivision.DataSource = ListDivision.ToList();


            DialogResult result = receptioncfg.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            Reception reception = new Reception();

            reception.Дата = receptioncfg.txtdate.Value;
            reception.Подразделения = receptioncfg.comboBoxDivision.Text.ToString();

            //вносим в переменную выбранную позицию
            string res2 = receptioncfg.comboBoxCartrige.SelectedItem.ToString();
            //обрезаем


            string trimmed = res2.Trim(new char[] { '(', ')' });

            reception.Картридж = trimmed.ToString();

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





          //  db.Currents.Add(reception);

            MessageBox.Show(resourceManager.GetString("WriteSuccessCartigeIn"));
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
                bool converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out id); //Find Index
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
                //      receptionConfigUpdateForm.comboBoxCartrige.DataSource = MiGlobalFunction();

                receptionConfigUpdateForm.comboBoxCartrige.DataSource = ForCartrigeArticleComboboxFull().ToList();


                //достаем из базы ранее найденую по id чистую запись (без скобок) и вешаем скобки для поиска на равенство
                var findForFiltrCartrige = "(" + receptionupdateModel.Картридж + ")";


                int findIndexComboboxCartrige = receptionConfigUpdateForm.comboBoxCartrige.FindString(findForFiltrCartrige); //поиск индекса в comboBoxCartrige
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

                //вносим в переменную выбранную позицию
                string res2 = receptionConfigUpdateForm.comboBoxCartrige.SelectedItem.ToString();
                //обрезаем
                string trimmed = res2.Trim(new char[] { '(', ')' });
                receptionupdateModel.Картридж = trimmed.ToString(); //заполнения картриджа

                receptionupdateModel.Картридж = trimmed.ToString(); //заполнения картриджа

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


              

                MessageBox.Show(resourceManager.GetString("WriteIsUpdated"));
                dataGridView1.DataSource = null; //занулить датагрид
                dataGridView1.Update(); //обновить
                dataGridView1.Refresh(); //обновить
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

            moving_the_cartridge ctpl = new moving_the_cartridge(); // екземпляр формы CartrigePlace


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


        }

        private void resetFiltr_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            printRecept();
        }

        //EXEL RECEPT
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

            var datenow = curTime.ToShortDateString().ToString();
            datenow = datenow.Replace("/", ".");

            ExcelWorkSheet.Name = $"{resourceManager.GetString("printReceptExel")} - {datenow}"; //Название листа (вкладки снизу)

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

            for (int i = 0; i < dataGridView1.Rows.Count; i++) //отступ вниз 1
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

                Worksheet sheet = (Worksheet)ExcelApp.ActiveSheet;

                object leftTop = ExcelWorkSheet.Cells[topRow, leftCol];
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridView1.RowCount - 1, leftCol + dataGridView1.ColumnCount - 1];

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
                    range.Borders[(Excel.XlBordersIndex)border[i]].LineStyle = Excel.XlLineStyle.xlContinuous; //Стиль
                    range.Borders[(Excel.XlBordersIndex)border[i]].Weight = Excel.XlBorderWeight.xlThin; //Толщина
                    range.Borders[(XlBordersIndex)border[i]].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
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
            comboBoxFiltrDispath.DataSource = null;
            comboBoxFiltrCartrige.DataSource = ForCartrigeArticleComboboxCUT().ToList();
            comboBoxFiltrDispath.DataSource = ForCartrigeArticleComboboxCUT().ToList();


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
            dispatchConfigForm.comboBoxCartrige.DataSource = ForCartrigeArticleComboboxFull().ToList();
            var ListDivision = from ls in db.Subdivisions
                               select ls.division;

            //  dispatchConfigForm.comboBoxCartrige.DataSource = ListCartrige.ToList();
            dispatchConfigForm.comboBoxDivision.DataSource = ListDivision.ToList();


            DialogResult result = dispatchConfigForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;



            //вносим в переменную выбранную позицию
            string res2 = dispatchConfigForm.comboBoxCartrige.SelectedItem.ToString();
            //обрезаем



            string trimmed = res2.Trim(new char[] { '(', ')' });



            Dispatch dispatchModel = new Dispatch();


            dispatchModel.Картридж = trimmed.ToString();

            dispatchModel.Дата = dispatchConfigForm.txtdate.Value; // дата отправки
            dispatchModel.Подразделения = dispatchConfigForm.comboBoxDivision.Text.ToString(); //подразделение
                                                                                               //     dispatchModel.Картридж = dispatchConfigForm.comboBoxCartrige.Text.ToString(); // картридж
            dispatchModel.Заметки = dispatchConfigForm.txtZametki.Text.ToString(); //Заметки

            dispatchModel.Вес = Convert.ToDouble(dispatchConfigForm.txtWeight.Text); //Вес

            db.Dispatches.Add(dispatchModel);
            db.SaveChanges();

            var qwe = resourceManager.GetString("WriteSuccessCartigeOut");
            MessageBox.Show(resourceManager.GetString("WriteSuccessCartigeOut"));
            dataGridView2.DataSource = null;
            this.dataGridView2.Update();
            this.dataGridView2.Refresh();
            PrintDispatch();

        }

        private void button14_Click(object sender, EventArgs e) => dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Ascending);



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


                dispatchnConfigUpdateForm.comboBoxCartrige.DataSource = ForCartrigeArticleComboboxFull().ToList();

                //достаем из базы ранее найденую по id чистую запись (без скобок) и вешаем скобки для поиска на равенство
                var findForFiltrCartrige = "(" + dispatchUpdateModel.Картридж + ")";

                int findIndexComboboxCartrige = dispatchnConfigUpdateForm.comboBoxCartrige.FindString(findForFiltrCartrige); //поиск строки в comboBoxCartrige
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

                //вносим в переменную выбранную позицию
                string res2 = dispatchnConfigUpdateForm.comboBoxCartrige.SelectedItem.ToString();
                //обрезаем
                string trimmed = res2.Trim(new char[] { '(', ')' });
                dispatchUpdateModel.Картридж = trimmed.ToString(); //заполнения картриджа



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
        //применения фильтра
        private void button12_Click(object sender, EventArgs e)
        {
            //заполняем выбранное
            string searchValue = comboBoxFiltrDispath.SelectedItem.ToString();


            //находим запись в базе
            var ctt = from u in db.Dispatches.Where(p => p.Картридж == searchValue) select u;


            dataGridView2.DataSource = null;
            this.dataGridView2.Update();
            this.dataGridView2.Refresh();
            dataGridView2.DataSource = ctt.ToList();
            dataGridView2.Columns[0].Width = 65;
            dataGridView2.Columns[1].Width = 220;
            dataGridView2.Columns[2].Width = 300;
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

        //EXPORT EXCEL Sending
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

            var datenow = curTime.ToShortDateString().ToString();
            datenow = datenow.Replace("/", ".");

            ExcelWorkSheet.Name = $"{resourceManager.GetString("printSendingExel")} - {datenow}"; //Название листа (вкладки снизу)

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


            var qwer = dataGridView2.RowCount + 1;

            for (int i = 0; i < dataGridView2.Rows.Count; i++) //отступ вниз 1
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

        private void button14_Click_1(object sender, EventArgs e)
        {
            moving_the_cartridge ctpl = new moving_the_cartridge(); // екземпляр формы CartrigePlace


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

        private void button5_Click(object sender, EventArgs e)
        {

            db.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

            О_программе o_ = new О_программе();
            o_.ShowDialog();
        }
        ///UA
        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            CultureDefine = UkrainCulture;
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, true);

            this.Hide();
            new Main_Reception(CultureDefine).Show();
        }

        //RU
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            CultureDefine = RussianCulture;
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, true);

            this.Hide();
            new Main_Reception(CultureDefine).Show();



        }
        //EN
        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            CultureDefine = EngCulture;
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, true);

            Main_Reception main_Reception = new Main_Reception(CultureDefine);


            this.Hide();
            new Main_Reception().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
        //Show all time  reception
        private void button19_Click(object sender, EventArgs e) => printRecept(0); 

        //Show last 2 month  reception
        private void button18_Click(object sender, EventArgs e) => printRecept();  
     
        //Show last month  reception
        private void button5_Click_1(object sender, EventArgs e) => printRecept(-1);      //reception
        

        //Show all time  Sending
        private void button21_Click(object sender, EventArgs e) => PrintDispatch(0);      //sending

       
        //Show last 2 month  sending
        private void button20_Click(object sender, EventArgs e) => PrintDispatch();      //sending
        
        //Show last month  sending
        private void button17_Click(object sender, EventArgs e) => PrintDispatch(-1);      //sending

        private void button22_Click(object sender, EventArgs e)
        {
            string searchValue = comboBoxDepertment.SelectedItem.ToString();

        }
    }

    //1
}
