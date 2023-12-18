using CartrigeAltstar.Model;
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
        public string Role { get; private set; }

        ContexAltstar contexAltstar;
        public LoginForm()
        {
            InitializeComponent();
            contexAltstar = new ContexAltstar();
            txtPassword.PasswordChar = '*';
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredLoginId = txtLoginId.Text;
            string enteredPassword = txtPassword.Text;

            // Поиск пользователя по введенному логину
            User user = contexAltstar.Users.FirstOrDefault(u => u.LoginId == enteredLoginId);

            if (user != null && user.Password == enteredPassword)
            {
                // Логин и пароль верны
                UserId = user.UniqId.ToString();// Передаем информацию об уникальном id
                Role = user.Role; // Передаем информацию о роли






                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Логин или пароль неверны
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { btnLogin_Click(sender, e); }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin_Click(sender, e); }
        }

        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnLogin_Click(sender, e); }
        }
    }
}
