namespace EmployeeManagement.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;

    using Microsoft.AspNetCore.Components;

    public class DepartamentService : IDepartamentService
    {
        private readonly HttpClient httpClient;

        public DepartamentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Departament> GetDepartamentAsync(int id)
        {
            return await this.httpClient.GetJsonAsync<Departament>($"api/departaments/{id}");
        }

        public async Task<IEnumerable<Departament>> GetDepartamentsAsync()
        {
            return await this.httpClient.GetJsonAsync<Departament[]>("api/departaments");
        }
    }
}
