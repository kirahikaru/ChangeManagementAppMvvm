using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EmployeeRepository : Repository<OEmployee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        /// <summary>
        /// Get employee by employee ID
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public List<OEmployee> GetByEmpId(string empId)
        {
            if (String.IsNullOrEmpty(empId) || empId.Trim().Length == 0)
                return new List<OEmployee>();

            return _dbContext.Employees.Where(c => c.EmployeeID.ToUpper() == empId.ToUpper() && c.IsDeleted == false).ToList();
        }

        /// <summary>
        /// Query employee by employee name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<OEmployee> GetByName(string name)
        {
            if (String.IsNullOrEmpty(name) || name.Trim().Length == 0)
                return new List<OEmployee>();

            return _dbContext.Employees.Where(c => c.IsDeleted == false && c.Fullname.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<OEmployee> SearchEmployee(string empId, string name, string dept, string function)
        {
            var condition = PredicateBuilder.Create<OEmployee>(c => c.IsDeleted == false);

            if (!String.IsNullOrWhiteSpace(empId) && empId.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.EmployeeID.ToUpper() == empId.Trim().ToUpper());

            if (!String.IsNullOrWhiteSpace(name) && name.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.Fullname.ToLower().Contains(name.ToLower()));

            if (!String.IsNullOrWhiteSpace(dept) && dept.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.Department.ToLower() == dept.Trim().ToLower());

            if (!String.IsNullOrWhiteSpace(function) && function.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.Function.ToLower() == function.Trim().ToLower());

            return _dbContext.Employees.Where(condition).ToList();
        }

        public Task<List<OEmployee>> SearchEmployeeAsync(string empId, string name, string dept, string function)
        {
            var condition = PredicateBuilder.Create<OEmployee>(c => c.IsDeleted == false);

            if (!String.IsNullOrWhiteSpace(empId) && empId.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.EmployeeID == empId.Trim());

            if (!String.IsNullOrWhiteSpace(name) && name.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.Fullname.ToLower().Contains(name.Trim().ToLower()));

            if (!String.IsNullOrWhiteSpace(dept) && dept.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.Department.ToLower() == dept.Trim().ToLower());

            if (!String.IsNullOrWhiteSpace(function) && function.Trim().Length > 0)
                condition = condition.And<OEmployee>(c => c.Function.ToLower() == function.Trim().ToLower());

            return _dbContext.Employees.Where(condition).ToListAsync();
        }

        public bool IsEmpIdDuplicated(Guid objId, string empId)
        {
            return _dbContext.Employees.Count(x => x.IsDeleted == false && x.Id != objId && x.EmployeeID.ToUpper() == empId.ToUpper()) > 0;
        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
