using Microsoft.AspNetCore.Identity;
using TrackerLab.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Data.Models
{
    public class Issue : AuditableEntitie
    {
        public int Id { get; init; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public int ProjectId { get; init; }
        public Project? Project { get; private set; }
        public int IssueTypeId { get; set; }
        public IssueType? IssueType { get; private set; }
        public string? AssignedToId { get; set; }
        public IdentityUser? AssignedTo { get; private set; }
        public Sprint? Sprint { get; set; }
        public int? SprintId { get; set; }
        public ICollection<Comment> Comments { get; init; } = new List<Comment>();

    }
}
