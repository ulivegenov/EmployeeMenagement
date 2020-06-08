namespace EmployeeManagement.Api.Models
{
    using EmployeeManagement.Models;
    using EmployeeManagement.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Employee Table
            modelBuilder.Entity<Departament>().HasData(
                new Departament { DepartamentId = 1, DepartamentName = "IT" });
            modelBuilder.Entity<Departament>().HasData(
                new Departament { DepartamentId = 2, DepartamentName = "HR" });
            modelBuilder.Entity<Departament>().HasData(
                new Departament { DepartamentId = 3, DepartamentName = "Payroll" });
            modelBuilder.Entity<Departament>().HasData(
                new Departament { DepartamentId = 4, DepartamentName = "Admin" });

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData (new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastigs",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                DepartamentId = 1,
                PhotoPath = "images/john.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBirth = new DateTime(1988, 6, 8),
                Gender = Gender.Male,
                DepartamentId = 1,
                PhotoPath = "images/sam.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Jonson",
                Email = "Mary@pragimtech.com",
                DateOfBirth = new DateTime(1985, 9, 10),
                Gender = Gender.Male,
                DepartamentId = 2,
                PhotoPath = "images/mary.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Stefany",
                LastName = "Kane",
                Email = "Stef@pragimtech.com",
                DateOfBirth = new DateTime(1992, 12, 1),
                Gender = Gender.Male,
                DepartamentId = 3,
                PhotoPath = "images/stefany.jpg"
            });
        }
    }
}
