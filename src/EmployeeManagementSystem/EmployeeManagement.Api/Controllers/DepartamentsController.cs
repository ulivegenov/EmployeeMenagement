namespace EmployeeManagement.Api.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EmployeeManagement.Api.Repositories.Contracts;
    using EmployeeManagement.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentsController : ControllerBase
    {
        private readonly IDepartamentRepository departamentRepository;

        public DepartamentsController(IDepartamentRepository departamentRepository)
        {
            this.departamentRepository = departamentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartaments()
        {
            try
            {
                return Ok(await this.departamentRepository.GetDepartamentsAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Departament>> GetDepartament(int id)
        {
            try
            {
                var result = await this.departamentRepository.GetDepartamentAsync(id);

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
    }
}
