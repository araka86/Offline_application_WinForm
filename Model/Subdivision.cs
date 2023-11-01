﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar.Model
{
  public  class Subdivision
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Compatibility> Compatibilities { get; set; }
      
        public virtual ICollection<Printer> Printers { get; set; }

        public Subdivision()
        {

            Printers = new List<Printer>();
            Compatibilities = new List<Compatibility>();
        }

      

    }
}
