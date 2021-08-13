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


namespace CartrigeAltstar.Nomenclatura.Cartrige
{
    public partial class ListCartrigeForm : Form
    {

        ContexAltstarContext db;


        public ListCartrigeForm()
        {
            InitializeComponent();
            db = new ContexAltstarContext();
            db.Printers.Load();

        }

        public void PrintCartrige()
        {

            var pr = from p in db.Cartriges
                     select new
                     {
                         p.Id,
                         Модель = p.ModelCartrige,
                         Артикул = p.ArticleCartrige,
                         Дата_покуки = p.purchase_date
                     };

            dataGridViewListCartrige.DataSource = pr.ToList();
            dataGridViewListCartrige.Columns[0].Width = 45;
        }


        private void ListCartrigeForm_Load(object sender, EventArgs e)
        {
            PrintCartrige();
        }

        private void btnAddCartrige_Click(object sender, EventArgs e)
        {

        }
    }
}
