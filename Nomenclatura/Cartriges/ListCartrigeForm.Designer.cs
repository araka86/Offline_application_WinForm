
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
            this.dataGridViewListCartrige = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddCartrige = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateCartrige = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDellCartrige = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportExel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClosed = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewListCartrige
            // 
            this.dataGridViewListCartrige.AllowUserToDeleteRows = false;
            this.dataGridViewListCartrige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListCartrige.Location = new System.Drawing.Point(0, 57);
            this.dataGridViewListCartrige.MultiSelect = false;
            this.dataGridViewListCartrige.Name = "dataGridViewListCartrige";
            this.dataGridViewListCartrige.ReadOnly = true;
            this.dataGridViewListCartrige.RowHeadersVisible = false;
            this.dataGridViewListCartrige.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListCartrige.Size = new System.Drawing.Size(334, 453);
            this.dataGridViewListCartrige.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddCartrige,
            this.toolStripSeparator3,
            this.btnUpdateCartrige,
            this.toolStripSeparator2,
            this.btnDellCartrige,
            this.toolStripSeparator4,
            this.btnExportExel,
            this.toolStripSeparator1,
            this.btnClosed});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(334, 30);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddCartrige
            // 
            this.btnAddCartrige.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCartrige.Image = global::CartrigeAltstar.Properties.Resources.Add;
            this.btnAddCartrige.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddCartrige.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCartrige.Name = "btnAddCartrige";
            this.btnAddCartrige.Size = new System.Drawing.Size(39, 27);
            this.btnAddCartrige.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddCartrige.Click += new System.EventHandler(this.btnAddCartrige_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // btnUpdateCartrige
            // 
            this.btnUpdateCartrige.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateCartrige.Image = global::CartrigeAltstar.Properties.Resources.update;
            this.btnUpdateCartrige.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdateCartrige.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateCartrige.Name = "btnUpdateCartrige";
            this.btnUpdateCartrige.Size = new System.Drawing.Size(39, 27);
            this.btnUpdateCartrige.Click += new System.EventHandler(this.btnUpdateCartrige_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btnDellCartrige
            // 
            this.btnDellCartrige.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDellCartrige.Image = global::CartrigeAltstar.Properties.Resources.delete;
            this.btnDellCartrige.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDellCartrige.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDellCartrige.Name = "btnDellCartrige";
            this.btnDellCartrige.Size = new System.Drawing.Size(79, 27);
            this.btnDellCartrige.Click += new System.EventHandler(this.btnDellCartrige_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // btnExportExel
            // 
            this.btnExportExel.Image = global::CartrigeAltstar.Properties.Resources.Exel;
            this.btnExportExel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportExel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportExel.Name = "btnExportExel";
            this.btnExportExel.Size = new System.Drawing.Size(79, 27);
            this.btnExportExel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportExel.Click += new System.EventHandler(this.btnExportCartroge_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // btnClosed
            // 
            this.btnClosed.Image = global::CartrigeAltstar.Properties.Resources.Close;
            this.btnClosed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClosed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(39, 27);
            this.btnClosed.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(334, 27);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // ListCartrigeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 510);
            this.Controls.Add(this.dataGridViewListCartrige);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ListCartrigeForm";
            this.Load += new System.EventHandler(this.ListCartrigeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListCartrige)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridViewListCartrige;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddCartrige;
        private System.Windows.Forms.ToolStripButton btnDellCartrige;
        private System.Windows.Forms.ToolStripButton btnUpdateCartrige;
        private System.Windows.Forms.ToolStripButton btnExportExel;
        private System.Windows.Forms.ToolStripButton btnClosed;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Splitter splitter1;
    }
}