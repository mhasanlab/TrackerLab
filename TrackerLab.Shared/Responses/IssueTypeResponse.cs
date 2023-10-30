using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Responses
{
    public class IssueTypeResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Color { get; set; }
    }
}
