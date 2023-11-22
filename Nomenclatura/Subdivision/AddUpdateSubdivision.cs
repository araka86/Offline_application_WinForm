using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class AddUpdateSubdivision : Form
    {
        private ResourceManager resourceManager;
        ContexAltstar db;
        private readonly int? id;
        private  Department SubdivisionModel;




        public AddUpdateSubdivision(ResourceManager _resourceManager, int? _id)
        {
            InitializeComponent();
            db = new ContexAltstar();
            resourceManager = _resourceManager;
            id = _id;
        }

        private void AddSubdivision_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                SubdivisionModel = db.Departments.Find(id);
                tbNameDepartment.Text = SubdivisionModel.Name.ToString();
                tbAddessDepartment.Text = SubdivisionModel.Address.ToString();

            }

            this.Text = id == null ? resourceManager.GetString("AddDepartmentModal") : resourceManager.GetString("UpdateDepartmentModal");
            lblNameDepartment.Text = resourceManager.GetString("lblNameDepartment");
            lblAddressDepartment.Text = resourceManager.GetString("lblAddressDepartment");
           

        }

        private void AddUpdateSubdivision_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (id == null)
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
                if (!string.IsNullOrEmpty(tbNameDepartment.Text) && !string.IsNullOrEmpty(tbAddessDepartment.Text))
                {
                    SubdivisionModel = new Department();
                    SubdivisionModel.Name = tbNameDepartment.Text;
                    SubdivisionModel.Address = tbAddessDepartment.Text;
                    db.Departments.Add(SubdivisionModel);
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("AddNewDepartmenMsgBox"));
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
                if (!string.IsNullOrEmpty(tbNameDepartment.Text) && !string.IsNullOrEmpty(tbAddessDepartment.Text))
                {
                   
                    SubdivisionModel.Name = tbNameDepartment.Text;
                    SubdivisionModel.Address = tbAddessDepartment.Text;
                    db.Entry(SubdivisionModel).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("ChekFieldMessageUpdateDepartment"));
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
