namespace VismaMeeting
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonsList.ReadFromFile();
            MeetingsList.ReadFromFile();
            Interface.Options();
            PersonsList.WriteToFile();
            MeetingsList.WriteToFile();
        }
    }
}

