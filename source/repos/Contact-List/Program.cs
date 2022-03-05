using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static List<Person> People = new List<Person>();
        Person person = new Person();
        static void Main(string[] args)
        {
           while(Console.ReadLine() != "Exit")
            {
                Console.Clear();
                Console.WriteLine("Please choose a command: Add, Remove, View, Search, or Exit");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "Add":
                        AddPerson();
                        break;
                    case "Remove":
                        RemoveContact();
                        break;
                    case "View":
                        Announce();
                        break;
                    case "Search":
                        SearchPerson();
                        break;
                    //default:
                    //    command;
                        break;
                }
                if (command == null)
                {
                    Console.WriteLine("Please choose a command: Add, Remove, View, Search, or Exit");
                    return;
                }
            }
        }
        class Person
        {
            string firstName { get; set; }
            string lastName { get; set; }
            public string fullName => firstName + " " + lastName;
            public string phoneNumber { get; set; }
            public string emailAddress { get; set; }
            public string streetAddress { get; set; }
            //public string[] Addresses { get; set; }
            //public static List<Person> People = new List<Person>();
        }

        static void AddPerson()
        {
            Person person = new Person();
            Console.WriteLine("Enter First Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email Address: ");
            var emailAddress = Console.ReadLine();
            Console.WriteLine("Enter Street Address: ");
            var streetAddress = Console.ReadLine();
            People.Add(person);
            //Console.WriteLine("Enter Email Address: ");
            //string[] addresses = new string[2];
            //addresses[0] = Console.ReadLine();
            //Console.WriteLine("Enter Street Address: ");
            //addresses[1] = Console.ReadLine();
            //var Addresses = addresses;
            //List<Person> list = new List<Person>();

        }
        static void PrintPerson(Person person)
        {
            string name = person.fullName;
            string phone = person.phoneNumber;
            string email = person.emailAddress;
            string street = person.streetAddress;
            //var email = person.Addresses[0];
            //var address = person.Addresses[1];
            Console.WriteLine($"Name: {person.fullName}", name);
            Console.WriteLine($"Phone Number: {person.phoneNumber}", phone);
            Console.WriteLine($"Email: {person.emailAddress}", email);
            Console.WriteLine($"Address: {person.streetAddress}", street);
            //Console.WriteLine($"Email Address: {person.Addresses[0]}", email);
            //Console.WriteLine($"Street Address: {person.Addresses[1]}", address);
        }
        static void Announce()
        {
            if(People.Count == 0)
            {
                Console.WriteLine("Your Contacts look empty. Press any key to continue");
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
        static void SearchPerson()
        {
            Console.WriteLine("Enter the name of person to look for.");
            var fullName = Console.ReadLine();
            var person = People.FirstOrDefault(x => x.fullName.ToLower() == fullName.ToLower());
            if (person == null)
            {
                Console.WriteLine("Not Found. Press any key to continue");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Is thsi the droid you're looking for?");
            Console.ReadKey();
            return;
        }
        private static void RemoveContact()
        {
            Console.WriteLine("Enter the name of person to remove.");
            var fullName = Console.ReadLine();
            var person = People.FirstOrDefault(x => x.fullName.ToLower() == fullName.ToLower());
            Console.WriteLine("Want to remove this person from your Contacts?");
            PrintPerson(person);

            if(Console.ReadLine() == "yes")
            {
                People.Remove(person);
                Console.WriteLine("Person Removed. Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
