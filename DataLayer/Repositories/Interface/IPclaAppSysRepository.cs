using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IPclaAppSysRepository : IRepository<OPclaAppSys>
    {
        new List<OPclaAppSys> GetAll();
        List<OPclaAppSys> GetByCode(string code);
        List<OPclaAppSys> GetByName(string name);
        List<OPclaAppSys> GetByCodeOrName(string code, string name);
        bool IsCodeDuplicated(Guid objId, string code);
    }
}