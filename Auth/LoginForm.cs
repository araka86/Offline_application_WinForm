using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar.Auth
{
    public partial class LoginForm : Form
    {
        public string UserId { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Передаем введенный идентификатор пользователя в основную форму
            UserId = txtUserId.Text;
            DialogResult = DialogResult.OK;
            Close();
        }



    }
}
