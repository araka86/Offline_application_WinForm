using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartrigeAltstar.Model
{
    public class Article
    {

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;





        public ICollection<Cartrige> Cartriges { get; set; }

        //public ICollection<Cartrige> Cartriges { get; set; }
        //public Article()
        //{
        //    Cartriges = new List<Cartrige>();
        //}


    }
}
