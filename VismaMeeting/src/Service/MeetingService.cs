using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            List<Person>? attendees = meeting.Attendees;
            try
            {
                if (meeting is null)
                {
                    Console.WriteLine("There is no meeting with this id.");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Try creating a meeting or choose an appropriate meeting id.");
            }
            Console.WriteLine("Enter id of the person you wish to add : ");
            Guid id = Guid.Parse(Console.ReadLine());
            var person = PersonsList.FindById(id);
            try
            {
                if (attendees.Contains(person) || meeting.ResponsiblePerson == person ||
                     currentPerson != meeting.ResponsiblePerson)
                {
                    Console.WriteLine("Error adding person to the meeting.");
                }
                else
                {
                    attendees.Add(person);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No person found with this id.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The string to be parsed is null.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
        }
        
        public static void RemoveFromMetting(Person currentPerson)
        {
            var meeting = FindMeeting();
            List<Person>? attendees = meeting.Attendees;
            try
            {
                if (meeting is null)
                {
                    Console.WriteLine("There is no meeting with this id.");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Try creating a meeting or choose an appropriate meeting id.");
            }
            Console.WriteLine("Enter id of the person you wish to remove : ");
            Guid id = Guid.Parse(Console.ReadLine());
            var person = PersonsList.FindById(id);
            try
            {
                if (!attendees.Contains(person) || meeting.ResponsiblePerson == person || 
                    currentPerson != meeting.ResponsiblePerson) 
                {
                    Console.WriteLine("Error removing person from the meeting.");
                }
                else
                {
                    attendees.Remove(person);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No person found with this id.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The string to be parsed is null.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
        }

        public static List<Meeting> DisplayMeetingsByResponsiblePerson()
        {
            var meetingsList = new List<Meeting>();
            Console.WriteLine("Enter responsible person's id : ");
            Guid id = Guid.NewGuid();
            try
            {
                id = Guid.Parse(Console.ReadLine());
                var meetings = MeetingsList.Meetings.Select(x => x)
                    .Where(x => x.ResponsiblePerson.PersonId == id).ToList();
                foreach (var meeting in meetings)
                {
                    meetingsList.Add(meeting);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No person found with this id.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The string to be parsed is null.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            if (meetingsList.Count == 0 )
            {
                Console.WriteLine("This person has not arranged any meetings yet.");
            }
            return meetingsList;
        }

        public static List<Meeting> DisplayMeetingsByCategory()
        {
            var meetingsList = new List<Meeting>();
            Console.WriteLine("Enter meeting's category (0 - codeMonkey, 1 -  hub, 2 - short, 3 - teamBuilding) : ");
            try
            {
                var category = (MeetingCategory) Convert.ToInt32(Console.ReadLine());
                var meetings = MeetingsList.Meetings.Select(x => x)
                    .Where(x => x.MeetingCategory == category).ToList();
                foreach (var meeting in meetings)
                {
                    meetingsList.Add(meeting);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            if (meetingsList.Count == 0 )
            {
                Console.WriteLine("No meetings with this category.");
            }
            return meetingsList;
        }

        public static List<Meeting> DisplayMeetingsByType()
        {
            var meetingsList = new List<Meeting>();
            Console.WriteLine("Enter meeting's type (0 - live, 1 - inPerson) : ");
            try
            {
                var type = (MeetingType) Convert.ToInt32(Console.ReadLine());
                var meetings = MeetingsList.Meetings.Select(x => x)
                    .Where(x => x.MeetingType == type).ToList();
                foreach (var meeting in meetings)
                {
                    meetingsList.Add(meeting);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            if (meetingsList.Count == 0 )
            {
                Console.WriteLine("No meetings with this type.");
            }
            return meetingsList;
        }

        public static List<Meeting> DisplayMeetingsByDescription()
        {
            var meetingsList = new List<Meeting>();
            Console.WriteLine("Enter description filter : ");
            try
            {
                var filter = Console.ReadLine();
                var meetings = MeetingsList.Meetings.Select(x => x)
                    .Where(x => x.Description.ToLower().Contains(filter.ToLower()))
                    .ToList();
                foreach (var meeting in meetings)
                {
                    meetingsList.Add(meeting);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            if (meetingsList.Count == 0 )
            {
                Console.WriteLine("No meetings with this description.");
            }
            return meetingsList;
        }

        public static List<Meeting> DisplayMeetingsByAttendeesCount()
        {
            var meetingsList = new List<Meeting>();
            Console.WriteLine("Enter a number : ");
            try
            {
                var count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Would you like to get meetings which have more than "+count+" attendees or less?\n" +
                                  "(0 - less , 1 - more) : ");
                var option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        var meetings = MeetingsList.Meetings.Select(x => x)
                            .Where(x => x.Attendees.Count <= count).ToList();
                        foreach (var meeting in meetings)
                        {
                            meetingsList.Add(meeting);
                        }
                        break;
                    case 1:
                        meetings = MeetingsList.Meetings.Select(x => x)
                            .Where(x => x.Attendees.Count >= count).ToList();
                        foreach (var meeting in meetings)
                        {
                            meetingsList.Add(meeting);
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            if (meetingsList.Count == 0)
            {
                Console.WriteLine("No meetings with selected attendees count.");
            }
            return meetingsList;
        }

        public static List<Meeting> DisplayMeetingsByDate()
        {
            var meetingsList = new List<Meeting>();
            try
            {
                Console.WriteLine("Enter start date : ");
                var startDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter end date : ");
                var endDate = Convert.ToDateTime(Console.ReadLine());
                var meetings = MeetingsList.Meetings.Select(x => x)
                    .Where(x => x.StartDate >= startDate || x.EndDate >= endDate)
                    .ToList();
                foreach (var meeting in meetings)
                {
                    meetingsList.Add(meeting);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format.");
            }
            if (meetingsList.Count == 0 )
            {
                Console.WriteLine("No meetings happening at this interval.");
            }
            return meetingsList;
        }
    }
}