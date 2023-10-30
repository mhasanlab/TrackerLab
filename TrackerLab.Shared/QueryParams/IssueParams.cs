using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Shared.Enums;

namespace TrackerLab.Shared.QueryParams
{
    public class IssueParams : PaginationParams
    {
        public int? ProjectId { get; set; }
        public IssueSortBy SortBy { get; set; }
        public SortOrder SortOrder { get; set; }
        public string? Title { get; set; }
    }
}
