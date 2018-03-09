using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class PclaAppSysRepository : Repository<OPclaAppSys>, IPclaAppSysRepository
    {
        public PclaAppSysRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public new List<OPclaAppSys> GetAll()
        {
            return _dbContext.PclaSysApps.Where(c => c.IsDeleted == false).ToList();
        }

        public List<OPclaAppSys> GetByCode(string code)
        {
            return _dbContext.PclaSysApps.Where(c => c.Code.ToUpper() == code.ToUpper() && c.IsDeleted == false).ToList();
        }

        public List<OPclaAppSys> GetByName(string name)
        {
            return _dbContext.PclaSysApps.Where(c => c.IsDeleted == false && c.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<OPclaAppSys> GetByCodeOrName(string code, string name)
        {
            return _dbContext.PclaSysApps.Where(c => c.IsDeleted == false && (c.Code.ToUpper().Contains(code.ToUpper()) || c.Name.ToLower().Contains(name.ToLower()))).ToList();
        }

        public bool IsCodeDuplicated(Guid objId, string code)
        {
            return _dbContext.PclaSysApps.Count(x => x.IsDeleted == false && x.Id != objId && x.Code.ToUpper() == code.ToUpper()) > 0;
        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
