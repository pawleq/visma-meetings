using System;
using System.Collections.Generic;
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
                Console.WriteLine($"Meeting's {meeting.Name}, {meeting.ResponsiblePerson.Name} " +
                                  $"{meeting.ResponsiblePerson.Surname}," +
                                  $"{meeting.Description}," +
                                  $"{meeting.MeetingCategory}, {meeting.MeetingType}, {meeting.StartDate}," +
                                  $"{meeting.EndDate}, {meeting.Atendees}");
            }
        }
    }
}