using CartrigeAltstar.Helpers;
using CartrigeAltstar.Model;
using CartrigeAltstar.Nomenclatura.Cartriges;

using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class ListCartrigeForm : Form
    {

        public ResourceManager resourceManager;
        ContexAltstarContext db;
        public ListCartrigeForm(ResourceManager _resourceManager)
        {
            db = new ContexAltstarContext();
            InitializeComponent();
            resourceManager = _resourceManager;
            this.Text = resourceManager.GetString("ListOfCartrige");
        }


        private void ListCartrigeForm_Load(object sender, EventArgs e) => PrintCartrige();



        public void PrintCartrige()
        {
            var dt = DateTime.Now;
            try
            {
                db.Cartriges.Load();
                var data = db.Cartriges.Local.ToBindingList();

                dataGridViewListCartrige.DataSource = data;

                dataGridViewListCartrige.Columns["ModelCartrige"].HeaderText = resourceManager.GetString("ModelCartrige");
                dataGridViewListCartrige.Columns["ArticleCartrige"].HeaderText = resourceManager.GetString("ArticleCartrige");
                dataGridViewListCartrige.Columns["purchase_date"].HeaderText = resourceManager.GetString("purchase_date");

                dataGridViewListCartrige.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewListCartrige.Font, FontStyle.Bold);



                dataGridViewListCartrige.Columns["Id"].Width = 30;
                dataGridViewListCartrige.Columns["ModelCartrige"].Width = 100;
                dataGridViewListCartrige.Columns["ArticleCartrige"].Width = 100;

                dataGridViewListCartrige.Columns["IsService"].Visible = false;
                dataGridViewListCartrige.Columns["Printers"].Visible = false;
                dataGridViewListCartrige.Columns["Compatibilitys"].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        //Add Cartrige
        private void btnAddCartrige_Click(object sender, EventArgs e)
        {
            AddUpdateCartriges addCartrige = new AddUpdateCartriges(resourceManager, null);
            DialogResult result = addCartrige.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            PrintCartrige();
        }


        //UPDATE Cartrige
        private void btnUpdateCartrige_Click(object sender, EventArgs e)
        {

            // update Cartrige
            if (dataGridViewListCartrige.SelectedRows.Count > 0)
            {
                int index = dataGridViewListCartrige.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dataGridViewListCartrige[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                AddUpdateCartriges updateCartrigeForm = new AddUpdateCartriges(resourceManager, id);
                DialogResult result = updateCartrigeForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;



                db = new ContexAltstarContext();
                PrintCartrige();
            }

        }



        //Delete Cartrige
        private void btnDellCartrige_Click(object sender, EventArgs e)
        {

            // Delete Cartrige
            if (dataGridViewListCartrige.SelectedRows.Count > 0)
            {
                try
                {
                    int index = dataGridViewListCartrige.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = int.TryParse(dataGridViewListCartrige[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;



                    var cartrigeDel = db.Cartriges.Find(id);
                    //find ForeignKey Compatibilitys.CartrigeId and set null
                    var compatability = cartrigeDel.Compatibilitys.FirstOrDefault(x => x.CartrigeId == id);
                    if (compatability != null)
                        compatability.CartrigeId = null;
                    //find ForeignKey Printers.CartrigeId and set null
                    var printers = cartrigeDel.Printers.FirstOrDefault(x => x.CartrigeId.Equals(id));
                    if (printers != null)
                        printers.CartrigeId = null;

                    db.SaveChanges();
                    db.Cartriges.Remove(cartrigeDel);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                db.SaveChanges();
                MessageBox.Show(resourceManager.GetString("CartrigeWasRemoved"));
                PrintCartrige();
            }

        }


        //Export to Exel cartridges
        private void btnExportCartroge_Click(object sender, EventArgs e) => ExelHelper.MyExportExel(dataGridViewListCartrige, true, resourceManager.GetString("ListOfCartrige"));


        private void btnClosed_Click(object sender, EventArgs e) => Close();






    }
}
