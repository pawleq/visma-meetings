using System;
using System.Collections.Generic;
using System.Linq;

namespace VismaMeeting
{
    public class PersonsList
    {
        public static List<Person> Persons;

        static PersonsList()
        {
            Persons = new List<Person>();
        }

        public static void Add(Person person)
        {
            Persons.Add(person);
        }

        public static void Display()
        {
            foreach (var person in Persons)
            {
                Console.WriteLine($"Person's information : id {person.PersonId}," +
                                  $"name : {person.Name}, surname : {person.Surname}");
            }
        }

        public static Person? FindById(Guid id)
        {
            var person = Persons.FirstOrDefault(x => x.PersonId == id);
            return person;
        }
    }
}