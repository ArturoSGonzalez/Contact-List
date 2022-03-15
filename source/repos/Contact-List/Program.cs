using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static List<Person> Persons = new List<Person>();
        static void Main(string[] args)
        {
            while (Console.ReadLine() != "Exit")
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
                    default:
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
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string fullName => 
            public string phoneNumber { get; set; }
            public string emailAddress { get; set; }
            public string streetAddress { get; set; }
        }
        static void AddPerson()
        {
            Person person = new Person();
            Console.WriteLine("Enter First Name: ");
            person.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            person.lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            person.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email Address: ");
            person.emailAddress = Console.ReadLine();
            Console.WriteLine("Enter Street Address: ");
            person.streetAddress = Console.ReadLine();

            Persons.Add(person);
        }
        static void PrintPerson(Person person)
        {
            //string name = person.fullName;
            //string phone = person.phoneNumber;
            //string email = person.emailAddress;
            //string street = person.streetAddress;

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Phone Number: " + phone);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Address: " + street);
        }
        static void Announce()
        {
            if (Persons.Count == 0)
            {
                Console.WriteLine("Your Contacts look empty. Press any key to continue");
                Console.ReadKey();
            }
            Console.WriteLine("You are viewing: ");
            foreach (Person person in Persons)
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
            Person person = Persons.FirstOrDefault(x => x.fullName.ToLower() == fullName.ToLower());
            Console.WriteLine("Is this the droid you're looking for?");
            PrintPerson(person);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            if (person == null)
            {
                Console.WriteLine("Not Found. Press any key to continue");
                Console.ReadKey();
                return;
            }
        }
        private static void RemoveContact()
        {
            Console.WriteLine("Enter the name of person to remove.");
            var fullName = Console.ReadLine();
            var person = Persons.FirstOrDefault(x => x.fullName.ToLower() == fullName.ToLower());
            Console.WriteLine("Want to remove this person from your Contacts?");
            PrintPerson(person);

            if (Console.ReadLine() == "yes")
            {
                Persons.Remove(person);
                Console.WriteLine("Person Removed. Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
}
}
