namespace EmployeeManagement.Services.Data.Contracts
{
    using EmployeeManagement.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeAsync(int id);

        Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee);

        Task<Employee> CreateEmployeeAsync(Employee newEmployee);
    }
}
