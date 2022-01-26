using System;
using System.Collections.Generic;
using VismaMeeting.Enum;

namespace VismaMeeting.Model
{
    public class Meeting
    {
        public Meeting(string? name, Person? responsiblePerson, string? description, MeetingCategory meetingCategory,
            MeetingType meetingType, DateTime startDate, DateTime endDate, List<Person>? atendees)
        {
            Name = name;
            ResponsiblePerson = responsiblePerson;
            Description = description;
            MeetingCategory = meetingCategory;
            MeetingType = meetingType;
            StartDate = startDate;
            EndDate = endDate;
            Atendees = atendees;
        }

        public string? Name { get; set; }
        public Person? ResponsiblePerson { get; set; }
        public string? Description { get; set; }
        public MeetingCategory MeetingCategory { get; set; }
        public MeetingType MeetingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Person>? Atendees { get; set; }
    }
}