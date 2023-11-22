using CartrigeAltstar.Helpers;
using CartrigeAltstar.MainMenu;
using CartrigeAltstar.Model;
using CartrigeAltstar.Nomenclatura.Cartriges;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class main_Reception : Form
    {
        //false - от
        private static bool ChekMode = false;
        private string CultureDefine;
        private ContexAltstar db;
        public ResourceManager resourceManager;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            db = new ContexAltstar();
            db.Department.Load();
            TranslateMenu();
            FillCombobox();
            FillDataGrid();
            SetOperationAccess();
            var cnt = dgwMain.Rows.Count;
          

        }












        private void SetOperationAccess() 
        {
            tsbDelete.Enabled = (dgwMain.Rows.Count > 0) ? true : false;
            tsbUpdate.Enabled = (dgwMain.Rows.Count > 0) ? true : false;
            tsbExport.Enabled = (dgwMain.Rows.Count > 0) ? true : false;
        } 









        public main_Reception()
        {
            CultureDefine = CultureInfo.CurrentCulture.Name;

            if (CultureDefine == "uk-UA")
            {
                // Создаем новый объект resourceManager, извлекающий из сборки 
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langUA", Assembly.GetExecutingAssembly());
            }
            else if (CultureDefine == "en")
            {
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langEN", Assembly.GetExecutingAssembly());
            }
            else
            {
                resourceManager = new ResourceManager("CartrigeAltstar.Resources.langRU", Assembly.GetExecutingAssembly());
            }

            InitializeComponent();
        }




        private void TranslateMenu()
        {
            tsmiMenu.Text = resourceManager.GetString("tsmiMenu");
            this.Text = resourceManager.GetString("main_Reception");
            tslFilter.Text = resourceManager.GetString("tslFilter");
            tslCartriges.Text = resourceManager.GetString("tslCartriges");
            tslDepartment.Text = resourceManager.GetString("tslDepartment");
            tsbApply.Text = resourceManager.GetString("tsbApply");
            tsbReset.Text = resourceManager.GetString("tsbReset");
            tsbChangeMode.Text = ChekMode ? resourceManager.GetString("tsbChangeModeSend") : resourceManager.GetString("tsbChangeModeArrival");
            tsbChangeMode.ToolTipText = resourceManager.GetString("tsbChangeModeToolTipText");
            tsniPrinters.Text = resourceManager.GetString("tsniPrinters");
            tsmiCartriges.Text = resourceManager.GetString("tslCartriges");
            tsmiDepartment.Text = resourceManager.GetString("tslDepartment");
            tsmenuLanguage.Text = resourceManager.GetString("tsmenuLanguage");
        }




        #region Click Change Language
        private void tsmiUA_Click(object sender, EventArgs e)
        {
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA", true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA", true);
            this.Hide();
            new main_Reception().Show();
        }

        private void tsmiRu_Click(object sender, EventArgs e)
        {
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-UA", true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-UA".ToString(), true);
            this.Hide();
            new main_Reception().Show();
        }

        private void tsmiEn_Click(object sender, EventArgs e)
        {
            // Устанавливаем выбранную культуру в качестве культуры  пользовательского интерфейса 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en", true);
            // Устанавливаем в качестве текущей культуры выбранную
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en", true);
            main_Reception main_Reception = new main_Reception();
            this.Hide();
            new main_Reception().Show();
        }
        #endregion

        #region Admin Edit Nomenclatura

        //Edit Printers
        private void tsniPrinters_Click(object sender, EventArgs e)
        {
            var listSettingPinterForm = new ListSettingPinterForm(resourceManager);
            listSettingPinterForm.Show();
        }
        //Edit Cartriges
        private void tsmiCartriges_Click(object sender, EventArgs e)
        {
            var listCartrigeForm = new ListCartrigeForm(resourceManager);
            listCartrigeForm.Show();
        }
        //Edit Department
        private void tsmiDepartment_Click(object sender, EventArgs e)
        {
            ListSubdivisionForm listSubdivisionForm = new ListSubdivisionForm(resourceManager);
            listSubdivisionForm.Show();
        }
        #endregion


        #region Fill Data

        public void FillCombobox()
        {
            db = new ContexAltstar();
            var ListCartrige = db.Cartriges.Select(c => c.ModelCartrige).ToList();
            tscbCartriges.ComboBox.DataSource = db.Cartriges.Select(c => c.ModelCartrige).Distinct().ToList();
            tscbDepartment.ComboBox.DataSource = db.Department.Select(s => s.Department).ToList();
        }

        private void FillDataGrid()
        {
            try
            {
                db = new ContexAltstar();
                dgwMain.DataSource = db.Cartrigelolocations.Local.ToBindingList();
                dgwMain.Columns["Id"].Width = 35;
                dgwMain.Columns["Data"].Width = 80;
                dgwMain.Columns["Data"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dgwMain.Columns["Article"].Width = 80;
                dgwMain.Columns["Cartrige"].Width = 80;
                dgwMain.Columns["Department"].Width = 300;


                dgwMain.Columns["Status"].Visible = false;
                dgwMain.Columns["Weight"].Visible = false;
                db.Cartrigelolocations.Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        #endregion


        #region Отправка/Прием Сервис

        private void tsmiSendCartrige_Click(object sender, EventArgs e)
        {
            SendingForFilling sendingForFilling = new SendingForFilling(resourceManager, true);
            if (sendingForFilling.ShowDialog() != DialogResult.OK)
                return;
        }

        private void tsmiAcceptCartriges_Click(object sender, EventArgs e)
        {
            var sendingForFilling = new SendingForFilling(resourceManager, false);
            DialogResult result = sendingForFilling.ShowDialog();
            if (result == DialogResult.Cancel) return;
        }
        #endregion

        #region Отправка/Прием Лакации
        private void tsbAdd_Click(object sender, EventArgs e) => tsmiSendToLocation_Click(sender, e);
        private void tsmiSendToLocation_Click(object sender, EventArgs e)
        {
            var distribOfCartridgesByLocation = new DistribOfCartridgesByLocation(resourceManager);
            distribOfCartridgesByLocation.FormClosing += DistribOfCartridgesByLocation_FormClosing;
            distribOfCartridgesByLocation.Show();

        }

        private void DistribOfCartridgesByLocation_FormClosing(object sender, FormClosingEventArgs e) 
        {
            dgwMain.DataSource = db.Cartrigelolocations.ToList();
            SetOperationAccess();
        } 



        private void tsmiAcceptFromLocation_Click(object sender, EventArgs e)
        {
            var acceptСartridgesFromLocations = new AcceptСartridgesFromLocations(resourceManager);
            DialogResult result = acceptСartridgesFromLocations.ShowDialog();
            if (result != DialogResult.OK)
            {
                dgwMain.DataSource = db.Cartrigelolocations.ToList();
                return;
            }
        }
        #endregion



        private void tsUpdateButton_Click(object sender, EventArgs e) => dgwMain.DataSource = db.Cartrigelolocations.ToList();
        private void tsbChangeMode_Click(object sender, EventArgs e)
        {
            tsbChangeMode.Text = ChekMode ? resourceManager.GetString("tsbChangeModeSend") : resourceManager.GetString("tsbChangeModeArrival");
            ChekMode = !ChekMode;
        }

        //export
        private void tsbExport_Click(object sender, EventArgs e) => ExelHelper.MyExportExel(dgwMain, true, resourceManager.GetString("ListOfCartrige"));

        private void tsbApply_Click(object sender, EventArgs e)
        {

        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {



            var uid = this.currentUserId;

            if (dgwMain.SelectedRows.Count > 0)
            {
                var getDatagridrow = dgwMain.SelectedRows[0];
                int idValue = int.Parse(getDatagridrow.Cells["id"].Value.ToString());

                var updateCartrigeLocation = new UpdateCartrigeLocation(idValue);
                if (updateCartrigeLocation.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Item is updated");
                    dgwMain.DataSource = db.Cartrigelolocations.ToList();
                    SetOperationAccess();
                }

                 
            }





        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgwMain.SelectedRows.Count > 0)
                {
                    var getDatagridrow = dgwMain.SelectedRows[0];
                    int idValue = int.Parse(getDatagridrow.Cells["id"].Value.ToString());
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        db.Cartrigelolocations.Remove(db.Cartrigelolocations.Find(idValue));
                        db.SaveChanges();
                        MessageBox.Show("Запись удалена!!!");
                        dgwMain.DataSource = db.Cartrigelolocations.ToList();
                        SetOperationAccess();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private string currentUserId;
     

        // Метод для установки текущего UserId из LoginForm
        public void SetCurrentUserId(string userId)
        {
            currentUserId = userId;
            // Здесь вы можете использовать currentUserId по вашему усмотрению
        }


    }
}
