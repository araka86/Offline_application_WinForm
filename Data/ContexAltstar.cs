using System.Data.Entity;
using System.Reflection.Emit;

namespace CartrigeAltstar.Model
{
    class ContexAltstarContext : DbContext
    {

        public ContexAltstarContext() : base("DefaultConnection") { }  //initialization 1

        static ContexAltstarContext()
        {
            Database.SetInitializer(new ContexAltstarInit());
        }

        public DbSet<Compatibility> Compatibilities { get; set; } //Совместимость
        public DbSet<Printer> Printers { get; set; } //Принтеры
        public DbSet<Subdivision> Subdivisions { get; set; } //Подразделения
        public DbSet<Cartrige> Cartriges { get; set; } //Картриджи
        public DbSet<Reception> Receptions { get; set; } //Прием картриджей
        public DbSet<Dispatch> Dispatches { get; set; } //отправка картриджей
        public DbSet<Current> Currents { get; set; }
        public DbSet<Article> Articles { get; set; }


      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Compatibility>()
            //    .HasRequired(c => c.CartrigePK)
            //    .WithMany(x => x.Compatibilitys)
            //    .HasForeignKey(c => c.CartrigeId)
            //    .WillCascadeOnDelete(false);




            //modelBuilder.Entity<Printer>()
            //    .HasOptional(p => p.CartrigePk)
            //    .WithMany(a=>a.Printers)                // Добавляем это, чтобы указать свойство обратной навигации
            //    .HasForeignKey(p => p.CartrigeId)
            //    .WillCascadeOnDelete(false);


        }






    }


}
