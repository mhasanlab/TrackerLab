using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Responses
{
    public class DashboardResponse
    {
        public int TotalOpenIssues { get; set; }
        public int TotalInProgressIssues { get; set; }
        public int TotalHighPrioritizedOpenIssues { get; set; }
        public int TotalIssuesAssignedToMe { get; set; }
        public IssueResponse? LatestIssue { get; set; }
        public IssueResponse? LatestUpdatedIssue { get; set; }
    }
}
