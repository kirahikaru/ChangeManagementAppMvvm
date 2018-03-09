using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ChangeTypeRepository : Repository<OChangeType>, IChangeTypeRepository
    {
        public ChangeTypeRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public new List<OChangeType> GetAll()
        {
            return _dbContext.ChangeTypes.Where(c => c.IsDeleted == false).ToList();
        }

        public List<OChangeType> GetByCode(string code)
        {
            return _dbContext.ChangeTypes.Where(c => c.Code.ToUpper() == code.ToUpper() && c.IsDeleted == false).ToList();
        }

        public List<OChangeType> GetByName(string name)
        {
            return _dbContext.ChangeTypes.Where(c => c.IsDeleted == false && c.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<OChangeType> GetByCodeOrName(string code, string name)
        {
            return _dbContext.ChangeTypes.Where(c => c.IsDeleted == false && (c.Code.ToUpper().Contains(code.ToUpper()) || c.Name.ToLower().Contains(name.ToLower()))).ToList();
        }

        public bool IsCodeDuplicated(Guid objId, string code)
        {
            return _dbContext.ChangeTypes.Count(x => x.IsDeleted == false && x.Id != objId && x.Code == code) > 0;
        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
