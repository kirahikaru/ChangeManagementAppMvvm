using System;

namespace DataLayer.Models
{
    public class OChangeRequestActivity : PclaObjectBase
    {
        public Guid ChangeRequestId { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public Guid? ActivityTypeId { get; set; }

        public OActivityType ActivityType { get; set; }
        public OChangeRequest ChangeRequest { get; set; }

        public OChangeRequestActivity()
            : base()
        {
        }
    }
}
