using System;
using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
    class Dispatch //отправка на подразделения
    {
        [Key]
        public int id { get; set; }
        
        public DateTime? Дата { get; set; } //data empty
        public string Картридж { get; set; }//Catrige
        public double Вес { get; set; } // вес после заправки
        public string Заметки { get; set; } //примечания работ (смена барабана, заправка, смена чистищего лезвие)
        public string Подразделения { get; set; } // куда поехал

    }
}
