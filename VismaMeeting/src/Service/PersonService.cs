using System;

namespace VismaMeeting.Service
{
    public class PersonService
    {
        public static void CreatePerson()
        {
            Console.WriteLine("Enter the name of the person : ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the surname of the person : ");
            var surname = Console.ReadLine();
            var id = Guid.NewGuid();
            Person newPerson = new(id, name, surname);
            PersonsList.Add(newPerson);
            // string json = JsonSerializer.Serialize(newPerson);
            // File.WriteAllText("personsJson.json", json);
            // Console.WriteLine(File.ReadAllText("personsJson.json"));
        }

        public static Person CurrentPerson()
        {
            Console.WriteLine("Enter the id of person you want to login as : ");
            Guid id = Guid.Parse(Console.ReadLine());
            var person = PersonsList.FindById(id);
            return person;
        }
    }
}