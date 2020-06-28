namespace EmployeeManagement.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EmployeeManagement.GlobalConstants;
    using EmployeeManagement.Models.Enums;

    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(AttributeConstraints.NameMaxLength, MinimumLength = AttributeConstraints.NameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(AttributeConstraints.NameMaxLength, MinimumLength = AttributeConstraints.NameMinLength)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int DepartamentId { get; set; }

        public Departament Departament { get; set; }

        public string PhotoPath { get; set; }
    }
}
