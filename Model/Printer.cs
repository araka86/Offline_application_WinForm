using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class Printer
    {
        public int Id { get; set; }
        public string ModelPrinter { get; set; }
        public string Article { get; set; }

      
       
      
        

        public virtual Subdivision SubIdPk { get; set; }
        public virtual Cartrige CartrigePk { get; set; }
    }
}
