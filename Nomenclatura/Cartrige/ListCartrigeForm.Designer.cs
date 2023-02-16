
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCartrigeForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCartrige = new System.Windows.Forms.Button();
            this.btnDellCartrige = new System.Windows.Forms.Button();
            this.btnUpdateCartrige = new System.Windows.Forms.Button();
            this.btnExportCartroge = new System.Windows.Forms.Button();
            this.btnClosed = new System.Windows.Forms.Button();
            this.dataGridViewListCartrige = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.btnAddCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnDellCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdateCartrige);
            this.flowLayoutPanel1.Controls.Add(this.btnExportCartroge);
            this.flowLayoutPanel1.Controls.Add(this.btnClosed);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnAddCartrige
            // 
            resources.ApplyResources(this.btnAddCartrige, "btnAddCartrige");
            this.btnAddCartrige.Name = "btnAddCartrige";
            this.btnAddCartrige.UseVisualStyleBackColor = true;
            this.btnAddCartrige.Click += new System.EventHandler(this.btnAddCartrige_Click);
            // 
            // btnDellCartrige
            // 
            resources.ApplyResources(this.btnDellCartrige, "btnDellCartrige");
            this.btnDellCartrige.Name = "btnDellCartrige";
            this.btnDellCartrige.UseVisualStyleBackColor = true;
            this.btnDellCartrige.Click += new System.EventHandler(this.btnDellCartrige_Click);
            // 
            // btnUpdateCartrige
            // 
            resources.ApplyResources(this.btnUpdateCartrige, "btnUpdateCartrige");
            this.btnUpdateCartrige.Name = "btnUpdateCartrige";
            this.btnUpdateCartrige.UseVisualStyleBackColor = true;
            this.btnUpdateCartrige.Click += new System.EventHandler(this.btnUpdateCartrige_Click);
            // 
            // btnExportCartroge
            // 
            resources.ApplyResources(this.btnExportCartroge, "btnExportCartroge");
            this.btnExportCartroge.Name = "btnExportCartroge";
            this.btnExportCartroge.UseVisualStyleBackColor = true;
            this.btnExportCartroge.Click += new System.EventHandler(this.btnExportCartroge_Click);
            // 
            // btnClosed
            // 
            resources.ApplyResources(this.btnClosed, "btnClosed");
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // dataGridViewListCartrige
            // 
            resources.ApplyResources(this.dataGridViewListCartrige, "dataGridViewListCartrige");
            this.dataGridViewListCartrige.AllowUserToDeleteRows = false;
            this.dataGridViewListCartrige.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListCartrige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListCartrige.Name = "dataGridViewListCartrige";
            this.dataGridViewListCartrige.RowHeadersVisible = false;
            this.dataGridViewListCartrige.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.dataGridViewListCartrige);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ListCartrigeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListCartrigeForm";
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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}