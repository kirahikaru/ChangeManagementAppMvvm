using DataLayer.EntityFrameworkDAL;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class ChangeRequestRepository : Repository<OChangeRequest>, IChangeRequestRepository
    {
        public ChangeRequestRepository(DatabaseContext dbContext)
            : base(dbContext)
        {

        }

        public List<OChangeRequest> SearchChangeRequest(string chgReqId, string rmfCrId, string title, string priority,
            Guid? pclaAppSysId, Guid? requestorId, Guid? itBaId, Guid? changeTypeId,
            DateTime? closeDateFrom, DateTime? closeDateTo,
            DateTime? reqDateFrom, DateTime? reqDateTo)
        {
            var condition = PredicateBuilder.Create<OChangeRequest>(c => c.IsDeleted == false);

            if (!String.IsNullOrEmpty(chgReqId) && chgReqId.Trim().Length > 0)
                condition = condition.And<OChangeRequest>(c => c.ChgReqID == chgReqId.Trim());

            if (!String.IsNullOrEmpty(rmfCrId) && rmfCrId.Trim().Length > 0)
                condition = condition.And<OChangeRequest>(c => c.RemedyForceId == rmfCrId.Trim());

            if (!String.IsNullOrEmpty(title) && title.Length > 0)
                condition = condition.And<OChangeRequest>(c => c.Title.ToLower().Contains(title.ToLower()));

            if (!String.IsNullOrEmpty(priority))
                condition = condition.And<OChangeRequest>(c => c.Priority == priority);

            if (pclaAppSysId.HasValue)
                condition = condition.And<OChangeRequest>(c => c.PclaAppSysId == pclaAppSysId.Value);

            if (requestorId.HasValue)
                condition = condition.And<OChangeRequest>(c => c.RequestorId == requestorId.Value);

            if (itBaId.HasValue)
                condition = condition.And<OChangeRequest>(c => c.ITBusnAnalystId == itBaId.Value);

            if (changeTypeId.HasValue)
                condition = condition.And<OChangeRequest>(c => c.ChangeTypeId == changeTypeId.Value);

            if (closeDateFrom.HasValue)
                condition = condition.And<OChangeRequest>(c => c.CloseDate != null && c.CloseDate.Value.Date >= closeDateFrom.Value.Date);

            if (closeDateTo.HasValue)
                condition = condition.And<OChangeRequest>(c => c.CloseDate != null && c.CloseDate.Value.Date <= closeDateTo.Value.Date);

            if (reqDateFrom.HasValue)
                condition = condition.And<OChangeRequest>(c => c.RequestDate != null && c.RequestDate.Value.Date >= reqDateFrom.Value.Date);

            if (reqDateTo.HasValue)
                condition = condition.And<OChangeRequest>(c => c.RequestDate != null && c.RequestDate.Value.Date <= reqDateTo.Value.Date);

            return _dbContext.ChangeRequests.Where(condition).ToList();
        }

        public bool IsChgReqIdDuplicated(Guid objId, string chgReqId)
        {
            return _dbContext.ChangeRequests.Count(x => x.IsDeleted == false && x.Id != objId && x.ChgReqID == chgReqId) > 0;
        }

        public DatabaseContext DbContext
        {
            get { return _dbContext as DatabaseContext; }
        }
    }
}
