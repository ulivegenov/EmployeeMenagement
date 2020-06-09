namespace EmployeeManagement.Api.Repositories.Contracts
{
    using System.Collections.Generic;

    using EmployeeManagement.Models;

    public interface IDepartamentRepository
    {
        IEnumerable<Departament> GetDepartaments();

        Departament GetDepartament(int departamentId);
    }
}
