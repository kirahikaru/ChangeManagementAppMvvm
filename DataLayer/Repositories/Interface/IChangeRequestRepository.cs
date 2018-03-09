using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IChangeRequestRepository : IRepository<OChangeRequest>
    {
        List<OChangeRequest> SearchChangeRequest(string chgReqId, string rmfCrId, string title, string priority,
            Guid? pclaAppSysId, Guid? requestorId, Guid? itBaId, Guid? changeTypeId,
            DateTime? closeDateFrom, DateTime? closeDateTo,
            DateTime? reqDateFrom, DateTime? reqDateTo);

        bool IsChgReqIdDuplicated(Guid objId, string chgReqId);
    }
}