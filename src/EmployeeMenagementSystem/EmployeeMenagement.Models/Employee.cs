﻿namespace EmployeeManagement.Models
{
    using System;

    using EmployeeManagement.Models.Enums;

    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int DepartamentId { get; set; }

        public string PhotoPath { get; set; }
    }
}
