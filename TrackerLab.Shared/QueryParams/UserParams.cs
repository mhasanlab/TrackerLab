using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.QueryParams
{
    public class UserParams : PaginationParams
    {
        public string? Email { get; set; }
        public int? NotInProjectId { get; set; }
    }
}
