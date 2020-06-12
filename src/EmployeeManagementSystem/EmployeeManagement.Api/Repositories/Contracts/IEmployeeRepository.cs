namespace EmployeeManagement.Api.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EmployeeManagement.Models;
    using EmployeeManagement.Models.Enums;

    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeAsync(int employeeId);

        Task<Employee> GetEmployeeByEmailAsync(string email);

        Task<Employee> AddEmployeeAsync(Employee employee);

        Task<Employee> UpdatemployeeAsync(Employee employee);

        Task<Employee> DeleteEmployeeAsync(int employeeId);

        Task<IEnumerable<Employee>> SearchAsync(string name, Gender? gender);
    }
}
