using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    // PL Klasa Abstrakcyjna AuditableEntity.
    // EN The AuditableEntity abstract class. 
    public abstract class AuditableEntity
    {
        // PL Inicjacja właściwości klasy AuditableEntity.
        // EN Initialization of the AuditableEntity class property.
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
