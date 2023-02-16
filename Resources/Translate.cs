using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CartrigeAltstar.Resources
{
    public static class Translate
    {


        public static void chkTranc(string culture, ResourceManager resourceManager, Main_Reception main_Reception)
        {


            if (culture == "uk-UA")
            {
                // Создаем новый объект resourceManager, извлекающий из сборки 
                resourceManager = new ResourceManager("CartrigeAltstar.langUA", Assembly.GetExecutingAssembly());
                string Data = resourceManager.GetString("Data");
            }
            if (culture == "ru-RU")
            {
                resourceManager = new ResourceManager("CartrigeAltstar.langRU", Assembly.GetExecutingAssembly());
            }
            else
            {

                resourceManager = new ResourceManager("CartrigeAltstar.langEn", Assembly.GetExecutingAssembly());
                string Data = resourceManager.GetString("Data");

            }


        }



    }
}
