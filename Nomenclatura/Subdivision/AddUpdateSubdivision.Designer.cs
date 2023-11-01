
namespace CartrigeAltstar
{
    partial class AddUpdateSubdivision
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
            this.tbNameDepartment = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblAddressDepartment = new System.Windows.Forms.Label();
            this.lblNameDepartment = new System.Windows.Forms.Label();
            this.tbAddessDepartment = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNameDepartment
            // 
            this.tbNameDepartment.Location = new System.Drawing.Point(194, 21);
            this.tbNameDepartment.Name = "tbNameDepartment";
            this.tbNameDepartment.Size = new System.Drawing.Size(314, 20);
            this.tbNameDepartment.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(358, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Calcel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblAddressDepartment
            // 
            this.lblAddressDepartment.AutoSize = true;
            this.lblAddressDepartment.Location = new System.Drawing.Point(42, 75);
            this.lblAddressDepartment.Name = "lblAddressDepartment";
            this.lblAddressDepartment.Size = new System.Drawing.Size(125, 13);
            this.lblAddressDepartment.TabIndex = 23;
            this.lblAddressDepartment.Text = "Адресс подразделения";
            // 
            // lblNameDepartment
            // 
            this.lblNameDepartment.AutoSize = true;
            this.lblNameDepartment.Location = new System.Drawing.Point(42, 21);
            this.lblNameDepartment.Name = "lblNameDepartment";
            this.lblNameDepartment.Size = new System.Drawing.Size(87, 13);
            this.lblNameDepartment.TabIndex = 22;
            this.lblNameDepartment.Text = "Подразделения";
            // 
            // tbAddessDepartment
            // 
            this.tbAddessDepartment.Location = new System.Drawing.Point(194, 75);
            this.tbAddessDepartment.Multiline = true;
            this.tbAddessDepartment.Name = "tbAddessDepartment";
            this.tbAddessDepartment.Size = new System.Drawing.Size(314, 94);
            this.tbAddessDepartment.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(194, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddUpdateSubdivision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 248);
            this.Controls.Add(this.tbNameDepartment);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblAddressDepartment);
            this.Controls.Add(this.lblNameDepartment);
            this.Controls.Add(this.tbAddessDepartment);
            this.Controls.Add(this.button1);
            this.Name = "AddUpdateSubdivision";
            this.Text = "AddSubdivision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUpdateSubdivision_FormClosing);
            this.Load += new System.EventHandler(this.AddSubdivision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbNameDepartment;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblAddressDepartment;
        private System.Windows.Forms.Label lblNameDepartment;
        public System.Windows.Forms.TextBox tbAddessDepartment;
        private System.Windows.Forms.Button button1;
    }
}