using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CartrigeAltstar.Model
{
    class Dispatch //отправка на подразделения
    {
        public int Id { get; set; }
        public string Date_of_dispatch { get; set; }
        public double Weight { get; set; } // вес после заправка

       
    }
}
