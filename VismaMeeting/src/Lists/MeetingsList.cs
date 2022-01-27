using System;
using System.Collections.Generic;
using System.Linq;
using VismaMeeting.Model;

namespace VismaMeeting
{
    public class MeetingsList
    {
        public static List<Meeting> Meetings;

        static MeetingsList()
        {
            Meetings = new List<Meeting>();
        }

        public static void Add(Meeting meeting)
        {
            Meetings.Add(meeting);
        }

        public static void Display()
        {
            foreach (var meeting in Meetings)
            {
                Console.WriteLine($"Meeting's {meeting.MeetingId}, {meeting.Name}, " +
                                  $" {meeting.ResponsiblePerson.PersonId}, " +
                                  $"{meeting.Description}," +
                                  $"{meeting.MeetingCategory}, {meeting.MeetingType}, {meeting.StartDate}, " +
                                  $"{meeting.EndDate}, {meeting.Atendees.Count}");
            }
        }
        
        public static Meeting? FindById(Guid id)
        {
            var meeting = Meetings.FirstOrDefault(x => x.MeetingId == id);
            return meeting;
        }
        
        public static void Remove(Meeting meeting)
        {
            Meetings.Remove(meeting);
        }
    }
}