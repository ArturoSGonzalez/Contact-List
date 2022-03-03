using System;
using System.Collections.Generic;

namespace Contact_List
{
    class Program
    {
        static List<Person> People = new List<Person>();
        Person person = new Person();
        static void Main(string[] args)
        {
            
        }
        public class Person
        {
            string firstName { get; set; }
            string lastName { get; set; }
            public string fullName => firstName + " " + lastName;
            public string phoneNumber { get; set; }
            public string[] Addresses { get; set; }
            public static List<Person> People = new List<Person>();
        }

        static void AddPerson()
        {
            Person person = new Person();
            Console.WriteLine("Enter Fist Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email Address: ");
            string[] addresses = new string[2];
            addresses[0] = Console.ReadLine();
            var Addresses = addresses;

            People.Add(person);
        }
        static void PrintPerson(Person person)
        {
            string name = person.fullName;
            string phone = person.phoneNumber;
            string email = person.Addresses[0];
            string address = person.Addresses[1];
            Console.WriteLine($"Name: {person.fullName}", name);
            Console.WriteLine($"Phone Number: {person.phoneNumber}", phone);
            Console.WriteLine($"Email Address: {person.Addresses[0]}", email);
            Console.WriteLine($"Strees Address: {person.Addresses[1]}", address);
            return;
        }
        static void Annouce()
        {
            if(People.Count > 0)
            {
                Console.WriteLine("Your Contacts look empty. Press any key to contiue");
                Console.ReadKey();
            }
            Console.WriteLine("You are viewing: ");
            foreach(Person person in People)
            {
                PrintPerson(person);
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

    }
}
