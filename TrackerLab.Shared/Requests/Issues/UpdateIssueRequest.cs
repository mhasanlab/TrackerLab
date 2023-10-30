using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Enums;

namespace TrackerLab.Shared.Requests.Issues
{
    public class UpdateIssueRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public int TypeId { get; set; }
        public string? AssignedToId { get; set; }
        public int? SprintId { get; set; }
    }
}
