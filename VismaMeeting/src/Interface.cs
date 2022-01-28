using System;
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
                              + "5 - Add a person to the meeting (only with responsible persons rights);"
                              + "6 - Remove a person from the meeting (only with responsible persons rights);");

            var option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    PersonService.CreatePerson();
                    Options();
                    break;
                case "2":
                    PersonsList.Display();
                    MeetingsList.Display();
                    Options();
                    break;
                case "3":
                    var currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.CreateMeeting(currentPerson);
                    }
                    Options();
                    break;
                case "4":
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.RemoveMeeting(currentPerson);
                    }
                    Options();
                    break;
                case "5":
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.AddToMeeting(currentPerson);
                    }
                    Options();
                    break;
                case "6":
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.RemoveFromMetting(currentPerson);
                    }
                    Options();
                    break;
            }
        }
    }
}