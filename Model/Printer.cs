using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartrigeAltstar.Model
{
    class Printer
    {
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
        public virtual Subdivision SubdivisioPK { get; set; } //ссилка на подразделения + внешний ключ SubdivisioPK_Id
        public virtual Cartrige CartrigePk { get; set; }     //ссилка на картридж + внешний ключ CartrigePk_Id
    }












}
