
namespace CartrigeAltstar
{
    partial class ReceptionConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceptionConfig));
            this.label4 = new System.Windows.Forms.Label();
            this.labelDivision = new System.Windows.Forms.Label();
            this.comboBoxDivision = new System.Windows.Forms.ComboBox();
            this.LabelData = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.okAdd = new System.Windows.Forms.Button();
            this.datalabel = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCartrige = new System.Windows.Forms.ComboBox();
            this.rbEmpty = new System.Windows.Forms.RadioButton();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // labelDivision
            // 
            resources.ApplyResources(this.labelDivision, "labelDivision");
            this.labelDivision.Name = "labelDivision";
            // 
            // comboBoxDivision
            // 
            resources.ApplyResources(this.comboBoxDivision, "comboBoxDivision");
            this.comboBoxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDivision.FormattingEnabled = true;
            this.comboBoxDivision.Name = "comboBoxDivision";
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
            resources.ApplyResources(this.okAdd, "okAdd");
            this.okAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okAdd.Name = "okAdd";
            this.okAdd.UseVisualStyleBackColor = true;
            // 
            // datalabel
            // 
            resources.ApplyResources(this.datalabel, "datalabel");
            this.datalabel.Name = "datalabel";
            // 
            // txtdate
            // 
            resources.ApplyResources(this.txtdate, "txtdate");
            this.txtdate.Name = "txtdate";
            // 
            // txtWeight
            // 
            resources.ApplyResources(this.txtWeight, "txtWeight");
            this.txtWeight.Name = "txtWeight";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBoxCartrige
            // 
            resources.ApplyResources(this.comboBoxCartrige, "comboBoxCartrige");
            this.comboBoxCartrige.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCartrige.FormattingEnabled = true;
            this.comboBoxCartrige.Name = "comboBoxCartrige";
            // 
            // rbEmpty
            // 
            resources.ApplyResources(this.rbEmpty, "rbEmpty");
            this.rbEmpty.Name = "rbEmpty";
            this.rbEmpty.TabStop = true;
            this.rbEmpty.UseVisualStyleBackColor = true;
            // 
            // rbFull
            // 
            resources.ApplyResources(this.rbFull, "rbFull");
            this.rbFull.Name = "rbFull";
            this.rbFull.TabStop = true;
            this.rbFull.UseVisualStyleBackColor = true;
            // 
            // ReceptionConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbFull);
            this.Controls.Add(this.rbEmpty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCartrige);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.datalabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelDivision);
            this.Controls.Add(this.comboBoxDivision);
            this.Controls.Add(this.LabelData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okAdd);
            this.Name = "ReceptionConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDivision;
        public System.Windows.Forms.ComboBox comboBoxDivision;
        private System.Windows.Forms.Label LabelData;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button okAdd;
        public System.Windows.Forms.Label datalabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxCartrige;
        public System.Windows.Forms.DateTimePicker txtdate;
        public System.Windows.Forms.TextBox txtWeight;
        public System.Windows.Forms.RadioButton rbEmpty;
        public System.Windows.Forms.RadioButton rbFull;
    }
}