using System;
using System.Collections.Generic;
using VismaMeeting.Enum;
using VismaMeeting.Model;

namespace VismaMeeting.Service
{
    public class MeetingService
    {
        public static Meeting FindMeeting()
        {
            Console.WriteLine("Enter the id of the meeting : ");
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
            var meeting = MeetingsList.FindById(id);
            return meeting;
        }
        public static void CreateMeeting(Person responsiblePerson)
        {
            Console.WriteLine("Enter the name for the meeting : ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter the description for the meeting : ");
            string? description = Console.ReadLine();
            Console.WriteLine("Enter the category for the meeting : ");
            var category = (MeetingCategory) Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type for the meeting : ");
            var type = (MeetingType) Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter start date of meeting : ");
            var startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter end date of meeting : ");
            var endDate = Convert.ToDateTime(Console.ReadLine());
            Guid id = Guid.NewGuid();
            Meeting newMeeting = new(id, name, responsiblePerson, description, category, type, startDate, endDate,
                new List<Person>());
            MeetingsList.Add(newMeeting);
        }

        public static void RemoveMeeting(Person currentPerson)
        {
            var meeting = FindMeeting();
            try
            {
                if (meeting is null)
                {
                    Console.WriteLine("There is no meeting with this id.");
                }
                if (meeting.ResponsiblePerson.PersonId != currentPerson.PersonId)
                {
                    Console.WriteLine("Person does not have right deleting this event. Check ownership.");
                }
                else
                {
                    MeetingsList.Remove(meeting);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Try creating a meet or choose an appropriate meeting id.");
            }
        }

        public static void AddToMeeting(Person currentPerson)
        {
            var meeting = FindMeeting();
            List<Person>? atendees = meeting.Atendees;
            try
            {
                if (meeting is null)
                {
                    Console.WriteLine("There is no meeting with this id.");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Try creating a meet or choose an appropriate meeting id.");
            }
            Console.WriteLine("Enter id of the person you wish to add : ");
            Guid id = Guid.Parse(Console.ReadLine()); //idet exception del id
            var person = PersonsList.FindById(id);
            try
            {
                if (!atendees.Contains(person) && currentPerson != person) //sutvarkyt logika kad nepridedinetu random
                {
                    atendees.Add(person);
                }
                else
                {
                    Console.WriteLine("This person is already in the meeting. Try removing it before adding.");
                }
                if (person == currentPerson)
                {
                    Console.WriteLine("Meeting owner cannot add himself as a atendee.");
                }
                if (meeting.ResponsiblePerson.PersonId != currentPerson.PersonId)
                {
                    Console.WriteLine("Person does not have rights to add atendees to the event. Check ownership.");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No person found with this id.");
            }
        }
        
        public static void RemoveFromMetting(Person currentPerson)
        {
            var meeting = FindMeeting();
        }
    }
}