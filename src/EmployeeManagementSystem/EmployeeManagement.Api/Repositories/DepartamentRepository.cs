namespace EmployeeManagement.Api.Repositories
{
    using EmployeeManagement.Api.Models;
    using EmployeeManagement.Api.Repositories.Contracts;
    using EmployeeManagement.Models;
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

        public Departament GetDepartament(int departamentId)
        {
            var result = this.appDbContext.Departaments.FirstOrDefault(d => d.DepartamentId == departamentId);

            return result;
        }

        public IEnumerable<Departament> GetDepartaments()
        {
            var result = this.appDbContext.Departaments;

            return result;
        }
    }
}
