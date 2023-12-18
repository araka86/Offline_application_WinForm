using CartrigeAltstar.Helpers;
using CartrigeAltstar.Model;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class ListSettingPinterForm : Form
    {
 
        public ResourceManager resourceManager;
        ContexAltstar db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_resourceManager">language resource </param>
        public ListSettingPinterForm(ResourceManager _resourceManager)
        {
            InitializeComponent();
            resourceManager = _resourceManager;
            db = new ContexAltstar();
            this.Text = resourceManager.GetString("ListOfPrinrter");


        }
   
        private void ListSettingPinterForm_Load(object sender, EventArgs e) => PrintPrinter();
        private void button1_Click(object sender, EventArgs e) => Close();



        //------------------------Вивод Принтеров----------------------------
        public void PrintPrinter()
        {
            try
            {
                db.Printers.Load();
                var data = db.Printers.Local.ToBindingList();

                dataGridViewListPrinter.DataSource = data;

            
                dataGridViewListPrinter.Columns["Id"].Width = 30;
                dataGridViewListPrinter.Columns["ModelPrinter"].HeaderText = resourceManager.GetString("ModelPrinter");
                dataGridViewListPrinter.Columns["Article"].HeaderText = resourceManager.GetString("Article");
                dataGridViewListPrinter.Columns["DateTimes"].HeaderText = resourceManager.GetString("purchase_date");

                dataGridViewListPrinter.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewListPrinter.Font, FontStyle.Bold);
                
                dataGridViewListPrinter.Columns["Department"].Visible = false;
                dataGridViewListPrinter.Columns["DepartmentId"].Visible = false;
                dataGridViewListPrinter.Columns["CartrigeId"].Visible = false;
                dataGridViewListPrinter.Columns["CartrigePK"].Visible = false;
            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.ToString());
            }
 
        }


        private void btnAddPrinter_Click(object sender, EventArgs e)
        {
            AddUpdatePrinter add = new AddUpdatePrinter(resourceManager, null);

            DialogResult result = add.ShowDialog();
            if (result == DialogResult.Cancel)
                return;


            PrintPrinter();
        }

        private void btnUpdatePrinter_Click(object sender, EventArgs e)
        {
            try
            {
                // update Cartrige
                if (dataGridViewListPrinter.SelectedRows.Count > 0)
                {
                    int index = dataGridViewListPrinter.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = int.TryParse(dataGridViewListPrinter[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    AddUpdatePrinter updatePrinerForm = new AddUpdatePrinter(resourceManager, id);
                    DialogResult result = updatePrinerForm.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                        return;


                    db = new ContexAltstar();
                    PrintPrinter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

        }



        // Delete Printer
        private void btnDelPrinter_Click(object sender, EventArgs e)
        {


            try
            {
                if (dataGridViewListPrinter.SelectedRows.Count > 0)
                {
                    int findId = int.Parse(dataGridViewListPrinter.SelectedRows[0].Cells["id"].Value.ToString());
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        db.Printers.Remove(db.Printers.Find(findId));
                        db.SaveChanges();
                        MessageBox.Show(resourceManager.GetString("MessageRemovePrinter"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        //Export to Exel
        private void btnExportExel_Click(object sender, EventArgs e) => ExelHelper.MyExportExel(dataGridViewListPrinter, true, resourceManager.GetString("ListOfPrinrter"));

        private void btnClosed_Click_1(object sender, EventArgs e) => Close();

    
    }
}
