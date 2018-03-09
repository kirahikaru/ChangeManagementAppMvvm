using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ActivityTypeRepository : Repository<OActivityType>, IActivityTypeRepository
    {
        public ActivityTypeRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public List<OActivityType> GetByCode(string code)
        {
            return _dbContext.ActivityTypes.Where(c => c.Code.ToUpper() == code.ToUpper() && c.IsDeleted == false).ToList();
        }

        public List<OActivityType> GetByName(string name)
        {
            return _dbContext.ActivityTypes.Where(c => c.IsDeleted == false && c.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<OActivityType> GetByCodeOrName(string code, string name)
        {
            return _dbContext.ActivityTypes.Where(c => c.IsDeleted == false && (c.Code.ToUpper().Contains(code.ToUpper()) || c.Name.ToLower().Contains(name.ToLower()))).ToList();
        }

        public bool IsCodeDuplicated(Guid objId, string code)
        {
            return _dbContext.ActivityTypes.Count(x => x.IsDeleted == false && x.Id != objId && x.Code == code) > 0;
        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
