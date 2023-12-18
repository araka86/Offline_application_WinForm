using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartrigeAltstar.Model
{
   public class Printer
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateTimes { get; set; }

        public string ModelPrinter { get; set; }
        public string Article { get; set; }


            //явно указать  внешний ключ
            [ForeignKey("Department")]  //название таблици на которуюбудет ссилатся внешний ключ
             public int? DepartmentId { get; set; }
            public virtual Department Department { get; set; }



        //public int? SubdivisionId { get; set; } //Foreign Key    
        //public virtual Department SubdivisioPK { get; set; } //ссилка на подразделения + внешний ключ SubdivisioPK_Id



        public int? CartrigeId { get; set; }   //Foreign Key
        public virtual Cartrige CartrigePk { get; set; }     //ссилка на картридж + внешний ключ CartrigePk_Id
    }



}
