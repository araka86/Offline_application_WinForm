using System;
using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
   public class Printer
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateTimes { get; set; }

        public string ModelPrinter { get; set; }
        public string Article { get; set; }

       
        // явно указать  внешний ключ
        //     [ForeignKey("Subdivision")]  //название таблици на которуюбудет ссилатся внешний ключ
        //     public int Subdivisionid { get; set; }
        //
        //
        //    public int? Subdivisionid { get; set; } //внешний ключ


        public int? SubdivisionId { get; set; } //Foreign Key
        public int? CartrigeId { get; set; }   //Foreign Key
        public virtual Subdivision SubdivisioPK { get; set; } //ссилка на подразделения + внешний ключ SubdivisioPK_Id
        public virtual Cartrige CartrigePk { get; set; }     //ссилка на картридж + внешний ключ CartrigePk_Id
    }



}
