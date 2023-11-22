using CartrigeAltstar.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartrigeAltstar
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            using (var loginForm = new LoginForm())
            {
                // Отображаем форму авторизации
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Если авторизация успешна, отображаем главное окно
                    main_Reception mainForm = new main_Reception();
                    mainForm.SetCurrentUserId(loginForm.UserId);
                    Application.Run(mainForm);

                }
            }



        }
    }
}
