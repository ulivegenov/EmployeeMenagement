namespace EmployeeManagement.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EmployeeManagement.GlobalConstants;
    using EmployeeManagement.Models;
    using EmployeeManagement.Models.Enums;

    public class EmployeeFormModel
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

        [Compare("Email", ErrorMessage = "Email and Confirm Email  must match")]
        public string ConfirmEmail { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int DepartamentId { get; set; }

        public Departament Departament { get; set; }

        public string PhotoPath { get; set; }
    }
}
