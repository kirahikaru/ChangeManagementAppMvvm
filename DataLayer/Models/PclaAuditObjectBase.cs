using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PclaAuditObjectBase
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CrtUsrName { get; set; }
        public DateTime CrtDateTime { get; set; }
        public string MdfUsrName { get; set; }
        public DateTime MdfDateTime { get; set; }

        public PclaAuditObjectBase()
        {
            this.Id = Guid.NewGuid();
            this.IsDeleted = false;
            this.CrtUsrName = Environment.UserName;
            this.CrtDateTime = DateTime.Now;
            this.MdfUsrName = Environment.UserName;
            this.MdfDateTime = DateTime.Now;
        }
    }
}
