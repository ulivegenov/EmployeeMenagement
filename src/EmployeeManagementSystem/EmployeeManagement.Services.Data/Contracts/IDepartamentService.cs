namespace EmployeeManagement.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EmployeeManagement.Models;

    public interface IDepartamentService
    {
        Task<IEnumerable<Departament>> GetDepartamentsAsync();

        Task<Departament> GetDepartamentAsync(int id);
    }
}
