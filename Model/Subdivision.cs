using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class Subdivision
    {
        public int Id { get; set; }

        public string division { get; set; }
        public string address_part { get; set; }



        public virtual ICollection<Compatibility> Compatibilities { get; set; }
     
    
        public virtual ICollection<Printer> Printers { get; set; }

        public Subdivision()
        {

            Printers = new List<Printer>();
            Compatibilities = new List<Compatibility>();
        }

      


        //  public override string ToString()
        //  {
        //      Id2 = Convert.ToString(id);
        //      return Id2;
        //  }

    }
}
