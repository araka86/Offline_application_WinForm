
namespace CartrigeAltstar
{
    partial class AddPrinter
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatetime = new System.Windows.Forms.DateTimePicker();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtModelPrinter = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата покупки принетра";
            // 
            // txtDatetime
            // 
            this.txtDatetime.Location = new System.Drawing.Point(200, 25);
            this.txtDatetime.Name = "txtDatetime";
            this.txtDatetime.Size = new System.Drawing.Size(215, 20);
            this.txtDatetime.TabIndex = 3;
            // 
            // txtArticle
            // 
            this.txtArticle.Location = new System.Drawing.Point(200, 124);
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(134, 20);
            this.txtArticle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Модель принтера";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Артикул";
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
            // txtModelPrinter
            // 
            this.txtModelPrinter.Location = new System.Drawing.Point(200, 77);
            this.txtModelPrinter.Name = "txtModelPrinter";
            this.txtModelPrinter.Size = new System.Drawing.Size(134, 20);
            this.txtModelPrinter.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDatetime);
            this.groupBox1.Controls.Add(this.txtArticle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtModelPrinter);
            this.groupBox1.Controls.Add(this.label3);
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
            // AddPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(420, 197);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "AddPrinter";
            this.Text = "AddPrinter";
            this.Load += new System.EventHandler(this.AddPrinter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DateTimePicker txtDatetime;
        public System.Windows.Forms.TextBox txtModelPrinter;
        public System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}