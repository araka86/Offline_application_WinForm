using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
  public  class Compatibility
    {
        [Key]
        public int id { get; set; }

        //Foreign key

        public int? CartrigeId { get; set; }    //Foreign key
        public int? SubdivisionId { get; set; } //Foreign key

      //  public virtual Printer PrinterPK { get; set; } //link to printer
        public virtual Cartrige CartrigePK { get; set; } //link to cartrige
        public virtual Subdivision SubdivisionPK { get; set; } //link to cartrige


    }
}
