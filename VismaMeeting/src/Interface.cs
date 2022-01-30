using System;
using System.Collections.Generic;
using VismaMeeting.Model;
using VismaMeeting.Service;

namespace VismaMeeting
{
    public class Interface
    {
        public static Person Login()
        {
            var currentPerson = PersonService.CurrentPerson();
            return currentPerson;
        }
        public static void Options()
        {
            Console.WriteLine("Choose an operation:\n"
                              + "1 - Register a new person;\n"
                              + "2 - Display all data;\n"
                              + "3 - Create a meeting;\n"
                              + "4 - Delete a meeting;\n"
                              + "5 - Add a person to the meeting (only with responsible persons rights);\n"
                              + "6 - Remove a person from the meeting (only with responsible persons rights);\n"
                              + "7 - List meetings by responsible person;\n" 
                              + "8 - List all meetings by category;\n"
                              + "9 - List all meetings by type;\n"
                              + "10 - List all meetings by description filter;\n"
                              + "11 - List all meetings by attendees count;\n"
                              + "12 - List all meetings by date.\n"
                              + "13 - Kill application.");
            
            var option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    PersonService.CreatePerson();
                    Options();
                    break;
                case 2:
                    PersonsList.Display();
                    MeetingsList.Display(MeetingsList.Meetings);
                    Options();
                    break;
                case 3:
                    var currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.CreateMeeting(currentPerson);
                    }

                    Options();
                    break;
                case 4:
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.RemoveMeeting(currentPerson);
                    }

                    Options();
                    break;
                case 5:
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.AddToMeeting(currentPerson);
                    }

                    Options();
                    break;
                case 6:
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.RemoveFromMetting(currentPerson);
                    }

                    Options();
                    break;
                case 7:
                    List<Meeting> meetings = MeetingService.DisplayMeetingsByResponsiblePerson();
                    MeetingsList.Display(meetings);
                    Options();
                    break;
                case 8:
                    meetings = MeetingService.DisplayMeetingsByCategory();
                    MeetingsList.Display(meetings);
                    Options();
                    break;
                case 9:
                    meetings = MeetingService.DisplayMeetingsByType();
                    MeetingsList.Display(meetings);
                    Options();
                    break;
                case 10:
                    meetings = MeetingService.DisplayMeetingsByDescription();
                    MeetingsList.Display(meetings);
                    Options();
                    break;
                case 11:
                    meetings = MeetingService.DisplayMeetingsByAttendeesCount();
                    MeetingsList.Display(meetings);
                    Options();
                    break;
                case 12:
                    meetings = MeetingService.DisplayMeetingsByDate();
                    MeetingsList.Display(meetings);
                    Options();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}