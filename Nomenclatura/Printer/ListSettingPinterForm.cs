using CartrigeAltstar.Helpers;
using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class ListSettingPinterForm : Form
    {
 
        public ResourceManager resourceManager;
        ContexAltstarContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_resourceManager">language resource </param>
        public ListSettingPinterForm(ResourceManager _resourceManager)
        {
            InitializeComponent();
            resourceManager = _resourceManager;
            db = new ContexAltstarContext();
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

                dataGridViewListPrinter.Columns["SubdivisionId"].Visible = false;
                dataGridViewListPrinter.Columns["CartrigeId"].Visible = false;
                dataGridViewListPrinter.Columns["CartrigePK"].Visible = false;
                dataGridViewListPrinter.Columns["SubdivisioPK"].Visible = false;
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



                db = new ContexAltstarContext();
                PrintPrinter();
            }

        }




        private void btnDelPrinter_Click(object sender, EventArgs e)
        {
            // Delete Printer
            if (dataGridViewListPrinter.SelectedRows.Count > 0)
            {
                int index = dataGridViewListPrinter.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dataGridViewListPrinter[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Printer printerdel = db.Printers.Find(id);
                db.Printers.Remove(printerdel);
                db.SaveChanges();


                MessageBox.Show(resourceManager.GetString("CartrigeWasRemoved"));
                PrintPrinter();

            }
        }



        //Export to Exel
        private void btnExportExel_Click(object sender, EventArgs e) => ExelHelper.MyExportExel(dataGridViewListPrinter, true, resourceManager.GetString("ListOfPrinrter"));

        private void btnClosed_Click_1(object sender, EventArgs e) => Close();

    }
}
