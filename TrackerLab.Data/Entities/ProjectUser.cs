using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Data.Models
{
    public class ProjectUser
    {
        public int ProjectId { get; init; }
        public string? UserId { get; init; }
        public IdentityUser? User { get; init; }
    }
}
