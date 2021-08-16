using CartrigeAltstar.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar
{

    public partial class InfoOrgTechnic : Form
    {
        ContexAltstarContext db;
        public InfoOrgTechnic()
        {
            InitializeComponent();
            db = new ContexAltstarContext();



        }

        private void InfoOrgTechnic_Load(object sender, EventArgs e)
        {
            db.Printers.Load();
            db.Subdivisions.Load();
            db.Cartriges.Load();
            db.Compatibilities.Load();





            var queryPrinter = from p in db.Printers
                               select new
                               {
                                   p.Id,
                                   Принтер = p.ModelPrinter,
                                   Артикул = p.Article
                               };

            var queryCartrige = from p in db.Cartriges
                                select new
                                {
                                    p.Id,
                                    Картридж = p.ModelCartrige,
                                    Артикул = p.ArticleCartrige
                                };


            db.Subdivisions.Load();
            db.Printers.Load();
            var a1 = (from usr in db.Printers.Include(p => p.ModelPrinter) select usr);
            dataGridView1.DataSource = queryPrinter.ToList();
            dataGridView2.DataSource = queryCartrige.ToList();
            dataGridView2.Columns[0].Width = 45;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;


            Printer sb = db.Printers.Find(ids);
            Subdivision subdivision = new Subdivision();

      //  db.Entry(sb).Reference("Printers").Load();
        //    db.Entry(subdivision).Collection("Printers").Load();



            var p = from l in db.Subdivisions
                    where l.Id == sb.SubdivisionId
                    select new
                    {
                        l.Id,
                         Подразделение = l.division,
                        Адресс = l.address_part,
                      
                    };


            dataGridView4.DataSource = p.ToList();


            //
            //    if (listBox1.Items.Count != 0)
            //    {
            //        listBox1.Items.Clear();
            //        listBox1.Items.Add(sb.SubdivisioPK.division);
            //        listBox1.DisplayMember = "Id";
            //    }
            //    else
            //    {
            //        listBox1.Items.Add(sb.SubdivisioPK.division);
            //        listBox1.DisplayMember = "Id";
            //    }


        }


        private void button4_Click_1(object sender, EventArgs e)
        {

            int index = dataGridView2.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;



            Cartrige cartrige = db.Cartriges.Find(ids);

            db.Entry(cartrige).Collection("Printers").Load();


            List<Cartrige> parts = new List<Cartrige>();


            parts.Add(cartrige);

            var r = from b in cartrige.Printers 
                    select new
                    {

                        b.Id,
                        b.ModelPrinter,
                        b.Article

                    };


            dataGridView3.DataSource = r.ToList();

            //       listBox2.DataSource = cartrige.Printers.ToList();
            //
            //       listBox2.DisplayMember = "ModelPrinter";
            //

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //редактирования Совместимость картридж - Принтеры
        private void button3_Click(object sender, EventArgs e)
        {
            //находим id с dataGridView2 отображаемого картриджа
            int index = dataGridView2.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;

            //создаем екземпляр формы
            AddI_Del_infoOrgTehnic addI_Del_InfoOrgTehnicForm = new AddI_Del_infoOrgTehnic();

            //находим выбранний картридж в базе
            Cartrige cartrigeAdd = db.Cartriges.Find(ids);
            //заполняем поля
            addI_Del_InfoOrgTehnicForm.textBoxCartrige.Text = cartrigeAdd.ModelCartrige;
            addI_Del_InfoOrgTehnicForm.textBoxArticleCartige.Text = cartrigeAdd.ArticleCartrige;

            //создаем запрос для comboBoxPrinter
            var printerAdd = from a in db.Printers
                             select new
                             {
                                 a.Id,
                                 Модель = a.ModelPrinter,
                                 Артикул = a.Article
                             };

            //ковретрируем в ToList
            var p = printerAdd.ToList();

            //указываем размер  строкового масива
            string[] sdata = new string[p.Count];

            //Производим замену знакам с  } на )
            for (int i = 0; i < p.Count; i++)
            {

                sdata[i] = p[i].ToString().Replace('}', ')').Replace('{', '(');

            }
            //добавляем в comboBoxPrinter(выпадающее окно)
            addI_Del_InfoOrgTehnicForm.comboBoxPrinter.DataSource = sdata.ToList();


            //откриваем форму
            DialogResult result = addI_Del_InfoOrgTehnicForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;



            //внорсим в переменную выбранную позицию с (выпадающего списка )comboBoxPrinter
            string res2 = addI_Del_InfoOrgTehnicForm.comboBoxPrinter.SelectedItem.ToString();
            //делаем обрезание оставляя id
            string trimmed = res2.Substring(res2.IndexOf("(") + 1, res2.IndexOf(",") - 1);

            //извлекаем цифру регулярнім выражением)
            string pattern = @"\d+";
            Regex reg = new Regex(pattern);
            MatchCollection m = reg.Matches(trimmed);
            int[] mas = new int[m.Count];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = int.Parse(m[i].Value);
            }
            //переносим из масива в переменную немасива getId (Printers) На віходе получаем выбранную из списка интовую id Printers
            int getId = mas[0];


            //находим принтер в базе выбранным принтеров с комбобокса(выпадающего списка) и вносим в переменную типа db.Printers
            var pr = db.Printers.Find(getId);

            //записиваем в таблицу принтер поле CartrigeId ранее выбранним с таблици Cartrige id
            pr.CartrigeId = cartrigeAdd.Id;
            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
            MessageBox.Show("Перемещение обновленно");



        }





        //редактирования Совместимость Принтер - Подразделения
        private void button1_Click(object sender, EventArgs e)
        {



            //находим айди  принтера

            int index = dataGridView1.SelectedRows[0].Index;
            int ids;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out ids);
            if (converted == false)
                return;

            //создаем екземпляр формы
            AddI_Del_infoOrgTehnic addI_Del_InfoOrgTehnicForm = new AddI_Del_infoOrgTehnic();

            //находим принтер  по айди в базе
            Printer printerAdd = db.Printers.Find(ids);
            
           //заполняем поля
            addI_Del_InfoOrgTehnicForm.textBoxCartrige.Text = printerAdd.ModelPrinter;
            addI_Del_InfoOrgTehnicForm.textBoxArticleCartige.Text = printerAdd.Article;


            //создаем запрос для комбобокса Subdivisions
            var divisionAdd = from a in db.Subdivisions
                             select new
                             {
                                 a.Id,
                                 Модель = a.division,
                                 Артикул = a.address_part
                             };

            // в лист
            var p = divisionAdd.ToList();

            // указываем размер для строкового масива
            string[] sdata = new string[p.Count];

            //изменяем знаки
            for (int i = 0; i < p.Count; i++)
            {

                sdata[i] = p[i].ToString().Replace('}', ')').Replace('{', '(');

            }

            //добавляем в выпадающий список
            addI_Del_InfoOrgTehnicForm.comboBoxPrinter.DataSource = sdata.ToList();


            //открываем окно
            DialogResult result = addI_Del_InfoOrgTehnicForm.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;



            //вносим в переменную выбранную позицию
            string res2 = addI_Del_InfoOrgTehnicForm.comboBoxPrinter.SelectedItem.ToString();
            //обрезаем
            string trimmed = res2.Substring(res2.IndexOf("(") + 1, res2.IndexOf(",") - 1);

            //выкорчовуем цифру
            string pattern = @"\d+";


            Regex reg = new Regex(pattern);
            MatchCollection m = reg.Matches(trimmed);
            int[] mas = new int[m.Count];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = int.Parse(m[i].Value);
            }


            //цифру с масива убираем
            int getId = mas[0];




            //находим подразделение в базе выбраннымподразделением с комбобокса(выпадающего списка) и вносим в переменную типа db.Subdivisions
            var pr = db.Subdivisions.Find(getId);


       //     Subdivision subdivisionadd = db.Subdivisions.Find(getId);


            printerAdd.SubdivisionId = pr.Id;





            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
            MessageBox.Show("Перемещение обновленно");


        }
    }
}
