using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IChangeTypeRepository : IRepository<OChangeType>
    {
        new List<OChangeType> GetAll();
        List<OChangeType> GetByCode(string code);
        List<OChangeType> GetByName(string name);
        List<OChangeType> GetByCodeOrName(string code, string name);
        bool IsCodeDuplicated(Guid objId, string code);
    }
}