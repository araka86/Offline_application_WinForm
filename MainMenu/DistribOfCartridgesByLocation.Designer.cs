
namespace CartrigeAltstar
{
    partial class DistribOfCartridgesByLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistribOfCartridgesByLocation));
            this.labelDivision = new System.Windows.Forms.Label();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.LabelData = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.okAdd = new System.Windows.Forms.Button();
            this.datalabel = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.tbCaretigeModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchCartrigeArticle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvFindArticleResult = new System.Windows.Forms.DataGridView();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.tbCartrigeArticle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindArticleResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDivision
            // 
            resources.ApplyResources(this.labelDivision, "labelDivision");
            this.labelDivision.Name = "labelDivision";
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FormattingEnabled = true;
            resources.ApplyResources(this.cbDepartment, "cbDepartment");
            this.cbDepartment.Name = "cbDepartment";
            // 
            // LabelData
            // 
            resources.ApplyResources(this.LabelData, "LabelData");
            this.LabelData.Name = "LabelData";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // okAdd
            // 
            this.okAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.okAdd, "okAdd");
            this.okAdd.Name = "okAdd";
            this.okAdd.UseVisualStyleBackColor = true;
            this.okAdd.Click += new System.EventHandler(this.okAdd_Click);
            // 
            // datalabel
            // 
            resources.ApplyResources(this.datalabel, "datalabel");
            this.datalabel.Name = "datalabel";
            // 
            // dtpData
            // 
            resources.ApplyResources(this.dtpData, "dtpData");
            this.dtpData.Name = "dtpData";
            // 
            // tbCaretigeModel
            // 
            resources.ApplyResources(this.tbCaretigeModel, "tbCaretigeModel");
            this.tbCaretigeModel.Name = "tbCaretigeModel";
            this.tbCaretigeModel.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbSearchCartrigeArticle
            // 
            resources.ApplyResources(this.tbSearchCartrigeArticle, "tbSearchCartrigeArticle");
            this.tbSearchCartrigeArticle.Name = "tbSearchCartrigeArticle";
            this.tbSearchCartrigeArticle.TextChanged += new System.EventHandler(this.tbSearchCartrigeArticle_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.tbSearchCartrigeArticle);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvFindArticleResult);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // dgvFindArticleResult
            // 
            this.dgvFindArticleResult.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvFindArticleResult, "dgvFindArticleResult");
            this.dgvFindArticleResult.MultiSelect = false;
            this.dgvFindArticleResult.Name = "dgvFindArticleResult";
            this.dgvFindArticleResult.ReadOnly = true;
            this.dgvFindArticleResult.RowHeadersVisible = false;
            this.dgvFindArticleResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFindArticleResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvFindArticleResult_MouseDoubleClick);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // tbCartrigeArticle
            // 
            resources.ApplyResources(this.tbCartrigeArticle, "tbCartrigeArticle");
            this.tbCartrigeArticle.Name = "tbCartrigeArticle";
            this.tbCartrigeArticle.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBox4);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tbId
            // 
            resources.ApplyResources(this.tbId, "tbId");
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbId);
            this.groupBox4.Controls.Add(this.dtpData);
            this.groupBox4.Controls.Add(this.cbDepartment);
            this.groupBox4.Controls.Add(this.tbCaretigeModel);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tbCartrigeArticle);
            this.groupBox4.Controls.Add(this.okAdd);
            this.groupBox4.Controls.Add(this.labelDivision);
            this.groupBox4.Controls.Add(this.datalabel);
            this.groupBox4.Controls.Add(this.button2);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.toolStrip1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::CartrigeAltstar.Properties.Resources.LeftArrow;
            resources.ApplyResources(this.tsbAdd, "tsbAdd");
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DistribOfCartridgesByLocation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LabelData);
            this.Name = "DistribOfCartridgesByLocation";
            this.Load += new System.EventHandler(this.DistribOfCartridgesByLocation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindArticleResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDivision;
        public System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label LabelData;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button okAdd;
        public System.Windows.Forms.Label datalabel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpData;
        public System.Windows.Forms.TextBox tbCaretigeModel;
        public System.Windows.Forms.TextBox tbSearchCartrigeArticle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        public System.Windows.Forms.TextBox tbCartrigeArticle;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.DataGridView dgvFindArticleResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
    }
}