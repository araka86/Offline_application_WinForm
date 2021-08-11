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
    public partial class CartrigePlace : Form
    {
        ContexAltstarContext db;
        public CartrigePlace()
        {
            InitializeComponent();

            db = new ContexAltstarContext();

            db.Receptions.Load();
        }
        //Добавление перемещения
        private void button1_Click(object sender, EventArgs e)
        {
            CartrigeSubdivision cartrigeSubdivisionForm = new CartrigeSubdivision(); //екземпляр формы CartrigeSubdivision


            //выборка данных
               var crt = from ct1 in db.Cartriges select (ct1.ArticleCartrige);
               var div = from dv in db.Subdivisions select (dv.division);

            //заполнения comboBox даними
               cartrigeSubdivisionForm.comboBoxSub.DataSource = div.ToList();
               cartrigeSubdivisionForm.comboBoxCartrige.DataSource = crt.ToList();



            //вызов окна
                 DialogResult result = cartrigeSubdivisionForm.ShowDialog(this);
                 if (result == DialogResult.Cancel)
                     return;



            Compatibility cm = new Compatibility();

            //choise combobox Cartrige
            var c = cartrigeSubdivisionForm.comboBoxCartrige.SelectedItem.ToString(); 



            //Find Cartrige
            var ctt = db.Cartriges.Single(t => t.ArticleCartrige.StartsWith(c));


            cm.CartrigeId = ctt.Id; //write Foreign Key

            //choise combobox Subdivision
            var t3 = cartrigeSubdivisionForm.comboBoxSub.SelectedItem.ToString();
            //Find Subdivision
            var t4 = db.Subdivisions.Single(t5 => t5.division.StartsWith(t3));

            cm.SubdivisionId = t4.Id; //write Foreign Key


            db.Compatibilities.Add(cm);
            db.ChangeTracker.DetectChanges();
            db.SaveChanges();
            MessageBox.Show("Перемещение Добавленно!!! ");
            dataGridView1.DataSource = null;
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            ShowCartige();




        }

        public void ShowCartige() 
        {
            var cp = from c1 in db.Compatibilities
                     select new
                     {
                         c1.id,
                         Модель = c1.CartrigePK.ModelCartrige,
                         Артикул = c1.CartrigePK.ArticleCartrige,
                         Подразделение = c1.SubdivisionPK.division

                     };

            dataGridView1.DataSource = cp.ToList(); //внесение данных в dataGridView1
        }
        //удаления
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                AddDellCartrigeSubdivisionForm addDellCartrigeSubdivisionForm = new AddDellCartrigeSubdivisionForm();

                Compatibility cmUpd = db.Compatibilities.Find(id);

                db.Compatibilities.Remove(cmUpd);
                db.SaveChanges();
                MessageBox.Show("Перемещение Удаленно!!! ");
                dataGridView1.DataSource = null;
                this.dataGridView1.Update();
                this.dataGridView1.Refresh();
                ShowCartige();
            }
        }


        //обновоение перемещения
        private void button2_Click(object sender, EventArgs e)
        {
          

           

            if (dataGridView1.SelectedRows.Count > 0)
            {
                CartrigeSubdivision cartrigeSubdivisionForm = new CartrigeSubdivision();
                var crt = from ct1 in db.Cartriges select (ct1.ArticleCartrige);
                var div = from dv in db.Subdivisions select (dv.division);


                cartrigeSubdivisionForm.comboBoxSub.DataSource = div.ToList();
                cartrigeSubdivisionForm.comboBoxCartrige.DataSource = crt.ToList();








               



                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id); //Find Index

                Compatibility cmUpd = db.Compatibilities.Find(id); //поиск индекса в таблице совместимости внешнего ключа
                Cartrige fndCtt = db.Cartriges.Find(cmUpd.CartrigeId); //поиск индека в таблице картриджи первичного ключа


                int findIndexComboboxCartrigeArticle = cartrigeSubdivisionForm.comboBoxCartrige.FindString(fndCtt.ArticleCartrige); //find index comboboxCatrige

                cartrigeSubdivisionForm.comboBoxCartrige.SelectedIndex = findIndexComboboxCartrigeArticle;





                DialogResult result = cartrigeSubdivisionForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;


                if (converted == false)
                    return;





               

            }





              

        }
    }
}
