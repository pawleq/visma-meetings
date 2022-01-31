using System;
using System.Collections.Generic;

namespace VismaMeeting
{
    public class Person
    {
        public Person(Guid personId, string name, string surname)
        {
            PersonId = personId;
            Name = name;
            Surname = surname;
        }
        
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}