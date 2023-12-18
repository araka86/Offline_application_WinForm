
namespace CartrigeAltstar
{
    partial class AcceptСartridgesFromLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcceptСartridgesFromLocations));
            this.tbSearchCartrigeArticle = new System.Windows.Forms.TextBox();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.datalabel = new System.Windows.Forms.Label();
            this.gbSearchArtileCartrige = new System.Windows.Forms.GroupBox();
            this.dgvFindArticleResulttoLocations = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLeft = new System.Windows.Forms.ToolStripButton();
            this.gbReceivingCartridges = new System.Windows.Forms.GroupBox();
            this.dgvAcceptFromLocations = new System.Windows.Forms.DataGridView();
            this.gbSearchArtileCartrige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindArticleResulttoLocations)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbReceivingCartridges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcceptFromLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearchCartrigeArticle
            // 
            resources.ApplyResources(this.tbSearchCartrigeArticle, "tbSearchCartrigeArticle");
            this.tbSearchCartrigeArticle.Name = "tbSearchCartrigeArticle";
            this.tbSearchCartrigeArticle.TextChanged += new System.EventHandler(this.tbSearchCartrigeArticle_TextChanged);
            // 
            // txtdate
            // 
            this.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.txtdate, "txtdate");
            this.txtdate.Name = "txtdate";
            // 
            // datalabel
            // 
            resources.ApplyResources(this.datalabel, "datalabel");
            this.datalabel.Name = "datalabel";
            // 
            // gbSearchArtileCartrige
            // 
            this.gbSearchArtileCartrige.Controls.Add(this.dgvFindArticleResulttoLocations);
            this.gbSearchArtileCartrige.Controls.Add(this.tbSearchCartrigeArticle);
            resources.ApplyResources(this.gbSearchArtileCartrige, "gbSearchArtileCartrige");
            this.gbSearchArtileCartrige.Name = "gbSearchArtileCartrige";
            this.gbSearchArtileCartrige.TabStop = false;
            // 
            // dgvFindArticleResulttoLocations
            // 
            this.dgvFindArticleResulttoLocations.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvFindArticleResulttoLocations, "dgvFindArticleResulttoLocations");
            this.dgvFindArticleResulttoLocations.MultiSelect = false;
            this.dgvFindArticleResulttoLocations.Name = "dgvFindArticleResulttoLocations";
            this.dgvFindArticleResulttoLocations.ReadOnly = true;
            this.dgvFindArticleResulttoLocations.RowHeadersVisible = false;
            this.dgvFindArticleResulttoLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindArticleResulttoLocations.DoubleClick += new System.EventHandler(this.dgvFindArticleResulttoLocations_DoubleClick);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.toolStrip1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOk,
            this.toolStripSeparator1,
            this.tsbRight,
            this.toolStripSeparator2,
            this.tsbLeft});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbOk
            // 
            this.tsbOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbOk, "tsbOk");
            this.tsbOk.Image = global::CartrigeAltstar.Properties.Resources.ok;
            this.tsbOk.Name = "tsbOk";
            this.tsbOk.Click += new System.EventHandler(this.tsbOk_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbRight
            // 
            this.tsbRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRight.Image = global::CartrigeAltstar.Properties.Resources.rightArrow;
            resources.ApplyResources(this.tsbRight, "tsbRight");
            this.tsbRight.Name = "tsbRight";
            this.tsbRight.Click += new System.EventHandler(this.tsbRight_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsbLeft
            // 
            this.tsbLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLeft.Image = global::CartrigeAltstar.Properties.Resources.LeftArrow;
            resources.ApplyResources(this.tsbLeft, "tsbLeft");
            this.tsbLeft.Name = "tsbLeft";
            this.tsbLeft.Click += new System.EventHandler(this.tsbLeft_Click);
            // 
            // gbReceivingCartridges
            // 
            this.gbReceivingCartridges.Controls.Add(this.datalabel);
            this.gbReceivingCartridges.Controls.Add(this.txtdate);
            resources.ApplyResources(this.gbReceivingCartridges, "gbReceivingCartridges");
            this.gbReceivingCartridges.Name = "gbReceivingCartridges";
            this.gbReceivingCartridges.TabStop = false;
            // 
            // dgvAcceptFromLocations
            // 
            this.dgvAcceptFromLocations.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvAcceptFromLocations, "dgvAcceptFromLocations");
            this.dgvAcceptFromLocations.MultiSelect = false;
            this.dgvAcceptFromLocations.Name = "dgvAcceptFromLocations";
            this.dgvAcceptFromLocations.ReadOnly = true;
            this.dgvAcceptFromLocations.RowHeadersVisible = false;
            this.dgvAcceptFromLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAcceptFromLocations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvAcceptFromLocations_MouseDoubleClick);
            // 
            // AcceptСartridgesFromLocations
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAcceptFromLocations);
            this.Controls.Add(this.gbReceivingCartridges);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbSearchArtileCartrige);
            this.Name = "AcceptСartridgesFromLocations";
            this.Load += new System.EventHandler(this.AcceptСartridgesFromLocations_Load);
            this.gbSearchArtileCartrige.ResumeLayout(false);
            this.gbSearchArtileCartrige.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindArticleResulttoLocations)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbReceivingCartridges.ResumeLayout(false);
            this.gbReceivingCartridges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcceptFromLocations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tbSearchCartrigeArticle;
        public System.Windows.Forms.DateTimePicker txtdate;
        public System.Windows.Forms.Label datalabel;
        private System.Windows.Forms.GroupBox gbSearchArtileCartrige;
        private System.Windows.Forms.DataGridView dgvFindArticleResulttoLocations;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbLeft;
        private System.Windows.Forms.GroupBox gbReceivingCartridges;
        private System.Windows.Forms.DataGridView dgvAcceptFromLocations;
    }
}