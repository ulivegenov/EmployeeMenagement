namespace EmployeeManagement.Services.Data
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;
    
    using Microsoft.AspNetCore.Components;

    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            return await this.httpClient.PostJsonAsync<Employee>("api/employees", newEmployee);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await this.httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await this.httpClient.GetJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee)
        {
            return await this.httpClient.PutJsonAsync<Employee>("api/employees", updatedEmployee);
        }
    }
}
