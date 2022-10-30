using HotelManagement.Entities.EntityBases;
using System;

namespace HotelManagement.Entities
{
    public class Employee : IPerson
    {
        public long id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string adress { get; set; }
        public Gender gender { get; set; }
        public Blood blood { get; set; }
        public String job { get; set; }
        public int salary { get; set; }

    }
}
