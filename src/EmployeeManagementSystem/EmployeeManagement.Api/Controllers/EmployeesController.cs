namespace EmployeeManagement.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EmployeeManagement.Api.Repositories.Contracts;
    using EmployeeManagement.Models;
    using EmployeeManagement.Models.Enums;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Internal;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await this.employeeRepository.GetEmployeesAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await this.employeeRepository.GetEmployeeAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                // TODO : EXTRACT VALIDATION CODE INTO A SEPARATE METHOD!
                if (employee == null)
                {
                    return BadRequest();
                }

                var emp = await this.employeeRepository.GetEmployeeByEmailAsync(employee.Email);

                if (emp != null)
                {
                    ModelState.AddModelError("email", "This email already in use!");

                    return BadRequest(ModelState);
                }

                var createdEmployee = await this.employeeRepository.AddEmployeeAsync(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                // TODO : EXTRACT VALIDATION CODE INTO A SEPARATE METHOD!
                var employeeToUpdate = await this.employeeRepository.GetEmployeeAsync(employee.EmployeeId);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Empolyee with Id {employee.EmployeeId} not found!");
                }

                return await this.employeeRepository.UpdateEmployeeAsync(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                // TODO : EXTRACT VALIDATION CODE INTO A SEPARATE METHOD!
                var employeeToDelete = await this.employeeRepository.GetEmployeeAsync(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Empolyee with Id {id} not found!");
                }

                return await this.employeeRepository.DeleteEmployeeAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data!");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<Employee>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await this.employeeRepository.SearchAsync(name, gender);

                if (result.Any())
                {
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }
    }
}
