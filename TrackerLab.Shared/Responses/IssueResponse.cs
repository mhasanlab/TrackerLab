using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Enums;

namespace TrackerLab.Shared.Responses
{
    public class IssueResponse
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public IssuePriority Priority { get; init; }
        public IssueStatus Status { get; set; }
        public DateTime Created { get; init; }
        public DateTime? Modified { get; init; }
        public string? SprintTitle { get; init; }
        public int? SprintId { get; init; }
        public string? ProjectTitle { get; init; }
        public int ProjectId { get; init; }
        public IssueTypeResponse? IssueType { get; init; }
        public ICollection<CommentResponse> Comments { get; init; } = new List<CommentResponse>();
        public UserResponse? CreatedBy { get; init; }
        public UserResponse? ModifiedBy { get; init; }
        public UserResponse? AssignedTo { get; set; }
    }
}
