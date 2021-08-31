
namespace CartrigeAltstar
{
    partial class ListCartrigeForm
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
            this.btnAddCartrige = new System.Windows.Forms.Button();
            this.btnDellCartrige = new System.Windows.Forms.Button();
            this.btnUpdateCartrige = new System.Windows.Forms.Button();
            this.btnExportCartroge = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewListCartrige = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnDellCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdateCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnExportCartroge);
            this.flowLayoutPanel1.Controls.Add(this.btnClosed);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 400);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(713, 30);
            this.flowLayoutPanel1.TabIndex = 31;
            // 
            // btnAddCartrige
            // 
            this.btnAddCartrige.Location = new System.Drawing.Point(3, 3);
            this.btnAddCartrige.Name = "btnAddCartrige";
            this.btnAddCartrige.Size = new System.Drawing.Size(112, 23);
            this.btnAddCartrige.TabIndex = 25;
            this.btnAddCartrige.Text = "Добавить";
            this.btnAddCartrige.UseVisualStyleBackColor = true;
            this.btnAddCartrige.Click += new System.EventHandler(this.btnAddCartrige_Click);
            // 
            // btnDellCartrige
            // 
            this.btnDellCartrige.Location = new System.Drawing.Point(121, 3);
            this.btnDellCartrige.Name = "btnDellCartrige";
            this.btnDellCartrige.Size = new System.Drawing.Size(112, 23);
            this.btnDellCartrige.TabIndex = 26;
            this.btnDellCartrige.Text = "Удалить";
            this.btnDellCartrige.UseVisualStyleBackColor = true;
            this.btnDellCartrige.Click += new System.EventHandler(this.btnDellCartrige_Click);
            // 
            // btnUpdateCartrige
            // 
            this.btnUpdateCartrige.Location = new System.Drawing.Point(239, 3);
            this.btnUpdateCartrige.Name = "btnUpdateCartrige";
            this.btnUpdateCartrige.Size = new System.Drawing.Size(112, 23);
            this.btnUpdateCartrige.TabIndex = 27;
            this.btnUpdateCartrige.Text = "Обновить";
            this.btnUpdateCartrige.UseVisualStyleBackColor = true;
            this.btnUpdateCartrige.Click += new System.EventHandler(this.btnUpdateCartrige_Click);
            // 
            // btnExportCartroge
            // 
            this.btnExportCartroge.Location = new System.Drawing.Point(357, 3);
            this.btnExportCartroge.Name = "btnExportCartroge";
            this.btnExportCartroge.Size = new System.Drawing.Size(112, 23);
            this.btnExportCartroge.TabIndex = 47;
            this.btnExportCartroge.Text = "Export Exel";
            this.btnExportCartroge.UseVisualStyleBackColor = true;
            this.btnExportCartroge.Click += new System.EventHandler(this.btnExportCartroge_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.Location = new System.Drawing.Point(475, 3);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(112, 23);
            this.btnClosed.TabIndex = 28;
            this.btnClosed.Text = "Закрыть";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(593, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 49;
            this.button2.Text = "0";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 50;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(649, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 51;
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(677, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 23);
            this.button4.TabIndex = 52;
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridViewListCartrige
            // 
            this.dataGridViewListCartrige.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListCartrige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListCartrige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListCartrige.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewListCartrige.Name = "dataGridViewListCartrige";
            this.dataGridViewListCartrige.RowHeadersVisible = false;
            this.dataGridViewListCartrige.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewListCartrige.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListCartrige.Size = new System.Drawing.Size(707, 411);
            this.dataGridViewListCartrige.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewListCartrige);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 430);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // ListCartrigeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 430);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListCartrigeForm";
            this.Text = "ListCartrigeForm";
            this.Load += new System.EventHandler(this.ListCartrigeForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddCartrige;
        private System.Windows.Forms.Button btnDellCartrige;
        private System.Windows.Forms.Button btnUpdateCartrige;
        public System.Windows.Forms.Button btnExportCartroge;
        private System.Windows.Forms.Button btnClosed;
        public System.Windows.Forms.DataGridView dataGridViewListCartrige;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}