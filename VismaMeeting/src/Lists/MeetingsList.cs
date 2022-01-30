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

        public static void Display(List<Meeting>? meetings)
        {
            foreach (var meeting in meetings)
            {
                Console.WriteLine($"------------------------------\nMeeting's information :\n" +
                                  $"id : {meeting.MeetingId}\ntitle : {meeting.Name}\n" +
                                  $"responsible person : {meeting.ResponsiblePerson.PersonId}\n" +
                                  $"description : {meeting.Description}\n" +
                                  $"meeting category : {meeting.MeetingCategory}\n" +
                                  $"meeting type : {meeting.MeetingType}\n" +
                                  $"meeting start date : {meeting.StartDate}\n" +
                                  $"meeting end date : {meeting.EndDate}\n" +
                                  $"meeting atendees count : {meeting.Attendees.Count}\n");
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

        // public static Meeting FindByOwnerId(Guid id)
        // {
        //     var meeting = Meetings.FirstOrDefault(x => x.ResponsiblePerson.PersonId == id);
        //     return meeting;
        // }
    }
}