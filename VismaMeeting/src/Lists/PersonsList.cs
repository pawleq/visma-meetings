using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using VismaMeeting.Model;
using VismaMeeting.Service;

namespace VismaMeeting
{
    public class PersonsList
    {
        public static List<Person> Persons;

        static PersonsList()
        {
            Persons = ReadFromFile();
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

        public static Person FindById(Guid id)
        {
            var person = Persons.FirstOrDefault(x => x.PersonId == id);
            return person;
        }
        
        public static void WriteToFile()
        {
            string fileName = "Persons.json";
            string jsonString = JsonSerializer.Serialize(Persons);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Person> ReadFromFile()
        {
            string fileName = "Persons.json";
            string jsonString = File.ReadAllText(fileName);
            var persons = JsonSerializer.Deserialize<List<Person>>(jsonString);
            return persons;
        }
    }
}