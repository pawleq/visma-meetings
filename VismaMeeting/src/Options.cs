using System;
using VismaMeeting.Service;

namespace VismaMeeting
{
    public class Options
    {
        public static void Interface()
        {
            Console.WriteLine("Choose an operation:\n"
                              + "1 - Add a new person to system\n"
                              + "2 - Display all users\n"
                              + "3 - \n"
                              + "4 - Create a new meeting\n");

            var option = Console.ReadLine();

            while (true)
            {
                switch (option)
                {
                    case "1":
                        PersonService.CreatePerson();
                        Interface();
                        break;
                    case "2":
                        PersonsList.Display();
                        MeetingsList.Display();
                        Interface();
                        break;
                    case "3":
                        PersonService.CurrentPerson();
                        Interface();
                        break;
                    case "4":
                        MeetingService.CreateMeeting();
                        Interface();
                        break;
                }
            }
        }
    }
}