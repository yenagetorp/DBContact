using System;
using DBContactLibrary;
using DBContactLibrary.Models;

namespace DBContactTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLRepository sqlRepository = new SQLRepository();
            //int id = sqlRepository.CreateContact("19900923-2335", "Yen", "Svensson");
            //Console.WriteLine(id);
            //Contact contact1 = sqlRepository.ReadContact(id);

            //Console.WriteLine(contact1);
            // var contacts = sqlRepository.ReadAllContacts();
            //foreach (var contact in contacts)
            //{
            //    Console.WriteLine(contact);
            //}
            // sqlRepository.ReadAllContacts().ForEach(Console.WriteLine);
            //sqlRepository.DeleteContact(id);
            //sqlRepository.UpdateContact(1, "19620601-1234", "Håkan", "Joelsson");
            //sqlRepository.ReadAllContacts().ForEach(Console.WriteLine);

            //int id = sqlRepository.CreateAddress("SommarGatan", "Lund", "333 56");
            //Console.WriteLine(id);
            Address address7 = sqlRepository.ReadAddress(7);
            Console.WriteLine(address7);


        }
    }
}
