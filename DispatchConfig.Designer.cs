
namespace CartrigeAltstar
{
    partial class DispatchConfig
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCartrige = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.datalabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDivision = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.okAdd = new System.Windows.Forms.Button();
            this.txtZametki = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Подразделение";
            // 
            // comboBoxCartrige
            // 
            this.comboBoxCartrige.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCartrige.FormattingEnabled = true;
            this.comboBoxCartrige.Location = new System.Drawing.Point(127, 94);
            this.comboBoxCartrige.Name = "comboBoxCartrige";
            this.comboBoxCartrige.Size = new System.Drawing.Size(215, 21);
            this.comboBoxCartrige.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Вес";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(127, 234);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 44;
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(127, 9);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(215, 20);
            this.txtdate.TabIndex = 43;
            // 
            // datalabel
            // 
            this.datalabel.AutoSize = true;
            this.datalabel.Location = new System.Drawing.Point(12, 9);
            this.datalabel.Name = "datalabel";
            this.datalabel.Size = new System.Drawing.Size(33, 13);
            this.datalabel.TabIndex = 42;
            this.datalabel.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Заметки";
            // 
            // labelDivision
            // 
            this.labelDivision.AutoSize = true;
            this.labelDivision.Location = new System.Drawing.Point(12, 94);
            this.labelDivision.Name = "labelDivision";
            this.labelDivision.Size = new System.Drawing.Size(57, 13);
            this.labelDivision.TabIndex = 40;
            this.labelDivision.Text = "Картридж";
            // 
            // comboBoxDivision
            // 
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Location = new System.Drawing.Point(127, 52);
            this.comboBoxDivision.Name = "comboBoxDivision";
            this.comboBoxDivision.Size = new System.Drawing.Size(215, 21);
            this.comboBoxDivision.TabIndex = 39;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "Calcel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // okAdd
            // 
            this.okAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okAdd.Location = new System.Drawing.Point(15, 281);
            this.okAdd.Name = "okAdd";
            this.okAdd.Size = new System.Drawing.Size(75, 23);
            this.okAdd.TabIndex = 37;
            this.okAdd.Text = "OK";
            this.okAdd.UseVisualStyleBackColor = true;
            // 
            // txtZametki
            // 
            this.txtZametki.Location = new System.Drawing.Point(127, 133);
            this.txtZametki.Multiline = true;
            this.txtZametki.Name = "txtZametki";
            this.txtZametki.Size = new System.Drawing.Size(215, 73);
            this.txtZametki.TabIndex = 50;
            // 
            // DispatchConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 313);
            this.Controls.Add(this.txtZametki);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCartrige);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.datalabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelDivision);
            this.Controls.Add(this.comboBoxDivision);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okAdd);
            this.Name = "DispatchConfig";
            this.Text = "DispatchConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxCartrige;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtWeight;
        public System.Windows.Forms.DateTimePicker txtdate;
        public System.Windows.Forms.Label datalabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDivision;
        public System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button okAdd;
        public System.Windows.Forms.TextBox txtZametki;
    }
}