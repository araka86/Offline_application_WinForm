using CartrigeAltstar.Auth;
using CartrigeAltstar.Data;
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
            //chek data after migration if exist
            DatabaseSeedAfterMigrations databaseService = new DatabaseSeedAfterMigrations();
            databaseService.CheckAndPopulateData();

            using (var loginForm = new LoginForm())
            {
                // Отображаем форму авторизации
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Если авторизация успешна, отображаем главное окно
                    main_Reception mainForm = new main_Reception();

                    //проверка роли и сритие админ панели управления номенклатурой
                    if (loginForm.Role != "SuperAdmin")
                    {
                        mainForm.tsddbutton.Visible = false;
                    }

                    mainForm.SetCurrentUserId(loginForm.UserId);
                   

                    Application.Run(mainForm);

                }
            }



        }
    }
}
