using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Resources;

using System.Windows.Forms;

namespace CartrigeAltstar.Nomenclatura.Cartriges
{
    public partial class AddUpdateCartriges : Form
    {

        private ResourceManager resourceManager;
        ContexAltstarContext db;

        
        private readonly int? id;
        private Cartrige CartrigeModel;
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_resourceManager">языковая среда</param>
        /// <param name="_id">присутствие  id означает что картридж будет обновлен </param>
        public AddUpdateCartriges(ResourceManager _resourceManager,int? _id)
        {
            InitializeComponent();
            db = new ContexAltstarContext();
            resourceManager = _resourceManager;
            
            id = _id;
        }
        private void AddCartriges_Load(object sender, System.EventArgs e)
        {
            if (id != null) 
            {
                CartrigeModel = db.Cartriges.Find(id);
                dtpDatetimeCartrige.Text = CartrigeModel.purchase_date.ToString();
                tbModelCartrige.Text = CartrigeModel.ModelCartrige;
                tbArticleCartrige.Text = CartrigeModel.ArticleCartrige;
            }
            
            this.Text = id == null ? resourceManager.GetString("AddCartigeModal") : resourceManager.GetString("UpdateCartigeModal");
            lblArticle.Text = resourceManager.GetString("lblArticle");
            lblModel.Text = resourceManager.GetString("lblModel");
            lblDatePurchase.Text = resourceManager.GetString("lblDatePurchase");
        }

        private void AddCartriges_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(id==null) 
            {
                if (this.DialogResult == DialogResult.OK)
                    e.Cancel = !this.SaveData();
            }
            else 
            {
                if (this.DialogResult == DialogResult.OK)
                    e.Cancel = !this.UpdateData();
            }
        }

        private bool SaveData() 
        {

            try
            {

                //Check
                if (!string.IsNullOrEmpty(tbArticleCartrige.Text) && !string.IsNullOrEmpty(tbArticleCartrige.Text))
                {
                    CartrigeModel = new Cartrige();
                    CartrigeModel.purchase_date = dtpDatetimeCartrige.Value;
                    CartrigeModel.ModelCartrige = tbModelCartrige.Text;
                    CartrigeModel.ArticleCartrige = tbArticleCartrige.Text;
                    db.Cartriges.Add(CartrigeModel);
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("AddNewCartrigeMsgBox"));
                }
                else
                {
                    MessageBox.Show(resourceManager.GetString("ChekFieldMessage"));
                    return false;
                }

            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return true;
        } 

        private bool UpdateData() 
        {
            try
            {
                if (!string.IsNullOrEmpty(tbArticleCartrige.Text) && !string.IsNullOrEmpty(tbArticleCartrige.Text))
                {
                    CartrigeModel.purchase_date = dtpDatetimeCartrige.Value;
                    CartrigeModel.ModelCartrige = tbModelCartrige.Text;
                    CartrigeModel.ArticleCartrige = tbArticleCartrige.Text;
                    db.Entry(CartrigeModel).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("ChekFieldMessageUpdate"));
                }
                else 
                {
                    MessageBox.Show(resourceManager.GetString("ChekFieldMessage"));
                    return false;
                } 

            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }       
            return true;

        }


    }
}
