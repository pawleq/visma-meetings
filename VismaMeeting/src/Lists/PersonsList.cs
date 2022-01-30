using System;
using System.Collections.Generic;
using System.Linq;
using VismaMeeting.Model;

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
                Console.WriteLine($"------------------------------\nPerson's information :\nid : {person.PersonId}\n" +
                                  $"name : {person.Name}\n" +
                                  $"surname : {person.Surname}\n");
            }
            
        }

        public static Person? FindById(Guid id)
        {
            var person = Persons.FirstOrDefault(x => x.PersonId == id);
            return person;
        }
    }
}