using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartrigeAltstar.Model
{
    public class Current
    {
        [Key]
        public int id { get; set; }

        public DateTime? Дата { get; set; }
        public string Картридж { get; set; }
        public double Вес { get; set; }
        public string Заметки { get; set; }
        public string Подразделения { get; set; }


        public Current(int Id, DateTime? dateTime, string cart, double weight, string ststus, string dep)
        {
            id = Id;
            Дата = dateTime;
            Картридж = cart;
            Вес = weight;
            Заметки = "Пустой";
            Подразделения = dep;
        }


        public static implicit operator Current(Reception v)
        {
            return new Current(v.id, v.Дата, v.Картридж, v.Вес,v.Статус, v.Подразделения);
        }
    }
}
