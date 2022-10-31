using HotelManagement.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Entities
{  
    public class Employee : IPerson
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [StringLength(25,MinimumLength =3 ,ErrorMessage = "Name Size must be between 3 and 25")]
        [Required(ErrorMessage ="Name can not be null")]
        public string name { get; set; }
        [Required(ErrorMessage = "Surname can not be null")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Surname Size must be between 3 and 25")]
        public string surname { get; set; }
        [Required(ErrorMessage = "BirthDate can not be null")]
        public DateTime birthDate { get; set; }
        [Required(ErrorMessage = "StartDate can not be null")]
        public DateTime startDate { get; set; }
        [Required(ErrorMessage = "FinishDate can not be null")]
        public DateTime finishDate { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [EmailAddress(ErrorMessage ="Email is not valid email format")]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone can not be null")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Adress can not be null")]
        [StringLength(125, MinimumLength = 3, ErrorMessage = "Adress Size must be between 3 and 125")]
        public string adress { get; set; }
        [Required(ErrorMessage = "Gender can not be null")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "Blood can not be null")]
        public Blood blood { get; set; }
        [Required(ErrorMessage = "Job can not be null")]
        [StringLength(45, MinimumLength = 3, ErrorMessage = "Job Size must be between 3 and 45")]
        public String job { get; set; }
        [Required(ErrorMessage = "Salary can not be null")]
        public int salary { get; set; }

    }
}
