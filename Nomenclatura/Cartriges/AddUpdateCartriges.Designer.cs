
namespace CartrigeAltstar.Nomenclatura.Cartriges
{
    partial class AddUpdateCartriges
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDatePurchase = new System.Windows.Forms.Label();
            this.dtpDatetimeCartrige = new System.Windows.Forms.DateTimePicker();
            this.tbArticleCartrige = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.tbModelCartrige = new System.Windows.Forms.TextBox();
            this.lblArticle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 167);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(421, 30);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(212, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Calcel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDatePurchase);
            this.groupBox1.Controls.Add(this.dtpDatetimeCartrige);
            this.groupBox1.Controls.Add(this.tbArticleCartrige);
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Controls.Add(this.tbModelCartrige);
            this.groupBox1.Controls.Add(this.lblArticle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 197);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lblDatePurchase
            // 
            this.lblDatePurchase.AutoSize = true;
            this.lblDatePurchase.Location = new System.Drawing.Point(18, 31);
            this.lblDatePurchase.Name = "lblDatePurchase";
            this.lblDatePurchase.Size = new System.Drawing.Size(135, 13);
            this.lblDatePurchase.TabIndex = 2;
            this.lblDatePurchase.Text = "Дата покупки картриджа";
            // 
            // dtpDatetimeCartrige
            // 
            this.dtpDatetimeCartrige.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatetimeCartrige.Location = new System.Drawing.Point(200, 31);
            this.dtpDatetimeCartrige.Name = "dtpDatetimeCartrige";
            this.dtpDatetimeCartrige.Size = new System.Drawing.Size(215, 20);
            this.dtpDatetimeCartrige.TabIndex = 3;
            // 
            // tbArticleCartrige
            // 
            this.tbArticleCartrige.Location = new System.Drawing.Point(200, 124);
            this.tbArticleCartrige.Name = "tbArticleCartrige";
            this.tbArticleCartrige.Size = new System.Drawing.Size(215, 20);
            this.tbArticleCartrige.TabIndex = 4;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(18, 77);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(104, 13);
            this.lblModel.TabIndex = 5;
            this.lblModel.Text = "Модель картриджа";
            // 
            // tbModelCartrige
            // 
            this.tbModelCartrige.Location = new System.Drawing.Point(200, 77);
            this.tbModelCartrige.Name = "tbModelCartrige";
            this.tbModelCartrige.Size = new System.Drawing.Size(215, 20);
            this.tbModelCartrige.TabIndex = 8;
            // 
            // lblArticle
            // 
            this.lblArticle.AutoSize = true;
            this.lblArticle.Location = new System.Drawing.Point(18, 131);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(49, 13);
            this.lblArticle.TabIndex = 6;
            this.lblArticle.Text = "Артикль";
            // 
            // AddUpdateCartriges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 197);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddUpdateCartriges";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCartriges_FormClosing);
            this.Load += new System.EventHandler(this.AddCartriges_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDatePurchase;
        public System.Windows.Forms.DateTimePicker dtpDatetimeCartrige;
        public System.Windows.Forms.TextBox tbArticleCartrige;
        private System.Windows.Forms.Label lblModel;
        public System.Windows.Forms.TextBox tbModelCartrige;
        private System.Windows.Forms.Label lblArticle;
    }
}