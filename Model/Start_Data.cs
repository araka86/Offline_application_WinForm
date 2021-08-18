using System.Collections.Generic;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class ContexAltstarInit : CreateDatabaseIfNotExists<ContexAltstarContext>
    {




        protected override void Seed(ContexAltstarContext context)
        {


            Subdivision sb1 = new Subdivision
            {

                division = " Сто Бориспольская",
                address_part = "Киев, ул. Бориспольсякая 7"


            };
            Subdivision sb2 = new Subdivision
            {

                division = "СТО Киев Академгородок",
                address_part = "Киев, ул. Степанченко, 5-4"


            };
            Subdivision sb3 = new Subdivision
            {

                division = "СТО Киев Окружная",
                address_part = "Киев, ул. Большая Окружная, 4Г"


            };
            Subdivision sb4 = new Subdivision
            {

                division = "СТО Киев Выдубичи",
                address_part = "Киев, ул. Будиндустрии, 6",



            };
            Subdivision sb5 = new Subdivision
            {

                division = "СТО Киев Жуляны Авторынок",
                address_part = "Киев, ул. Садовая 70А/110"


            };
            Subdivision sb6 = new Subdivision
            {

                division = "СТО Киев Голосеево",
                address_part = "Киев ул. Голосеевская, 9"


            };
            Subdivision sb7 = new Subdivision
            {

                division = "СТО Киев Подол",
                address_part = "Киев ул. Новоконстантиновская 1В (Бокс 194, 195)"


            };
            Subdivision sb8 = new Subdivision
            {

                division = "СТО Вишневое Центр",
                address_part = "г. Вишневое, ул. Киевская, 1"


            };
            Subdivision sb9 = new Subdivision
            {

                division = "СТО Бровары Центр",
                address_part = "Бровары, ул. Киевская, 227/1"


            };
            Subdivision sb10 = new Subdivision
            {

                division = "СТО Бровары Окружная",
                address_part = "Бровары ул.Броварської сотні, 43 (ул. Чкалова)"


            };
            Subdivision sb11 = new Subdivision
            {

                division = "Мастерская АЛЬТ-СТАР «Тиса» Окружная",
                address_part = "Киев ул. Большая Кольцевая, 4Б"


            };
            Subdivision sb12 = new Subdivision
            {

                division = "Мастерская Киев «Жуляны» Авторынок",
                address_part = "Киев ул.Садовая, 70-А/110, п.176"


            };
            Subdivision sb13 = new Subdivision
            {

                division = "Мастерская Киев «Перова» Авторынок",
                address_part = "Киев ул.Перова, 19, павильон 6-А"


            };
            Subdivision sb14 = new Subdivision
            {

                division = "Мастерская Альт Стар – Киев Пуховская",
                address_part = "Киев, ул. Пуховская 2а"


            };
            Subdivision sb15 = new Subdivision
            {

                division = "СТО Киев «Вереснева»",
                address_part = "Киев ул. Вереснева 24"


            };
            Subdivision sb16 = new Subdivision
            {

                division = "Бухгалтерия 275каб",
                address_part = "Киев ул. Бориспольская 7, 2ет"


            };
            Subdivision sb17 = new Subdivision
            {

                division = "279",
                address_part = "Киев ул. Бориспольская 7, 2ет"


            };
            context.Subdivisions.AddRange(new List<Subdivision> { sb1, sb2, sb3, sb4, sb5, sb6, sb7, sb8, sb9, sb10, sb11, sb12, sb13, sb14, sb15, sb16 });
            context.SaveChanges();

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
            context.SaveChanges();




          
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
            context.SaveChanges();


            Compatibility cp = new Compatibility
            {
               
                CartrigePK = ct3,
                SubdivisionPK = sb4

            };
            context.Compatibilities.Add(cp);
            context.SaveChanges();



        }


    }
}
