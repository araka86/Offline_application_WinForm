namespace CartrigeAltstar.Nomenclatura.Cartriges
{
    partial class SendingForFilling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendingForFilling));
            this.listBoxFindArticleResult = new System.Windows.Forms.ListBox();
            this.tbSearchCartrigeArticle = new System.Windows.Forms.TextBox();
            this.labelCartrigeInfoAboveTheGrid = new System.Windows.Forms.Label();
            this.lblSearchArticle = new System.Windows.Forms.Label();
            this.btnShowIsServiceCartriges = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearServiceCartriges = new System.Windows.Forms.Button();
            this.dgShowIsServiceCartriges = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxForSend = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.tsbSendtoFillCartrige = new System.Windows.Forms.ToolStripButton();
            this.tsbAcceptCrtige = new System.Windows.Forms.ToolStripButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgShowIsServiceCartriges)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxFindArticleResult
            // 
            this.listBoxFindArticleResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFindArticleResult.FormattingEnabled = true;
            this.listBoxFindArticleResult.Location = new System.Drawing.Point(3, 16);
            this.listBoxFindArticleResult.Name = "listBoxFindArticleResult";
            this.listBoxFindArticleResult.Size = new System.Drawing.Size(773, 136);
            this.listBoxFindArticleResult.TabIndex = 2;
            this.listBoxFindArticleResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbFindArticleResult_MouseClick);
            this.listBoxFindArticleResult.SelectedIndexChanged += new System.EventHandler(this.lbFindArticleResult_SelectedIndexChanged);
            this.listBoxFindArticleResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFindArticleResult_MouseDoubleClick);
            // 
            // tbSearchCartrigeArticle
            // 
            this.tbSearchCartrigeArticle.Location = new System.Drawing.Point(12, 35);
            this.tbSearchCartrigeArticle.Name = "tbSearchCartrigeArticle";
            this.tbSearchCartrigeArticle.Size = new System.Drawing.Size(147, 20);
            this.tbSearchCartrigeArticle.TabIndex = 3;
            this.tbSearchCartrigeArticle.TextChanged += new System.EventHandler(this.tbSearchCartrigeArticle_TextChanged);
            // 
            // labelCartrigeInfoAboveTheGrid
            // 
            this.labelCartrigeInfoAboveTheGrid.AutoSize = true;
            this.labelCartrigeInfoAboveTheGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCartrigeInfoAboveTheGrid.Location = new System.Drawing.Point(3, 16);
            this.labelCartrigeInfoAboveTheGrid.Name = "labelCartrigeInfoAboveTheGrid";
            this.labelCartrigeInfoAboveTheGrid.Size = new System.Drawing.Size(129, 13);
            this.labelCartrigeInfoAboveTheGrid.TabIndex = 9;
            this.labelCartrigeInfoAboveTheGrid.Text = "Картриджи на заправке";
            // 
            // lblSearchArticle
            // 
            this.lblSearchArticle.AutoSize = true;
            this.lblSearchArticle.Location = new System.Drawing.Point(15, 17);
            this.lblSearchArticle.Name = "lblSearchArticle";
            this.lblSearchArticle.Size = new System.Drawing.Size(97, 13);
            this.lblSearchArticle.TabIndex = 11;
            this.lblSearchArticle.Text = "Поиск по артиклу";
            // 
            // btnShowIsServiceCartriges
            // 
            this.btnShowIsServiceCartriges.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowIsServiceCartriges.Location = new System.Drawing.Point(3, 16);
            this.btnShowIsServiceCartriges.Name = "btnShowIsServiceCartriges";
            this.btnShowIsServiceCartriges.Size = new System.Drawing.Size(110, 26);
            this.btnShowIsServiceCartriges.TabIndex = 7;
            this.btnShowIsServiceCartriges.Text = "Показать";
            this.btnShowIsServiceCartriges.UseVisualStyleBackColor = true;
            this.btnShowIsServiceCartriges.Click += new System.EventHandler(this.btnShowIsServiceCartriges_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatusInfo);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblSearchArticle);
            this.groupBox1.Controls.Add(this.tbSearchCartrigeArticle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 64);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Location = new System.Drawing.Point(278, 16);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(736, 42);
            this.lblStatusInfo.TabIndex = 14;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(203, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 17);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Статус :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dgShowIsServiceCartriges);
            this.groupBox2.Controls.Add(this.labelCartrigeInfoAboveTheGrid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(779, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 426);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearServiceCartriges);
            this.groupBox3.Controls.Add(this.btnShowIsServiceCartriges);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 378);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 45);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // btnClearServiceCartriges
            // 
            this.btnClearServiceCartriges.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClearServiceCartriges.Location = new System.Drawing.Point(113, 16);
            this.btnClearServiceCartriges.Name = "btnClearServiceCartriges";
            this.btnClearServiceCartriges.Size = new System.Drawing.Size(110, 26);
            this.btnClearServiceCartriges.TabIndex = 8;
            this.btnClearServiceCartriges.Text = "Очистить";
            this.btnClearServiceCartriges.UseVisualStyleBackColor = true;
            this.btnClearServiceCartriges.Click += new System.EventHandler(this.btnClearServiceCartriges_Click);
            // 
            // dgShowIsServiceCartriges
            // 
            this.dgShowIsServiceCartriges.AllowUserToDeleteRows = false;
            this.dgShowIsServiceCartriges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgShowIsServiceCartriges.Location = new System.Drawing.Point(3, 29);
            this.dgShowIsServiceCartriges.MultiSelect = false;
            this.dgShowIsServiceCartriges.Name = "dgShowIsServiceCartriges";
            this.dgShowIsServiceCartriges.ReadOnly = true;
            this.dgShowIsServiceCartriges.RowHeadersVisible = false;
            this.dgShowIsServiceCartriges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgShowIsServiceCartriges.Size = new System.Drawing.Size(235, 394);
            this.dgShowIsServiceCartriges.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxForSend);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(779, 271);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // listBoxForSend
            // 
            this.listBoxForSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxForSend.FormattingEnabled = true;
            this.listBoxForSend.Location = new System.Drawing.Point(3, 57);
            this.listBoxForSend.Name = "listBoxForSend";
            this.listBoxForSend.Size = new System.Drawing.Size(773, 211);
            this.listBoxForSend.TabIndex = 3;
            this.listBoxForSend.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbForSend_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUp,
            this.tsbDown,
            this.tsbSendtoFillCartrige,
            this.tsbAcceptCrtige});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(773, 41);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbUp
            // 
            this.tsbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUp.Image = global::CartrigeAltstar.Properties.Resources.up;
            this.tsbUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(34, 38);
            this.tsbUp.Text = "toolStripButton1";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // tsbDown
            // 
            this.tsbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDown.Image = global::CartrigeAltstar.Properties.Resources.down;
            this.tsbDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(34, 38);
            this.tsbDown.Text = "toolStripButton2";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // tsbSendtoFillCartrige
            // 
            this.tsbSendtoFillCartrige.Enabled = false;
            this.tsbSendtoFillCartrige.Image = global::CartrigeAltstar.Properties.Resources.Send;
            this.tsbSendtoFillCartrige.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSendtoFillCartrige.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSendtoFillCartrige.Name = "tsbSendtoFillCartrige";
            this.tsbSendtoFillCartrige.Size = new System.Drawing.Size(171, 38);
            this.tsbSendtoFillCartrige.Text = "Отправить на заправку";
            this.tsbSendtoFillCartrige.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbSendtoFillCartrige.ToolTipText = "Отправить на заправку";
            this.tsbSendtoFillCartrige.Click += new System.EventHandler(this.tsbSend_Click);
            // 
            // tsbAcceptCrtige
            // 
            this.tsbAcceptCrtige.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAcceptCrtige.Image = global::CartrigeAltstar.Properties.Resources.sendBack;
            this.tsbAcceptCrtige.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAcceptCrtige.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAcceptCrtige.Name = "tsbAcceptCrtige";
            this.tsbAcceptCrtige.Size = new System.Drawing.Size(251, 38);
            this.tsbAcceptCrtige.Text = "Прейти к меню картриджи с заправки";
            this.tsbAcceptCrtige.Click += new System.EventHandler(this.tsbAcceptCrtige_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBoxFindArticleResult);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(779, 155);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // SendingForFilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 514);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SendingForFilling";
            this.Text = "Отправить картриджи на заправку";
            this.Load += new System.EventHandler(this.SendingForFilling_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgShowIsServiceCartriges)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFindArticleResult;
        private System.Windows.Forms.TextBox tbSearchCartrigeArticle;
        private System.Windows.Forms.Label labelCartrigeInfoAboveTheGrid;
        private System.Windows.Forms.Label lblSearchArticle;
        private System.Windows.Forms.Button btnShowIsServiceCartriges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.ToolStripButton tsbSendtoFillCartrige;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ListBox listBoxForSend;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgShowIsServiceCartriges;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearServiceCartriges;
        private System.Windows.Forms.ToolStripButton tsbAcceptCrtige;
        private System.Windows.Forms.Label lblStatusInfo;
    }
}