namespace EmployeeManagement.Services.Data.Contracts
{
    using EmployeeManagement.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int id);
    }
}
