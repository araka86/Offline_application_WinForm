
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
            this.dataGridViewListCartrige = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnDellCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdateCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnExportCartroge);
            this.flowLayoutPanel1.Controls.Add(this.btnClosed);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 368);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(591, 31);
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
            // dataGridViewListCartrige
            // 
            this.dataGridViewListCartrige.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListCartrige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListCartrige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListCartrige.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewListCartrige.Name = "dataGridViewListCartrige";
            this.dataGridViewListCartrige.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListCartrige.Size = new System.Drawing.Size(591, 399);
            this.dataGridViewListCartrige.TabIndex = 30;
            // 
            // ListCartrigeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 399);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dataGridViewListCartrige);
            this.Name = "ListCartrigeForm";
            this.Text = "ListCartrigeForm";
            this.Load += new System.EventHandler(this.ListCartrigeForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).EndInit();
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
    }
}