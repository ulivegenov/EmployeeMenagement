namespace EmployeeManagement.Api.Controllers
{
    using EmployeeManagement.Api.Repositories.Contracts;
    using EmployeeManagement.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
    }
}
