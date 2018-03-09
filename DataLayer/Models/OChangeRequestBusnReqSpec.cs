using System;

namespace DataLayer.Models
{
    public class OChangeRequestBusnReqSpec : PclaAuditObjectBase
    {
        public Guid? ChangeRequestId { get; set; }
        public String RequirementId { get; set; }
        public String RequirementDesc { get; set; }
        public int Priority { get; set; }

        public OChangeRequest ChangeRequest { get; set; }

        public OChangeRequestBusnReqSpec()
            : base()
        {

        }
    }
}
