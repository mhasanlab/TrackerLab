using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Data.Models
{
    public abstract class AuditableEntitie
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public string? ModifiedById { get; set; }
        public IdentityUser? ModifiedBy { get; set; }
        public string? DeletedById { get; set; }
        public IdentityUser? DeletedBy { get; set; }
    }
}
