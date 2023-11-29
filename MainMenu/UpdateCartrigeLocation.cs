using CartrigeAltstar.Model;
using System.Data.Entity;
using System;
using System.Windows.Forms;
using System.Linq;

namespace CartrigeAltstar.MainMenu
{
    public partial class UpdateCartrigeLocation : Form
    {
        private ContexAltstar db;
        private int itemId;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            db = new ContexAltstar();
            db.Departments.Load();
            FillCombobox();
        }

        public UpdateCartrigeLocation(int _itemId)
        {
            InitializeComponent();
            ItemId = _itemId;
            lbId.Text = _itemId.ToString();
        }
        public void FillCombobox()
        {

            try
            {
                var currentUpdate = db.Cartrigelolocations.Find(itemId);
                if (currentUpdate != null)
                {


                    cbUpdateCartrigeArticle.DataSource = db.Cartriges
                    .OrderByDescending(a => a.ArticleCartrige == currentUpdate.Article) // Order by the condition (true comes first)
                    .ThenBy(a => a.ArticleCartrige) // Then order by ArticleCartrige
                    .Select(x => x.ArticleCartrige)
                    .ToList();



                    cbUpdateDupertment.DataSource = db.Departments
                     .OrderByDescending(a => a.Name == currentUpdate.Department)
                     .ThenBy(s => s.Name)
                     .Select(x => x.Name)
                     .ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }







        }

        private void cbUpdateCartrigeArticle_TextChanged(object sender, EventArgs e)
        {
            if (cbUpdateCartrigeArticle != null)
            {

                var getSelectArticle = cbUpdateCartrigeArticle.SelectedItem as string;
                tbCartrige.Text = db.Cartriges
                    .Where(x => x.ArticleCartrige
                    .Equals(getSelectArticle))
                    .Select(x => x.ModelCartrige).FirstOrDefault();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var getCurrent = db.Cartrigelolocations.FirstOrDefault(x => x.Id == ItemId);

                if (getCurrent != null)
                {

                    var checkExistItem = db.Cartrigelolocations.Any(x=>x.Article == cbUpdateCartrigeArticle.SelectedItem.ToString() 
                    && x.Department == cbUpdateDupertment.SelectedItem.ToString() );
                    
                    if (checkExistItem)
                    {
                        MessageBox.Show("Error!! такая запись уже существует ");
                        return;
                    }
                    else
                    {
                        getCurrent.Article = cbUpdateCartrigeArticle.SelectedItem.ToString();
                        getCurrent.Cartrige = tbCartrige.Text.ToString();                
                    }

                    getCurrent.Department = cbUpdateDupertment.SelectedItem.ToString();
                    db.Entry(getCurrent).State = EntityState.Modified;
                    db.SaveChanges();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) =>this.Close();
        
    }
}
