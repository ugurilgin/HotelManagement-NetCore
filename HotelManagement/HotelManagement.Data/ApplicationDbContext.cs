using Entities;
using HotelManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public DbSet<CustomerBill> Bills { get; set; }
        public DbSet<customer_extra> Customer_Extras { get; set; }
        public DbSet<customer_restaurant> Customer_Restaurants { get; set; }
        public DbSet<customer_service> Customer_Services { get; set; }
        public DbSet<Extras> Extras { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<user_roles> User_Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Rooms>()
            .HasMany(c => c.customerBill)
            .WithOne(e => e.room);

            // configures one-to-many relationship
            modelBuilder.Entity<Customers>()
            .HasMany(c => c.customerBill)
            .WithOne(e => e.customer);

            // configures one-to-many relationship
            modelBuilder.Entity<Employee>()
            .HasMany(c => c.room)
            .WithOne(e => e.employee);

            // configures many-to-many relationship
            modelBuilder.Entity<user_roles>()
        .HasKey(bc => new { bc.user_id, bc.role_id });
            modelBuilder.Entity<user_roles>()
                .HasOne(bc => bc.user)
                .WithMany(b => b.user_Roles)
                .HasForeignKey(bc => bc.user_id);
            modelBuilder.Entity<user_roles>()
                .HasOne(bc => bc.role)
                .WithMany(c => c.user_Roles)
                .HasForeignKey(bc => bc.role_id);

            // configures many-to-many relationship
            modelBuilder.Entity<customer_service>()
        .HasKey(bc => new { bc.customer_id, bc.service_id });
            modelBuilder.Entity<customer_service>()
                .HasOne(bc => bc.customers)
                .WithMany(b => b.customer_Services)
                .HasForeignKey(bc => bc.customer_id);
            modelBuilder.Entity<customer_service>()
                .HasOne(bc => bc.services)
                .WithMany(c => c.customer_Services)
                .HasForeignKey(bc => bc.service_id);

            // configures many-to-many relationship
            modelBuilder.Entity<customer_extra>()
      .HasKey(bc => new { bc.customer_id, bc.extras_id });
            modelBuilder.Entity<customer_extra>()
                .HasOne(bc => bc.customers)
                .WithMany(b => b.customer_Extras)
                .HasForeignKey(bc => bc.customer_id);
            modelBuilder.Entity<customer_extra>()
                .HasOne(bc => bc.extras)
                .WithMany(c => c.customer_Extras)
                .HasForeignKey(bc => bc.extras_id);

            // configures many-to-many relationship
            modelBuilder.Entity<customer_restaurant>()
      .HasKey(bc => new { bc.customer_id, bc.restaurant_id });
            modelBuilder.Entity<customer_restaurant>()
                .HasOne(bc => bc.customers)
                .WithMany(b => b.customer_Restaurants)
                .HasForeignKey(bc => bc.customer_id);
            modelBuilder.Entity<customer_restaurant>()
                .HasOne(bc => bc.restaurant)
                .WithMany(c => c.customer_Restaurants)
                .HasForeignKey(bc => bc.restaurant_id);
        }


    }
   

}
