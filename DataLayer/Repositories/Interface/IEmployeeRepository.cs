using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IEmployeeRepository : IRepository<OEmployee>
    {
        List<OEmployee> GetByEmpId(string empId);
        List<OEmployee> GetByName(string name);
        List<OEmployee> SearchEmployee(string empId, string name, string dept, string function);
        Task<List<OEmployee>> SearchEmployeeAsync(string empId, string name, string dept, string function);
        bool IsEmpIdDuplicated(Guid objId, string empId);
    }
}