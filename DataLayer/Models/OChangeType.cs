using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class OChangeType : PclaAuditObjectBase
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public OChangeType()
            : base()
        {
            this.Code = String.Empty;
            this.Name = String.Empty;
        }
    }
}
