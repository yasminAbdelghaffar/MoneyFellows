using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class AuditEntity
    {
        public string CreatedBy { set; get; }
        public DateTime CreationDate { set; get; }
        public string LastModifiedBy { set; get; }
        public DateTime LastModifiedDate { set; get; }
    }
}
