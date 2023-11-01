
namespace CartrigeAltstar
{
    partial class ListSettingPinterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListSettingPinterForm));
            this.dataGridViewListPrinter = new System.Windows.Forms.DataGridView();
            this.toolStripPrinter = new System.Windows.Forms.ToolStrip();
            this.btnAddPrinter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdatePrinter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelPrinter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportExel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClosed = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrinter)).BeginInit();
            this.toolStripPrinter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListPrinter
            // 
            resources.ApplyResources(this.dataGridViewListPrinter, "dataGridViewListPrinter");
            this.dataGridViewListPrinter.MultiSelect = false;
            this.dataGridViewListPrinter.Name = "dataGridViewListPrinter";
            this.dataGridViewListPrinter.ReadOnly = true;
            this.dataGridViewListPrinter.RowHeadersVisible = false;
            this.dataGridViewListPrinter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // toolStripPrinter
            // 
            this.toolStripPrinter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPrinter,
            this.toolStripSeparator3,
            this.btnUpdatePrinter,
            this.toolStripSeparator2,
            this.btnDelPrinter,
            this.toolStripSeparator4,
            this.btnExportExel,
            this.toolStripSeparator1,
            this.btnClosed});
            resources.ApplyResources(this.toolStripPrinter, "toolStripPrinter");
            this.toolStripPrinter.Name = "toolStripPrinter";
            this.toolStripPrinter.Stretch = true;
            // 
            // btnAddPrinter
            // 
            this.btnAddPrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddPrinter.Image = global::CartrigeAltstar.Properties.Resources.Add;
            resources.ApplyResources(this.btnAddPrinter, "btnAddPrinter");
            this.btnAddPrinter.Name = "btnAddPrinter";
            this.btnAddPrinter.Click += new System.EventHandler(this.btnAddPrinter_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // btnUpdatePrinter
            // 
            this.btnUpdatePrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdatePrinter.Image = global::CartrigeAltstar.Properties.Resources.update;
            resources.ApplyResources(this.btnUpdatePrinter, "btnUpdatePrinter");
            this.btnUpdatePrinter.Name = "btnUpdatePrinter";
            this.btnUpdatePrinter.Click += new System.EventHandler(this.btnUpdatePrinter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnDelPrinter
            // 
            this.btnDelPrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelPrinter.Image = global::CartrigeAltstar.Properties.Resources.delete;
            resources.ApplyResources(this.btnDelPrinter, "btnDelPrinter");
            this.btnDelPrinter.Name = "btnDelPrinter";
            this.btnDelPrinter.Click += new System.EventHandler(this.btnDelPrinter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // btnExportExel
            // 
            this.btnExportExel.Image = global::CartrigeAltstar.Properties.Resources.Exel;
            resources.ApplyResources(this.btnExportExel, "btnExportExel");
            this.btnExportExel.Name = "btnExportExel";
            this.btnExportExel.Click += new System.EventHandler(this.btnExportExel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnClosed
            // 
            this.btnClosed.Image = global::CartrigeAltstar.Properties.Resources.Close;
            resources.ApplyResources(this.btnClosed, "btnClosed");
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click_1);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // ListSettingPinterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridViewListPrinter);
            this.Controls.Add(this.toolStripPrinter);
            this.Name = "ListSettingPinterForm";
            this.Load += new System.EventHandler(this.ListSettingPinterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListPrinter)).EndInit();
            this.toolStripPrinter.ResumeLayout(false);
            this.toolStripPrinter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridViewListPrinter;
        private System.Windows.Forms.ToolStrip toolStripPrinter;
        private System.Windows.Forms.ToolStripButton btnAddPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnUpdatePrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDelPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnExportExel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClosed;
        private System.Windows.Forms.Splitter splitter1;
    }
}