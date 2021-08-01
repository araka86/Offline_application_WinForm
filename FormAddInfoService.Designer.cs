
namespace CartrigeAltstar
{
    partial class FormAddInfoService
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
            this.okAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LabelData = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.comboBoxCartrige = new System.Windows.Forms.ComboBox();
            this.txtype = new System.Windows.Forms.TextBox();
            this.labelCartrige = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // okAdd
            // 
            this.okAdd.Location = new System.Drawing.Point(28, 275);
            this.okAdd.Name = "okAdd";
            this.okAdd.Size = new System.Drawing.Size(75, 23);
            this.okAdd.TabIndex = 0;
            this.okAdd.Text = "OK";
            this.okAdd.UseVisualStyleBackColor = true;
            this.okAdd.Click += new System.EventHandler(this.okAdd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Calcel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LabelData
            // 
            this.LabelData.AutoSize = true;
            this.LabelData.Location = new System.Drawing.Point(6, 66);
            this.LabelData.Name = "LabelData";
            this.LabelData.Size = new System.Drawing.Size(39, 13);
            this.LabelData.TabIndex = 2;
            this.LabelData.Text = "Число";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(138, 59);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 3;
            // 
            // comboBoxCartrige
            // 
            this.comboBoxCartrige.FormattingEnabled = true;
            this.comboBoxCartrige.Location = new System.Drawing.Point(138, 118);
            this.comboBoxCartrige.Name = "comboBoxCartrige";
            this.comboBoxCartrige.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCartrige.TabIndex = 4;
            this.comboBoxCartrige.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtype
            // 
            this.txtype.Location = new System.Drawing.Point(138, 169);
            this.txtype.Multiline = true;
            this.txtype.Name = "txtype";
            this.txtype.Size = new System.Drawing.Size(284, 80);
            this.txtype.TabIndex = 6;
            // 
            // labelCartrige
            // 
            this.labelCartrige.AutoSize = true;
            this.labelCartrige.Location = new System.Drawing.Point(6, 126);
            this.labelCartrige.Name = "labelCartrige";
            this.labelCartrige.Size = new System.Drawing.Size(57, 13);
            this.labelCartrige.TabIndex = 8;
            this.labelCartrige.Text = "Картридж";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Наименования работ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(506, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 249);
            this.dataGridView1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(403, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(671, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 44);
            this.button4.TabIndex = 14;
            this.button4.Text = "Closed";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormAddInfoService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCartrige);
            this.Controls.Add(this.txtype);
            this.Controls.Add(this.comboBoxCartrige);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.LabelData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okAdd);
            this.Name = "FormAddInfoService";
            this.Text = "FormAddInfoService";
            this.Load += new System.EventHandler(this.FormAddInfoService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LabelData;
        private System.Windows.Forms.Label labelCartrige;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button okAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.ComboBox comboBoxCartrige;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox txtDate;
        public System.Windows.Forms.TextBox txtype;
    }
}