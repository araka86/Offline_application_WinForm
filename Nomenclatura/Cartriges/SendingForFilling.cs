using CartrigeAltstar.Model;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CartrigeAltstar.Nomenclatura.Cartriges
{
    public partial class SendingForFilling : Form
    {
        private ContexAltstar db = new ContexAltstar();
        private ResourceManager resourceManager;
        private void SendingForFilling_Load(object sender, EventArgs e) => db.Cartriges.Load();


        //menu sending or not sending
        public bool isSending { get; set; }

        // cartrige is on service or is not service
        public bool IsService { get; set; }


        public SendingForFilling(ResourceManager _resourceManager,bool menuisSending)
        {
            InitializeComponent();
            resourceManager = _resourceManager;
            isSending = menuisSending;

            ChangeLangMenu();
        }

        private void ChangeLangMenu()
        {

            lblSearchArticle.Text = resourceManager.GetString("lblSearchArticle");
            lblStatus.Text = resourceManager.GetString("lblStatus");
            btnShowIsServiceCartriges.Text = resourceManager.GetString("ShowButton");
            btnClearServiceCartriges.Text = resourceManager.GetString("ClearBtn");




            this.Text = (isSending) ? resourceManager.GetString("sendingToService") : resourceManager.GetString("ReceivingFromService");
            tsbAcceptCrtige.Text = (isSending) ? resourceManager.GetString("btnReceivingFromService") : resourceManager.GetString("btnsendingToService");
            if(isSending) {
                labelCartrigeInfoAboveTheGrid.Text = resourceManager.GetString("labelInfoGridInService");
                labelCartrigeInfoAboveTheGrid.ForeColor = Color.Red;

                tsbSendtoFillCartrige.Text = resourceManager.GetString("tsbSendtoFillCartrige");
            }
            else {
                labelCartrigeInfoAboveTheGrid.Text = resourceManager.GetString("labelInfoGridNotInService");
                labelCartrigeInfoAboveTheGrid.ForeColor = Color.Green;

                tsbSendtoFillCartrige.Text = resourceManager.GetString("tsbReturnFillCartrige");

            }
            
        }
        

        private void tbSearchCartrigeArticle_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchCartrigeArticle.Text; // Получаем текст из текстового поля
            if (!string.IsNullOrEmpty(searchText))
            {
             //  db = new ContexAltstar();
                var data = db.Cartriges
                   .Where(x => x.ArticleCartrige.StartsWith(searchText))
                   .Select(c => new
                   {
                       id = c.Id,
                       Model = c.ModelCartrige,
                       Article = c.ArticleCartrige
                   }).ToList();

                if (data.Count > 0)
                {
                    listBoxFindArticleResult.Items.Clear();
                    listBoxFindArticleResult.Items.AddRange(data.ToArray());
                    listBoxFindArticleResult.SelectedIndex = 0;
                }
            }
            else
            {
                listBoxFindArticleResult.Items.Clear();
            }

        }






        private void lbFindArticleResult_MouseClick(object sender, MouseEventArgs e) => lbFindArticleResult_SelectedIndexChanged(sender, e);
        private void lbFindArticleResult_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (listBoxFindArticleResult.SelectedItems.Count > 0)
                {


                    var ID = GetIdFromData(listBoxFindArticleResult.SelectedItem.ToString());
                    if (ID != null)
                    {
                        var result = db.Cartriges.Where(x => x.Id == ID && x.IsService == true).FirstOrDefault(); //находим кртрилж в сервисе


                        if (isSending) //эсли меню для отправки НА сервис
                        {
                            if (result == null)//эсли в сервисе не найден
                            {
                                lblStatusInfo.Text = resourceManager.GetString("txStatusSendCartrigeNoOK");
                                lblStatusInfo.ForeColor = Color.Green;
                                lblStatusInfo.Font = new Font(lblStatusInfo.Font.FontFamily, 16);
                                IsService = false; //для разрешения добвления в меню пред отправкой
                            }
                            else
                            {
                                lblStatusInfo.Text = resourceManager.GetString("txStatusSendCartrigeOK");
                                lblStatusInfo.ForeColor = Color.Red;
                                lblStatusInfo.Font = new Font(lblStatusInfo.Font.FontFamily, 16);
                                IsService = true; //для запрета добвления в меню пред отправкой
                            }
                        }
                        else //эсли меню для получение ИЗ сервиса
                        {
                            if (result == null)//эсли в сервисе не найден
                            {
                                lblStatusInfo.Text = resourceManager.GetString("txStatusSendCartrigeNoOKReceive");
                                lblStatusInfo.ForeColor = Color.Red;
                                lblStatusInfo.Font = new Font(lblStatusInfo.Font.FontFamily, 16);
                                IsService = true; //для разрешения добвления в меню пред отправкой
                            }
                            else//эсли в сервисе НАЙДЕН
                            {
                                lblStatusInfo.Text = resourceManager.GetString("txStatusSendCartrigeOKReceive");
                                lblStatusInfo.ForeColor = Color.Green;
                                lblStatusInfo.Font = new Font(lblStatusInfo.Font.FontFamily, 16);
                                IsService = false; //для запрета добвления в меню пред отправкой
                            }



                        }


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
  

        }


        private void lbFindArticleResult_MouseDoubleClick(object sender, MouseEventArgs e) => tsbDown_Click(sender, e);

        private void tsbDown_Click(object sender, EventArgs e)
        {
            if (listBoxFindArticleResult != null)
            {
                if (isSending) 
                {
                    if (IsService)  //проверка, на сервисе ли картридж, в случае true - запретить
                    {
                        MessageBox.Show("Картридж не может бы добавлен т.к на сервисе!!!!"); return;
                    }
                }
                else 
                {
                    if (IsService)  //проверка, на сервисе ли картридж, в случае true - запретить
                    {
                        MessageBox.Show("Картридж не может быть получен из сервиса, т.к его там нет!!!!"); return;
                    }

                }

               

                if (listBoxFindArticleResult.SelectedItem != null)
                {

                    if (!listBoxForSend.Items.Contains(listBoxFindArticleResult.SelectedItem))
                    {
                        listBoxForSend.Items.Add(listBoxFindArticleResult.SelectedItem);
                     
                    }
                    else
                    {
                        MessageBox.Show("Такая запись уже существует");
                    }
                    ChekValueSendingGrid();
                }
            }
        }
     
        //проверка активности кнопки
        public void ChekValueSendingGrid()=> tsbSendtoFillCartrige.Enabled = listBoxForSend.Items.Count > 0 ? true : false;
        

        // id = 5, Model = "22222", Article = "22222"
        private void lbForSend_MouseDoubleClick(object sender, MouseEventArgs e) => tsbUp_Click(sender, e);
        private void tsbUp_Click(object sender, EventArgs e)
        {
            if (listBoxForSend != null && listBoxForSend.SelectedItem != null)
                listBoxForSend.Items.Remove(listBoxForSend.SelectedItem);

            ChekValueSendingGrid();
        }

        private int? GetIdFromData(string data)
        {
            int startIndex = data.IndexOf("id = ") + "id = ".Length;

            if (startIndex != -1)
            {
                int endIndex = data.IndexOfAny(new char[] { ',', ' ', '\r', '\n', '\t', '\v' }, startIndex);

                if (endIndex == -1)
                {
                    endIndex = data.Length;
                }
                string idPart = data.Substring(startIndex, endIndex - startIndex).Trim();
                if (int.TryParse(idPart, out int id))
                {
                    return id;
                }
            }

            return -1; // Возврат -1 в случае ошибки или неверных данных
        }

        private void tsbSend_Click(object sender, EventArgs e)
        {
            try
            {
                db = new ContexAltstar();
                var cartptiges = new List<Cartrige>(); // Создаем новую коллекцию для объектов Cartrige

                if (listBoxForSend != null)
                {
                    foreach (var item in listBoxForSend.Items)
                    {
                        var data = item.ToString();
                        int? id = GetIdFromData(data);

                        if (id != -1)
                        {
                            Cartrige cartrige = db.Cartriges.Where(x => x.Id == id).FirstOrDefault();
                            if (cartrige != null)
                            {
                                cartrige.IsService = (isSending)?true:false;
                                db.Entry(cartrige).State = EntityState.Modified;
                            }
                        }
                    }

                    db.SaveChanges();
                    MessageBox.Show("Операция успешна!!!");
                    listBoxForSend.Items.Clear();
                    ChekValueSendingGrid();                 //проверка активности кнопки отрпавки/получения

                }
                else
                {
                    // Обработка, если список пуст
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnShowIsServiceCartriges_Click(object sender, EventArgs e)
        {


            try
            {
                db.Cartriges.Load();
                if (isSending) 
                {
                    dgShowIsServiceCartriges.DataSource = db.Cartriges.Local.Where(x => x.IsService == true).ToList();
                }
                else 
                {
                    dgShowIsServiceCartriges.DataSource = db.Cartriges.Local.Where(x => x.IsService == false).ToList();
                }

               
                dgShowIsServiceCartriges.Columns["ModelCartrige"].HeaderText = resourceManager.GetString("ModelCartrige");
                dgShowIsServiceCartriges.Columns["ArticleCartrige"].HeaderText = resourceManager.GetString("ArticleCartrige");


                dgShowIsServiceCartriges.ColumnHeadersDefaultCellStyle.Font = new Font(dgShowIsServiceCartriges.Font, FontStyle.Bold);


                dgShowIsServiceCartriges.Columns["Id"].Width = 30;
                dgShowIsServiceCartriges.Columns["ModelCartrige"].Width = 100;
                dgShowIsServiceCartriges.Columns["ArticleCartrige"].Width = 100;

                dgShowIsServiceCartriges.Columns["purchase_date"].Visible = false;
                dgShowIsServiceCartriges.Columns["IsService"].Visible = false;
                dgShowIsServiceCartriges.Columns["Printers"].Visible = false;
                dgShowIsServiceCartriges.Columns["Compatibilitys"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }

        private void btnClearServiceCartriges_Click(object sender, EventArgs e) => dgShowIsServiceCartriges.DataSource = null;

        private void tsbAcceptCrtige_Click(object sender, EventArgs e)
        {
            if (isSending) 
            {
                this.Hide();
                new SendingForFilling(resourceManager, false).ShowDialog();
            }
            else 
            {
                this.Hide();
                new SendingForFilling(resourceManager, true).ShowDialog();
            }
           
           
        }
    }
}
