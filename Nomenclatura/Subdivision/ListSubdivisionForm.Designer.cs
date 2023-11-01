
namespace CartrigeAltstar
{
    partial class ListSubdivisionForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDellDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportExel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClosed = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewListSubdivision = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListSubdivision)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDepartment,
            this.toolStripSeparator3,
            this.btnUpdateDepartment,
            this.toolStripSeparator2,
            this.btnDellDepartment,
            this.toolStripSeparator4,
            this.btnExportExel,
            this.toolStripSeparator1,
            this.btnClosed});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(691, 30);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDepartment.Image = global::CartrigeAltstar.Properties.Resources.Add;
            this.btnAddDepartment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(39, 27);
            this.btnAddDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // btnUpdateDepartment
            // 
            this.btnUpdateDepartment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDepartment.Image = global::CartrigeAltstar.Properties.Resources.update;
            this.btnUpdateDepartment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdateDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDepartment.Name = "btnUpdateDepartment";
            this.btnUpdateDepartment.Size = new System.Drawing.Size(39, 27);
            this.btnUpdateDepartment.Click += new System.EventHandler(this.btnUpdateDepartment_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btnDellDepartment
            // 
            this.btnDellDepartment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDellDepartment.Image = global::CartrigeAltstar.Properties.Resources.delete;
            this.btnDellDepartment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDellDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDellDepartment.Name = "btnDellDepartment";
            this.btnDellDepartment.Size = new System.Drawing.Size(79, 27);
            this.btnDellDepartment.Click += new System.EventHandler(this.btnDellDepartment_Click);
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
            this.btnExportExel.Click += new System.EventHandler(this.btnExportExel_Click);
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
            // dataGridViewListSubdivision
            // 
            this.dataGridViewListSubdivision.AllowUserToDeleteRows = false;
            this.dataGridViewListSubdivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewListSubdivision.Location = new System.Drawing.Point(0, 57);
            this.dataGridViewListSubdivision.MultiSelect = false;
            this.dataGridViewListSubdivision.Name = "dataGridViewListSubdivision";
            this.dataGridViewListSubdivision.ReadOnly = true;
            this.dataGridViewListSubdivision.RowHeadersVisible = false;
            this.dataGridViewListSubdivision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListSubdivision.Size = new System.Drawing.Size(691, 526);
            this.dataGridViewListSubdivision.TabIndex = 32;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(691, 27);
            this.splitter1.TabIndex = 33;
            this.splitter1.TabStop = false;
            // 
            // ListSubdivisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 583);
            this.Controls.Add(this.dataGridViewListSubdivision);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ListSubdivisionForm";
            this.Text = "ListDepartmentForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListSubdivision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnUpdateDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDellDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnExportExel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClosed;
        public System.Windows.Forms.DataGridView dataGridViewListSubdivision;
        private System.Windows.Forms.Splitter splitter1;
    }
}