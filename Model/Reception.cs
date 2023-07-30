using System;
using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar
{
  public class Reception //прием + сдача на сервис
    {
        [Key]
        public int id { get; set; }
        public DateTime? Дата { get; set; } //data empty
        public string Картридж { get; set; }//Catrige
        public double Вес { get; set; } // вес
        public string  Статус { get; set; } //статус (пустой, полний)
        public string Подразделения { get; set; } //от куда приехал

    }
}
