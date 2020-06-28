namespace EmployeeManagement.Api.Repositories
{
    using EmployeeManagement.Api.Models;
    using EmployeeManagement.Api.Repositories.Contracts;
    using EmployeeManagement.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class DepartamentRepository : IDepartamentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartamentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Departament> GetDepartamentAsync(int departamentId)
        {
            var result = await this.appDbContext.Departaments.FirstOrDefaultAsync(d => d.DepartamentId == departamentId);

            return result;
        }

        public async Task<IEnumerable<Departament>> GetDepartamentsAsync()
        {
            var result = await this.appDbContext.Departaments.ToListAsync();

            return result;
        }
    }
}
