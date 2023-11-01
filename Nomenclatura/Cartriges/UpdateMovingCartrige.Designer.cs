
namespace CartrigeAltstar
{
    partial class UpdateMovingCartrige
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
            this.labelCartrige = new System.Windows.Forms.Label();
            this.labelCartrigeArticle = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCartrige
            // 
            this.labelCartrige.AutoSize = true;
            this.labelCartrige.Location = new System.Drawing.Point(23, 22);
            this.labelCartrige.Name = "labelCartrige";
            this.labelCartrige.Size = new System.Drawing.Size(35, 13);
            this.labelCartrige.TabIndex = 0;
            this.labelCartrige.Text = "label1";
            // 
            // labelCartrigeArticle
            // 
            this.labelCartrigeArticle.AutoSize = true;
            this.labelCartrigeArticle.Location = new System.Drawing.Point(87, 22);
            this.labelCartrigeArticle.Name = "labelCartrigeArticle";
            this.labelCartrigeArticle.Size = new System.Drawing.Size(35, 13);
            this.labelCartrigeArticle.TabIndex = 1;
            this.labelCartrigeArticle.Text = "label2";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(214, 19);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(321, 21);
            this.comboBoxDivision.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(475, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cansel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "--------->";
            // 
            // UpdateMovingCartrige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 93);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxDivision);
            this.Controls.Add(this.labelCartrigeArticle);
            this.Controls.Add(this.labelCartrige);
            this.Name = "UpdateMovingCartrige";
            this.Text = "UpdateMovingCartrige";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxDivision;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labelCartrige;
        public System.Windows.Forms.Label labelCartrigeArticle;
    }
}