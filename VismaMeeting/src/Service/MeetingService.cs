using System;
using VismaMeeting.Enum;
using VismaMeeting.Model;

namespace VismaMeeting.Service
{
    public class MeetingService
    {
        public static void CreateMeeting()
        {
            Console.WriteLine("Enter the name for the meeting : ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter id of the person who is responsible for it : ");
            Person? responsiblePerson = PersonsList.FindById(Guid.Parse(Console.ReadLine()));
            Console.WriteLine("Enter the description for the meeting : ");
            string? description = Console.ReadLine();
            Console.WriteLine("Enter the category for the meeting : ");
            var category = (MeetingCategory) Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type for the meeting : ");
            var type = (MeetingType) Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter start date of meeting : ");
            var startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter end date of meeting : ");
            var endDate = Convert.ToDateTime(Console.ReadLine());
            Meeting newMeeting = new(name, responsiblePerson, description, category, type, startDate, endDate,
                null);
            MeetingsList.Add(newMeeting);
        }
    }
}