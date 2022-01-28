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
                Console.WriteLine($"Meeting's information : ID : {meeting.MeetingId} , title : {meeting.Name}, " +
                                  $"responsible person {meeting.ResponsiblePerson.PersonId}, " +
                                  $"description {meeting.Description}," +
                                  $"meeting category {meeting.MeetingCategory}, meeting type {meeting.MeetingType}," +
                                  $"meeting start date {meeting.StartDate}, " +
                                  $"meeting end date {meeting.EndDate}, meeting atendees count {meeting.Atendees.Count}");
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