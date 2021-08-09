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
        public int id { get; set; }
        public DateTime? Date { get; set; } //data empty
        public string Cartrige { get; set; }//Catrige
        public string Date_of_receipt { get; set; } // куда поехал
        public double Weight { get; set; } // вес после заправки
        public string Work_notes { get; set; } //примечания работ (смена барабана, заправка, смена чистищего лезвие)


    }
}
