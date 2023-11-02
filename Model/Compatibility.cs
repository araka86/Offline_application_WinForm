using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
  public  class Compatibility
    {
        [Key]
        public int id { get; set; }

        //Foreign key

   


        public int? SubdivisionId { get; set; }
        public virtual Subdivision SubdivisionPK { get; set; } 

        public int? CartrigeId { get; set; }    
        public virtual Cartrige CartrigePK { get; set; } 





    }
}
