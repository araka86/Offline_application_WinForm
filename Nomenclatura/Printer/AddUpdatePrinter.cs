using CartrigeAltstar.Model;
using System;
using System.Data.Entity;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class AddUpdatePrinter : Form
    {

        private ResourceManager resourceManager;
        ContexAltstar db;
        private readonly int? id;
        private Printer PrinterModel;

        public AddUpdatePrinter(ResourceManager _resourceManager, int? _id)
        {
            InitializeComponent();
            db = new ContexAltstar();
            resourceManager = _resourceManager;
            id = _id;
        }

        private void AddPrinter_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                PrinterModel = db.Printers.Find(id);
                dtpDatetimePrinter.Text = PrinterModel.DateTimes.ToString();
                tbModelPrinter.Text = PrinterModel.ModelPrinter;
                tbArticlePrinter.Text = PrinterModel.Article;
            }

            this.Text = id == null ? resourceManager.GetString("AddPrinterModal") : resourceManager.GetString("UpdatePrinterModal");

            lblArticlePrinter.Text = resourceManager.GetString("Article");
            lblModelPrinter.Text = resourceManager.GetString("Model");
            lblDatePrinter.Text = resourceManager.GetString("Data");

        }


        private void AddUpdatePrinter_FormClosing(object sender, FormClosingEventArgs e) => 
            e.Cancel = (DialogResult == DialogResult.OK) && (id == null ? !SaveData() : !UpdateData());




        private bool SaveData()
        {

            try
            {

                //Check
                if (!string.IsNullOrEmpty(tbArticlePrinter.Text) && !string.IsNullOrEmpty(tbArticlePrinter.Text))
                {
                    PrinterModel = new Printer();
                    PrinterModel.DateTimes = dtpDatetimePrinter.Value;
                    PrinterModel.ModelPrinter = tbModelPrinter.Text;
                    PrinterModel.Article = tbArticlePrinter.Text;
                    db.Printers.Add(PrinterModel);
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("AddNewPrinterMsgBox"));
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
                if (!string.IsNullOrEmpty(tbArticlePrinter.Text) && !string.IsNullOrEmpty(tbArticlePrinter.Text))
                {
                    PrinterModel.DateTimes = dtpDatetimePrinter.Value;
                    PrinterModel.ModelPrinter = tbModelPrinter.Text;
                    PrinterModel.Article = tbArticlePrinter.Text;
                    db.Entry(PrinterModel).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show(resourceManager.GetString("MessageUpdatePrinter"));
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
