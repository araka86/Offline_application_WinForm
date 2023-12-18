using System.Collections.Generic;
using System.Data.Entity;
namespace CartrigeAltstar.Model
{
    class ContexAltstarInit : CreateDatabaseIfNotExists<ContexAltstar>
    {




        protected override void Seed(ContexAltstar context)
        {


            Department sb1 = new Department
            {

                Name = " Сто Бориспольская",
                Address = "Киев, ул. Бориспольсякая 7"


            };
            Department sb2 = new Department
            {

                Name = "СТО Киев Академгородок",
                Address = "Киев, ул. Степанченко, 5-4"


            };
            Department sb3 = new Department
            {

                Name = "СТО Киев Окружная",
                Address = "Киев, ул. Большая Окружная, 4Г"


            };
            Department sb4 = new Department
            {

                Name = "СТО Киев Выдубичи",
                Address = "Киев, ул. Будиндустрии, 6",



            };
            Department sb5 = new Department
            {

                Name = "СТО Киев Жуляны Авторынок",
                Address = "Киев, ул. Садовая 70А/110"


            };
            Department sb6 = new Department
            {

                Name = "СТО Киев Голосеево",
                Address = "Киев ул. Голосеевская, 9"


            };
            Department sb7 = new Department
            {

                Name = "СТО Киев Подол",
                Address = "Киев ул. Новоконстантиновская 1В (Бокс 194, 195)"


            };
            Department sb8 = new Department
            {

                Name = "СТО Вишневое Центр",
                Address = "г. Вишневое, ул. Киевская, 1"


            };
            Department sb9 = new Department
            {

                Name = "СТО Бровары Центр",
                Address = "Бровары, ул. Киевская, 227/1"


            };
            Department sb10 = new Department
            {

                Name = "СТО Бровары Окружная",
                Address = "Бровары ул.Броварської сотні, 43 (ул. Чкалова)"


            };
            Department sb11 = new Department
            {

                Name = "Мастерская АЛЬТ-СТАР «Тиса» Окружная",
                Address = "Киев ул. Большая Кольцевая, 4Б"


            };
            Department sb12 = new Department
            {

                Name = "Мастерская Киев «Жуляны» Авторынок",
                Address = "Киев ул.Садовая, 70-А/110, п.176"


            };
            Department sb13 = new Department
            {

                Name = "Мастерская Киев «Перова» Авторынок",
                Address = "Киев ул.Перова, 19, павильон 6-А"


            };
            Department sb14 = new Department
            {

                Name = "Мастерская Альт Стар – Киев Пуховская",
                Address = "Киев, ул. Пуховская 2а"


            };
            Department sb15 = new Department
            {

                Name = "СТО Киев «Вереснева»",
                Address = "Киев ул. Вереснева 24"


            };
            Department sb16 = new Department
            {

                Name = "Бухгалтерия 275каб",
                Address = "Киев ул. Бориспольская 7, 2ет"


            };
            Department sb17 = new Department
            {

                Name = "279",
                Address = "Киев ул. Бориспольская 7, 2ет"

            };
            context.Departments.AddRange(new List<Department> { sb1, sb2, sb3, sb4, sb5, sb6, sb7, sb8, sb9, sb10, sb11, sb12, sb13, sb14, sb15, sb16 });


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
                Department = sb4


            };
            Printer pr2 = new Printer
            {

                ModelPrinter = "Canon MF3010 V4",
                Article = "P001",
                CartrigePk = ct1,
                Department = sb1

            };
            Printer pr3 = new Printer
            {
               
                ModelPrinter = "Canon MF3010 V4",
                Article = "P883",
                CartrigePk = ct2,
                Department = sb1

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
