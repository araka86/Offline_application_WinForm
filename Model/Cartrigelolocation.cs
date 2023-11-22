using System;
using System.ComponentModel.DataAnnotations;

namespace CartrigeAltstar
{
    public class Cartrigelolocation
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Cartrige { get; set; }
        public string Article { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }

      
    }
}
