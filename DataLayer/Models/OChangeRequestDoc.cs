using System;

namespace DataLayer.Models
{
    public class OChangeRequestDoc : PclaAuditObjectBase
    {
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public string DocOwner { get; set; }
        public string DocPath { get; set; }
        public Guid? ChgReqId { get; set; }

        public OChangeRequest ChangeRequest { get; set; }
    }
}
