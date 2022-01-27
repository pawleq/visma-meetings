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
        }

        public static Person CurrentPerson()
        {
            Console.WriteLine("Enter the id of person you want to login as (type 'continue' if you wish to " +
                              "continue unauthorized) : ");
            Guid id = Guid.NewGuid();
            try
            {
                id = Guid.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The string to be parsed is null.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            var person = PersonsList.FindById(id);
            if (person is null)
            {
                Console.WriteLine("Person with this ID does not exist.");
            }
            return person;
        }
    }
}