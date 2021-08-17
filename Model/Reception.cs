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
        public DateTime? Date { get; set; } //data empty
        public string Cartrige { get; set; }//Catrige
        public string Date_of_receipt { get; set; } //от куда приехал
        public double Weight { get; set; } // вес
        public string  Status { get; set; } //статус (пустой, полний)
       

    }
}
