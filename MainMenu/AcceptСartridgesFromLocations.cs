using CartrigeAltstar.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    public partial class AcceptСartridgesFromLocations : Form
    {
        private ContexAltstar db = new ContexAltstar();
        public ResourceManager resourceManager;
        private DataTable dataTable = new DataTable();



        private void AcceptСartridgesFromLocations_Load(object sender, EventArgs e)
        {
            this.Text = resourceManager.GetString("tsmiAcceptFromLocation");
            gbReceivingCartridges.Text = resourceManager.GetString("tsmiAcceptFromLocation");
            datalabel.Text = resourceManager.GetString("Data");
            gbSearchArtileCartrige.Text = resourceManager.GetString("SearchArticle");
        }
        public AcceptСartridgesFromLocations(ResourceManager resourceManager)
        {
            InitializeComponent();
            this.resourceManager = resourceManager;
        }

        private void tbSearchCartrigeArticle_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchCartrigeArticle.Text; // Получаем текст из текстового поля
            if (!string.IsNullOrEmpty(searchText))
            {
                //исключить виборку картриджей из сервиса и те которые уже добавлены в подразделения(таблица Tolocation)
                var data = (from cartrige in db.Cartriges
                            where cartrige.ArticleCartrige.StartsWith(searchText)
                                  && cartrige.IsService != true
                                  && db.Cartrigelolocations.Any(location => location.Article == cartrige.ArticleCartrige)
                            select new
                            {
                                id = cartrige.Id,
                                Model = cartrige.ModelCartrige,
                                Article = cartrige.ArticleCartrige
                            }).ToList();

                if (data.Count > 0)
                {

                    dgvFindArticleResulttoLocations.DataSource = null;
                    dgvFindArticleResulttoLocations.DataSource = data;
                    dgvFindArticleResulttoLocations.Columns["Id"].Width = 30;


                }

            }
            else 
            {
                dgvFindArticleResulttoLocations.DataSource = null;
            }
        }









        private void tsbRight_Click(object sender, EventArgs e) => dgvFindArticleResulttoLocations_DoubleClick(sender, e);
        

        private void dgvFindArticleResulttoLocations_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFindArticleResulttoLocations.SelectedRows.Count > 0)
            {
                string getArticle = dgvFindArticleResulttoLocations.SelectedRows[0].Cells["Article"].Value.ToString();
                Cartrigelolocation data = db.Cartrigelolocations.Where(x => x.Article == getArticle).FirstOrDefault();

                // Если столбцы отсутствуют, добавляем их
                if (dataTable.Columns.Count == 0)
                {
                    foreach (var prop in data.GetType().GetProperties())
                    {
                        Type propType = prop.PropertyType;

                        // Если свойство имеет тип System.Nullable<>, используем базовый тип
                        if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            propType = Nullable.GetUnderlyingType(propType);
                        }

                        dataTable.Columns.Add(prop.Name, propType);
                    }
                }

                // Создаем новую строку в DataTable и заполняем ее данными из объекта data
                DataRow newRow = dataTable.NewRow();
                foreach (var prop in data.GetType().GetProperties())
                {
                    object propValue = prop.GetValue(data);
                    newRow[prop.Name] = propValue ?? DBNull.Value;
                }

                // Проверяем, есть ли строка с таким Article в DataTable, прежде чем добавить
                if (dataTable.Select($"Article = '{getArticle}'").Length == 0)
                {
                    dataTable.Rows.Add(newRow);
                }

                // Устанавливаем DataTable как источник данных для DataGridView
                dgvAcceptFromLocations.DataSource = dataTable;

                dgvAcceptFromLocations.Columns["Id"].Width = 30;
                dgvAcceptFromLocations.Columns["Department"].Width = 240;
                dgvAcceptFromLocations.Columns["Weight"].Visible = false;
                dgvAcceptFromLocations.Columns["Status"].Visible = false;

                if (dgvAcceptFromLocations.Rows.Count>0)
                    tsbOk.Enabled = true;
            }

        }
        private void tsbLeft_Click(object sender, EventArgs e) => dgvAcceptFromLocations_MouseDoubleClick(sender, e as MouseEventArgs);

        private void dgvAcceptFromLocations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvAcceptFromLocations.SelectedRows.Count > 0)
            {
                dgvAcceptFromLocations.Rows.Remove(dgvAcceptFromLocations.SelectedRows[0] as DataGridViewRow);
                if (dgvAcceptFromLocations.SelectedRows.Count > 0)
                    tsbOk.Enabled = false;
            }
        }

        //private void tsbOk_Click(object sender, EventArgs e)
        //{
        //    var data = 


        //    var data = db.Cartrigelolocations.Find(2);

        //        db.Cartrigelolocations.Remove(data);
        //        db.SaveChanges();

        //}
        private void tsbOk_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли выбранные строки в DataGridView
            if (dgvAcceptFromLocations.SelectedRows.Count > 0)
            {
                // Создаем список для хранения ID выбранных строк
                List<int> selectedIds = new List<int>();

                // Получение значений ID из выбранных строк
                foreach (DataGridViewRow selectedRow in dgvAcceptFromLocations.Rows)
                {
                    int selectedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                    selectedIds.Add(selectedId);
                }

                // Находим соответствующие записи в базе данных и удаляем их
                var toDeleteList = db.Cartrigelolocations.Where(x => selectedIds.Contains(x.Id)).ToList();

                if (toDeleteList.Any())
                {
                    db.Cartrigelolocations.RemoveRange(toDeleteList);
                    db.SaveChanges();

                    dgvAcceptFromLocations.DataSource = null;
                    MessageBox.Show("Картрилджи перемещені на склад!!!");
                    this.Close();
                }
                else
                {
                    // Обработка случая, если записи не найдены
                    MessageBox.Show("Выбранные записи не найдены в базе данных.", "Ошибка");
                }
            }
            else
            {
                // Обработка случая, если нет выбранных строк в DataGridView
                MessageBox.Show("Выберите строки для удаления.", "Предупреждение");
            }
        }

     
    }
}
