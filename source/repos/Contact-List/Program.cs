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
    class Person
        {
            string? firstName { get; set; }
            string? lastName { get; set; }
            public string fullName => firstName + " " + lastName;
            public string? phoneNumber { get; set; }
            public string[]? Addresses { get; set; }
            public static List<Person> People = new List<Person>();
        }
    }
}
