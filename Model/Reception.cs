using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CartrigeAltstar
{
    class Reception //прием + сдача на сервис
    {

        public int id { get; set; }
        public DateTime? Дата { get; set; } //data empty
        public string Картридж { get; set; }//Catrige
        public double Вес { get; set; } // вес
        public string  Статус { get; set; } //статус (пустой, полний)
        public string Подразделения { get; set; } //от куда приехал

    }
}
