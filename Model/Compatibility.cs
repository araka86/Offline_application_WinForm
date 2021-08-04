using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class Compatibility
    {
        public int id { get; set; }

        //Foreign key


        public int? CartrigeId { get; set; }    //Foreign key
        public int? SubdivisionId { get; set; } //Foreign key

      //  public virtual Printer PrinterPK { get; set; } //link to printer
        public virtual Cartrige CartrigePK { get; set; } //link to cartrige
        public virtual Subdivision SubdivisionPK { get; set; } //link to cartrige


    }
}
