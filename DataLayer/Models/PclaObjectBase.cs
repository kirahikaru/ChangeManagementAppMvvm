using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PclaObjectBase
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime SysTimestamp { get; set; }

        public PclaObjectBase()
        {
            this.Id = Guid.NewGuid();
            this.IsDeleted = false;
            this.SysTimestamp = DateTime.Now;
        }
    }
}
