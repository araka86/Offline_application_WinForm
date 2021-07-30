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
        public int CartrigeId { get; set; }
        public int PrinterId { get; set; }

        public Printer Printer { get; set; } //link to printer
        public Cartrige Cartrige { get; set; } //link to cartrige


    }
}
