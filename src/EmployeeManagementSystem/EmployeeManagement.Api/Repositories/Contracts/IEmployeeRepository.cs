namespace EmployeeManagement.Api.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EmployeeManagement.Models;
    

    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int employeeId);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> Updatemployee(Employee employee);

        void DeleteEmployee(int employeeId);
    }
}
