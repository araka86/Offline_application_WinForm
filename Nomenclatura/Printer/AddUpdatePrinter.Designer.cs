
namespace CartrigeAltstar
{
    partial class AddUpdatePrinter
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblDatePrinter = new System.Windows.Forms.Label();
            this.dtpDatetimePrinter = new System.Windows.Forms.DateTimePicker();
            this.tbArticlePrinter = new System.Windows.Forms.TextBox();
            this.lblModelPrinter = new System.Windows.Forms.Label();
            this.lblArticlePrinter = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbModelPrinter = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            // lblDatePrinter
            // 
            this.lblDatePrinter.AutoSize = true;
            this.lblDatePrinter.Location = new System.Drawing.Point(18, 31);
            this.lblDatePrinter.Name = "lblDatePrinter";
            this.lblDatePrinter.Size = new System.Drawing.Size(127, 13);
            this.lblDatePrinter.TabIndex = 2;
            this.lblDatePrinter.Text = "Дата покупки принетра";
            // 
            // dtpDatetimePrinter
            // 
            this.dtpDatetimePrinter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatetimePrinter.Location = new System.Drawing.Point(212, 25);
            this.dtpDatetimePrinter.Name = "dtpDatetimePrinter";
            this.dtpDatetimePrinter.Size = new System.Drawing.Size(203, 20);
            this.dtpDatetimePrinter.TabIndex = 3;
            // 
            // tbArticlePrinter
            // 
            this.tbArticlePrinter.Location = new System.Drawing.Point(212, 124);
            this.tbArticlePrinter.Name = "tbArticlePrinter";
            this.tbArticlePrinter.Size = new System.Drawing.Size(203, 20);
            this.tbArticlePrinter.TabIndex = 4;
            // 
            // lblModelPrinter
            // 
            this.lblModelPrinter.AutoSize = true;
            this.lblModelPrinter.Location = new System.Drawing.Point(18, 77);
            this.lblModelPrinter.Name = "lblModelPrinter";
            this.lblModelPrinter.Size = new System.Drawing.Size(96, 13);
            this.lblModelPrinter.TabIndex = 5;
            this.lblModelPrinter.Text = "Модель принтера";
            // 
            // lblArticlePrinter
            // 
            this.lblArticlePrinter.AutoSize = true;
            this.lblArticlePrinter.Location = new System.Drawing.Point(18, 131);
            this.lblArticlePrinter.Name = "lblArticlePrinter";
            this.lblArticlePrinter.Size = new System.Drawing.Size(48, 13);
            this.lblArticlePrinter.TabIndex = 6;
            this.lblArticlePrinter.Text = "Артикул";
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
            // tbModelPrinter
            // 
            this.tbModelPrinter.Location = new System.Drawing.Point(212, 77);
            this.tbModelPrinter.Name = "tbModelPrinter";
            this.tbModelPrinter.Size = new System.Drawing.Size(203, 20);
            this.tbModelPrinter.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDatePrinter);
            this.groupBox1.Controls.Add(this.dtpDatetimePrinter);
            this.groupBox1.Controls.Add(this.tbArticlePrinter);
            this.groupBox1.Controls.Add(this.lblModelPrinter);
            this.groupBox1.Controls.Add(this.tbModelPrinter);
            this.groupBox1.Controls.Add(this.lblArticlePrinter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 197);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 167);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(420, 30);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // AddUpdatePrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(420, 197);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "AddUpdatePrinter";
            this.Text = "AddUpdatePrinter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUpdatePrinter_FormClosing);
            this.Load += new System.EventHandler(this.AddPrinter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDatePrinter;
        private System.Windows.Forms.Label lblModelPrinter;
        private System.Windows.Forms.Label lblArticlePrinter;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DateTimePicker dtpDatetimePrinter;
        public System.Windows.Forms.TextBox tbModelPrinter;
        public System.Windows.Forms.TextBox tbArticlePrinter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}