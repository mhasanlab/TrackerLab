using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Responses
{
    public class ProjectResponse
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public int TotalIssues { get; set; }
        public int TotalHighPriorityIssues { get; set; }
    }
}
