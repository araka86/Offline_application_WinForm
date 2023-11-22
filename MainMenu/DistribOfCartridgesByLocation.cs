using CartrigeAltstar.Model;
using System;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class DistribOfCartridgesByLocation : Form
    {
        private ContexAltstarContext db = new ContexAltstarContext();
        private ResourceManager resourceManager;

        private void DistribOfCartridgesByLocation_Load(object sender, EventArgs e)
        {
            cbDepartment.DataSource = db.Subdivisions.Select(x => x.Department).ToArray();
        }
        public DistribOfCartridgesByLocation(ResourceManager resourceManager)
        {
            InitializeComponent();
            this.resourceManager = resourceManager;
        }

        private void tbSearchCartrigeArticle_TextChanged(object sender, System.EventArgs e)
        {
            string searchText = tbSearchCartrigeArticle.Text; // Получаем текст из текстового поля
            if (!string.IsNullOrEmpty(searchText))
            {

                //var data = db.Cartriges
                //   .Where(x => x.ArticleCartrige.StartsWith(searchText) && x.IsService != true)
                //   .Select(c => new
                //   {
                //       id = c.Id,
                //       Model = c.ModelCartrige,
                //       Article = c.ArticleCartrige
                //   }).ToList();



                //исключить виборку картриджей из сервиса и те которые уже добавлены в подразделения(таблица Tolocation)
                var data = (from cartrige in db.Cartriges
                            where cartrige.ArticleCartrige.StartsWith(searchText)
                                  && cartrige.IsService != true
                                  && !db.Cartrigelolocations.Any(location => location.Article == cartrige.ArticleCartrige)
                            select new
                            {
                                id = cartrige.Id,
                                Model = cartrige.ModelCartrige,
                                Article = cartrige.ArticleCartrige
                            }).ToList();


                if (data.Count > 0)
                {

                    dgvFindArticleResult.DataSource = null;
                    dgvFindArticleResult.DataSource = data;
                }
            }
            else
            {
                dgvFindArticleResult.DataSource = null;
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e) => dgvFindArticleResult_MouseDoubleClick(sender, e as MouseEventArgs);
        private void dgvFindArticleResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dgvFindArticleResult.SelectedRows.Count >0)
            {
                var selectedRow = dgvFindArticleResult.SelectedRows[0];
                tbId.Text = Convert.ToInt32(selectedRow.Cells["id"].Value).ToString();
                tbCaretigeModel.Text = selectedRow.Cells["Model"].Value.ToString();
                tbCartrigeArticle.Text = selectedRow.Cells["Article"].Value.ToString();
            }
        }

        private void okAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = cbDepartment.SelectedItem.ToString();

                Cartrigelolocation tolocation = new Cartrigelolocation()
                {
                    Cartrige = tbCaretigeModel.Text,
                    Article = tbCartrigeArticle.Text,
                    Data = dtpData.Value,
                    Department = cbDepartment.SelectedItem.ToString()
                };



                var chkCartrige = db.Cartrigelolocations.Where(x => x.Article == tbCartrigeArticle.Text).FirstOrDefault();

                if (chkCartrige == null) 
                {
                    db = new ContexAltstarContext();
                    db.Cartrigelolocations.Add(tolocation);
                    db.SaveChanges();
                    MessageBox.Show("Sucessfull!!");
                   
                }
                else 
                {
                    MessageBox.Show("Такой картридж уже на подразделении");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
         

        }

       
        
    }
}
