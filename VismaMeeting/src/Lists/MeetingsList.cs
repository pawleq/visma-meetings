using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using VismaMeeting.Model;

namespace VismaMeeting
{
    public class MeetingsList
    {
        public static List<Meeting> Meetings;

        static MeetingsList()
        {
            Meetings = ReadFromFile();
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
        
        public static Meeting FindById(Guid id)
        {
            var meeting = Meetings.FirstOrDefault(x => x.MeetingId == id);
            return meeting;
        }
        
        public static void Remove(Meeting meeting)
        {
            Meetings.Remove(meeting);
        }

        public static void WriteToFile()
        {
            string fileName = "Meetings.json";
            string jsonString = JsonSerializer.Serialize(Meetings);
            File.WriteAllText(fileName, jsonString);
        }

        public static List<Meeting> ReadFromFile()
        {
            string fileName = "Meetings.json";
            string jsonString = File.ReadAllText(fileName);
            var meetings = new List<Meeting>();
            meetings = JsonSerializer.Deserialize<List<Meeting>>(jsonString);
            return meetings;
        }
    }
}