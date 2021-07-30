using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class Cartrige
    {

        public int Id { get; set; }
        public string ModelCartrige { get; set; } // модель, наименования картриджа
        public string ArticleCartrige { get; set; } //артикул картриджа
        public string purchase_date { get; set; } //дата покупки (новый не новый)

 
      


        public ICollection<Printer> Printers { get; set; }


        public Cartrige() 
        {
            Printers = new List<Printer>();
        }


    }
}
