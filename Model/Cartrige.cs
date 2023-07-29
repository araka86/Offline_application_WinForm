using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
    class Cartrige
    {

        [Key]
        public int Id { get; set; }
        public string ModelCartrige { get; set; } // модель, наименования картриджа
        public string ArticleCartrige { get; set; } //артикул картриджа
        public  DateTime? purchase_date { get; set; } //дата покупки (новый не новый)

 
      


        public ICollection<Printer> Printers { get; set; } //ссилка, колекция принтер


        public Cartrige() 
        {
            Printers = new List<Printer>();
        }

       
    }
}
