using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IActivityTypeRepository : IRepository<OActivityType>
    {
        List<OActivityType> GetByCode(string code);
        List<OActivityType> GetByName(string name);
        List<OActivityType> GetByCodeOrName(string code, string name);
        bool IsCodeDuplicated(Guid objId, string code);
    }
}