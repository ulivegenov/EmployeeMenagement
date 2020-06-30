namespace EmployeeManagement.Api.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EmployeeManagement.Api.Models;
    using EmployeeManagement.Api.Repositories.Contracts;
    using EmployeeManagement.Models;
    using EmployeeManagement.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = await this.appDbContext.AddAsync(employee);

            await this.appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Employee> DeleteEmployeeAsync(int employeeId)
        {
            var result = await this.appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (result != null)
            {
                this.appDbContext.Employees.Remove(result);
                await this.appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var result = await this.appDbContext.Employees
                                                .Where(e => e.EmployeeId == employeeId)
                                                .Select(e => new Employee 
                                                {
                                                    EmployeeId = e.EmployeeId,
                                                    FirstName = e.FirstName,
                                                    LastName = e.LastName,
                                                    DateOfBirth = e.DateOfBirth,
                                                    Email = e.Email,
                                                    PhotoPath = e.PhotoPath,
                                                    Gender = e.Gender,
                                                    DepartamentId = e.DepartamentId,
                                                    Departament = new Departament
                                                    {
                                                        DepartamentId = e.DepartamentId,
                                                        DepartamentName = e.Departament.DepartamentName,
                                                    },
                                                })
                                                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            var result = await this.appDbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);

            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var result = await this.appDbContext.Employees.ToListAsync();

            return result;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var result = await this.appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            //TODO: USE AUTOMAPPER!
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartamentId = employee.DepartamentId;
                result.PhotoPath = employee.PhotoPath;

                await this.appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string name, Gender? gender)
        {
            IQueryable<Employee> query = this.appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                                    || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
