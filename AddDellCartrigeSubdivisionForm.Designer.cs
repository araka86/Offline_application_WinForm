
namespace CartrigeAltstar
{
    partial class AddDellCartrigeSubdivisionForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxCartrige = new System.Windows.Forms.ComboBox();
            this.comboBoxSub = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "------------------------------->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Подразделение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Картридж (Артикул)";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(255, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBoxCartrige
            // 
            this.comboBoxCartrige.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCartrige.FormattingEnabled = true;
            this.comboBoxCartrige.Location = new System.Drawing.Point(12, 55);
            this.comboBoxCartrige.Name = "comboBoxCartrige";
            this.comboBoxCartrige.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCartrige.TabIndex = 15;
            // 
            // comboBoxSub
            // 
            this.comboBoxSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSub.FormattingEnabled = true;
            this.comboBoxSub.Location = new System.Drawing.Point(255, 55);
            this.comboBoxSub.Name = "comboBoxSub";
            this.comboBoxSub.Size = new System.Drawing.Size(280, 21);
            this.comboBoxSub.TabIndex = 14;
            // 
            // AddDellCartrigeSubdivisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 155);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCartrige);
            this.Controls.Add(this.comboBoxSub);
            this.Name = "AddDellCartrigeSubdivisionForm";
            this.Text = "AddDellCartrigeSubdivisionForm";
            this.Load += new System.EventHandler(this.AddDellCartrigeSubdivisionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBoxCartrige;
        public System.Windows.Forms.ComboBox comboBoxSub;
    }
}