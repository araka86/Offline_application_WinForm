using System.Collections.Generic;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class ContexAltstarInit : CreateDatabaseIfNotExists<ContexAltstar>
    {




        protected override void Seed(ContexAltstar context)
        {


            Subdivision sb1 = new Subdivision
            {

                Name = " Сто Бориспольская",
                Address = "Киев, ул. Бориспольсякая 7"


            };
            Subdivision sb2 = new Subdivision
            {

                Name = "СТО Киев Академгородок",
                Address = "Киев, ул. Степанченко, 5-4"


            };
            Subdivision sb3 = new Subdivision
            {

                Name = "СТО Киев Окружная",
                Address = "Киев, ул. Большая Окружная, 4Г"


            };
            Subdivision sb4 = new Subdivision
            {

                Name = "СТО Киев Выдубичи",
                Address = "Киев, ул. Будиндустрии, 6",



            };
            Subdivision sb5 = new Subdivision
            {

                Name = "СТО Киев Жуляны Авторынок",
                Address = "Киев, ул. Садовая 70А/110"


            };
            Subdivision sb6 = new Subdivision
            {

                Name = "СТО Киев Голосеево",
                Address = "Киев ул. Голосеевская, 9"


            };
            Subdivision sb7 = new Subdivision
            {

                Name = "СТО Киев Подол",
                Address = "Киев ул. Новоконстантиновская 1В (Бокс 194, 195)"


            };
            Subdivision sb8 = new Subdivision
            {

                Name = "СТО Вишневое Центр",
                Address = "г. Вишневое, ул. Киевская, 1"


            };
            Subdivision sb9 = new Subdivision
            {

                Name = "СТО Бровары Центр",
                Address = "Бровары, ул. Киевская, 227/1"


            };
            Subdivision sb10 = new Subdivision
            {

                Name = "СТО Бровары Окружная",
                Address = "Бровары ул.Броварської сотні, 43 (ул. Чкалова)"


            };
            Subdivision sb11 = new Subdivision
            {

                Name = "Мастерская АЛЬТ-СТАР «Тиса» Окружная",
                Address = "Киев ул. Большая Кольцевая, 4Б"


            };
            Subdivision sb12 = new Subdivision
            {

                Name = "Мастерская Киев «Жуляны» Авторынок",
                Address = "Киев ул.Садовая, 70-А/110, п.176"


            };
            Subdivision sb13 = new Subdivision
            {

                Name = "Мастерская Киев «Перова» Авторынок",
                Address = "Киев ул.Перова, 19, павильон 6-А"


            };
            Subdivision sb14 = new Subdivision
            {

                Name = "Мастерская Альт Стар – Киев Пуховская",
                Address = "Киев, ул. Пуховская 2а"


            };
            Subdivision sb15 = new Subdivision
            {

                Name = "СТО Киев «Вереснева»",
                Address = "Киев ул. Вереснева 24"


            };
            Subdivision sb16 = new Subdivision
            {

                Name = "Бухгалтерия 275каб",
                Address = "Киев ул. Бориспольская 7, 2ет"


            };
            Subdivision sb17 = new Subdivision
            {

                Name = "279",
                Address = "Киев ул. Бориспольская 7, 2ет"

            };
            context.Department.AddRange(new List<Subdivision> { sb1, sb2, sb3, sb4, sb5, sb6, sb7, sb8, sb9, sb10, sb11, sb12, sb13, sb14, sb15, sb16 });


            Cartrige ct1 = new Cartrige
            {
                ModelCartrige = "719",
                ArticleCartrige = "K514",
              
            };
            Cartrige ct2 = new Cartrige
            {
                ModelCartrige = "725 start",
                ArticleCartrige = "K86",
              
            };
            Cartrige ct3 = new Cartrige
            {
                ModelCartrige = "106A",
                ArticleCartrige = "K106",
              
            };

            context.Cartriges.AddRange(new List<Cartrige> { ct1, ct2, ct3 });

            Printer pr1 = new Printer
            {
                
                ModelPrinter = "Samsung 106A",
                Article = "P0KV",
                CartrigePk = ct3,
                SubdivisioPK = sb4


            };
            Printer pr2 = new Printer
            {

                ModelPrinter = "Canon MF3010 V4",
                Article = "P001",
                CartrigePk = ct1,
                SubdivisioPK = sb1

            };
            Printer pr3 = new Printer
            {
               
                ModelPrinter = "Canon MF3010 V4",
                Article = "P883",
                CartrigePk = ct2,
                SubdivisioPK = sb1

            };

            context.Printers.AddRange(new List<Printer> { pr1, pr2, pr3 });
           


            Compatibility cp = new Compatibility
            {
               
                CartrigePK = ct3,
                SubdivisionPK = sb4

            };
            context.Compatibilities.Add(cp);
      

            User user = new User()
            {
                FirstName="Admin",
                LasttName="Admin",
                LoginId = "12345",
                UniqId = 1234567890,
                Role="SuperAdmin",
                Password="12345"
            };
            context.Users.Add(user);
            context.SaveChanges();


        }


    }
}
