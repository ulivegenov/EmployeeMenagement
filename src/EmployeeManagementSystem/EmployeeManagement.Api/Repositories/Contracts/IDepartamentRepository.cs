﻿namespace EmployeeManagement.Api.Repositories.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeManagement.Models;

    public interface IDepartamentRepository
    {
        Task<IEnumerable<Departament>> GetDepartamentsAsync();

        Task<Departament> GetDepartamentAsync(int departamentId);
    }
}
