using HotelManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-2HT864D\\SQLEXPRESS;Database=HotelManagement;User Id=DESKTOP-2HT864D\futbo;Password=;integrated security = true");
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
