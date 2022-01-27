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
                              + "2 - Display all persons;\n"
                              + "3 - Remove a meeting (only responsible person can);\n"
                              + "4 - Create a new meeting;\n");

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
                        MeetingService.RemoveMeeting(currentPerson);
                    }
                    Options();
                    break;
                case "4":
                    currentPerson = Login();
                    if (currentPerson is not null)
                    {
                        MeetingService.CreateMeeting(currentPerson);
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
            }
        }
    }
}