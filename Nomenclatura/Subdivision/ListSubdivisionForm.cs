using CartrigeAltstar.Helpers;
using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{

    public partial class ListSubdivisionForm : Form
    {

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PrintDepartment();
        }

        ContexAltstar db;
        public ResourceManager resourceManager;

        public ListSubdivisionForm(ResourceManager _resourceManager)
        {
            this.resourceManager = _resourceManager;
            InitializeComponent();
            db = new ContexAltstar();
            db.Departments.Load();
            this.Text = resourceManager.GetString("ListOfDepartment");
        }

        public void PrintDepartment()
        {
            var dt = DateTime.Now;
            try
            {
                db.Departments.Load();
                var data = db.Departments.Local.ToBindingList();

                dataGridViewListSubdivision.DataSource = data;

               dataGridViewListSubdivision.Columns["Name"].HeaderText = resourceManager.GetString("Department");
                dataGridViewListSubdivision.Columns["Address"].HeaderText = resourceManager.GetString("Address");

                dataGridViewListSubdivision.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewListSubdivision.Font, FontStyle.Bold);

                dataGridViewListSubdivision.Columns["Id"].Width = 30;
                dataGridViewListSubdivision.Columns["Name"].Width = 300;
                dataGridViewListSubdivision.Columns["Address"].Width = 350;

                dataGridViewListSubdivision.Columns["Printers"].Visible = false;
                dataGridViewListSubdivision.Columns["Compatibilities"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Add
        private void btnAddDepartment_Click(object sender, EventArgs e)
        {

            AddUpdateSubdivision addCartrige = new AddUpdateSubdivision(resourceManager, null);
            DialogResult result = addCartrige.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            PrintDepartment();
        }

        //Update
        private void btnUpdateDepartment_Click(object sender, EventArgs e)
        {

            // update Cartrige
            if (dataGridViewListSubdivision.SelectedRows.Count > 0)
            {
                int index = dataGridViewListSubdivision.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dataGridViewListSubdivision[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                AddUpdateSubdivision updateCartrigeForm = new AddUpdateSubdivision(resourceManager, id);
                DialogResult result = updateCartrigeForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;


                db = new ContexAltstar();
                PrintDepartment();
            }

        }

        //Delete
        private void btnDellDepartment_Click(object sender, EventArgs e)
        {

            // Delete Cartrige
            if (dataGridViewListSubdivision.SelectedRows.Count > 0)
            {

                try
                {
                    int department = dataGridViewListSubdivision.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = int.TryParse(dataGridViewListSubdivision[0, department].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    Department depertmentDel = db.Departments.Find(id);
                    //find ForeignKey Printer.SubdivisionId and set null
                    var printer = depertmentDel.Printers.FirstOrDefault(p=>p.DepartmentId == id);
                    if (printer != null)
                        printer.DepartmentId = null;

                    //find ForeignKey Printer.SubdivisionId and set null
                    var compatibilities = depertmentDel.Compatibilities.FirstOrDefault(c=>c.DepartmentId == id);
                        if(compatibilities != null)
                            compatibilities.DepartmentId = null;

                        db.SaveChanges();
                        db.Departments.Remove(depertmentDel);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                db.SaveChanges();
                MessageBox.Show(resourceManager.GetString("DepartmentWasRemoved"));
                PrintDepartment();
            }
        }

        //export
        private void btnExportExel_Click(object sender, EventArgs e) => ExelHelper.MyExportExel(dataGridViewListSubdivision, true, resourceManager.GetString("ListOfDepartment"));
        private void btnClosed_Click(object sender, EventArgs e) =>this.Close();
        
    }
}
