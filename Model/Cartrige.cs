using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartrigeAltstar.Model
{
    public class Cartrige
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Модель")]
        public string ModelCartrige { get; set; }

        [DisplayName("Артикль")]
        public string ArticleCartrige { get; set; }

        [DisplayName("Дата")]
        public DateTime? purchase_date { get; set; } 




        public ICollection<Printer> Printers { get; set; }


        [ForeignKey("Article")]
        public int? ArticleId { get; set; } 
        public Article Article { get; set; }




    }
}
