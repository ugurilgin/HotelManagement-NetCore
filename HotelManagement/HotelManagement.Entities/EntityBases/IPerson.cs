using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Entities.EntityBases
{
    public enum Gender
    {
        Erkek, Kadın, Male, Female
    }
    public enum Blood
    {
        ORhN, ORhP, ARhN, ARhP, BRhN, BRhP, ABRhN, ABRhP

    }

    public interface IPerson
    {
      
        public long id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string adress { get; set; }
        public Gender gender { get; set; }
        public Blood blood { get; set; }
    }
}
