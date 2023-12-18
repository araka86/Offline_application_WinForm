using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartrigeAltstar.Model
{
  public  class Compatibility
    {
        [Key]
        public int id { get; set; }

        //Foreign key



       
        [ForeignKey("Department")]  
        public int? DepartmentId { get; set; }
    
        public virtual Department Department { get; set; } 

        public int? CartrigeId { get; set; }    
        public virtual Cartrige CartrigePK { get; set; } 





    }
}
