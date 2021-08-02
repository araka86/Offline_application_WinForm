using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartrigeAltstar.Model
{
    class ContexAltstarContext : DbContext
    {


       
     public ContexAltstarContext() :base("DefaultConnection") { }  //initialization 1

       static ContexAltstarContext() 
       {
           Database.SetInitializer(new ContexAltstarInit());
       }

        public DbSet<Compatibility> Compatibilities {get;set;} //Совместимость
        public DbSet<Printer> Printers { get; set; } //Принтеры
        public DbSet<Subdivision> Subdivisions { get; set; } //Подразделения
        public DbSet<Cartrige> Cartriges { get; set; } //Картриджи
        public DbSet<Reception> Receptions { get; set; } //Прием картриджей
        public DbSet<Dispatch> Dispatches { get; set; } //отправка картриджей
        public DbSet<InfoService> infoServices { get; set; }










        //initialization 2


        //   protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //   {
        //       base.OnModelCreating(modelBuilder);
        //   }


    }



   


}
