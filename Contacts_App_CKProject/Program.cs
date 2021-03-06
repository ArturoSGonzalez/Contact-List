using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;


namespace Contacts_App_CKProject
{
    class Program
    {
        private static List<Person> people = new List<Person>();
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"data/people.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                people = csv.GetRecords<Person>().ToList();
            }
            string command = "";
            while (command != "Exit")
            {
                Console.Clear();
                Console.WriteLine("Contacts");
                Console.WriteLine("Please choose a command.");
                Console.WriteLine("Add, View, Search, Remove, or Exit");
                command = Console.ReadLine();
                switch (command)
                {
                    case "Add":
                        AddPerson();
                        people.Add(new Person());
                        break;
                    case "View":
                        Announce();
                        break;
                    case "Search":
                        Search();
                        break;
                    case "Remove":
                        Remove();
                        break;
                    default:
                        break;
                }
            }
        }
        class Person
        {
            [Name("first name")]
            public string firstName { get; set; }
            [Name("last name")]
            public string lastName { get; set; }
            [Name("full name")]
            public string fullName => firstName + " " + lastName;
            [Name("phone number")]
            public string phoneNumber { get; set; }
            [Name("email")]
            public string email { get; set; }
        }
        static void AddPerson()
        {
            Person person = new Person();
            Console.WriteLine("Enter First Name:");
            person.firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            person.lastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            person.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            person.email = Console.ReadLine();

            people.Add(person);
            WriteToCsv(people);
        }

        static void WriteToCsv(List<Person> people)
        {
            using (StreamWriter writer = new StreamWriter(@"data/people.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(people);
            }
        }
        static void Announce()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("Contacts are Empty. Press any key to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("This is: ");
                foreach (Person person in people)
                {
                    PrintPerson(person);
                }
            }
            Console.WriteLine();
            Console.ReadKey();

        }
        static void PrintPerson(Person person)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Name: " + person.fullName);
            Console.WriteLine("Phone Number: " + person.phoneNumber);
            Console.WriteLine("Email: " + person.email);
        }
        static void Search()
        {
            Console.WriteLine("Enter the name of the person to look for.");
            var fullName = Console.ReadLine();
            Person person = people.FirstOrDefault(x => x.fullName.ToLower() == fullName.ToLower());
            if (person == null)
            {
                Console.WriteLine("Not Found. Press any key to continue");
                Console.ReadKey();
                return;
            }
            else
                Console.WriteLine("Is this the droid you're looking for?");
            PrintPerson(person);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void Remove()
        {
            Console.WriteLine("Enter the full name of person to remove.");
            var fullName = Console.ReadLine();
            Person person = people.FirstOrDefault(x => x.fullName.ToLower() == fullName.ToLower());
            if (person == null)
            {
                Console.WriteLine("Person not found. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            bool Y = true;
            while (Y)
            {
                Console.WriteLine("Want to remove this person from your contacts?");
                PrintPerson(person);
                Console.WriteLine("Type Y to confirm.");
                string decision = Console.ReadLine();
                if (decision == "Y")
                {
                    people.Remove(person);
                    Y = true;
                    Console.WriteLine("Person Removed. Press any key to continue.");
                    Console.ReadKey();
                    return;
                }
                else if (decision != "Y")
                {
                    Y = false;
                    Console.WriteLine("Person has not been removed. Press any key to continue.");
                    Console.ReadKey();
                    return;

                }
            }
        }
    }
}
