namespace EmployeeManagement.Models
{
    using System.ComponentModel.DataAnnotations;

    using EmployeeManagement.GlobalConstants;

    public class Departament
    {
        public int DepartamentId { get; set; }

        [Required]
        [StringLength(AttributeConstraints.NameMaxLength, MinimumLength = AttributeConstraints.NameMinLength)]
        public string DepartamentName { get; set; }
    }
}
