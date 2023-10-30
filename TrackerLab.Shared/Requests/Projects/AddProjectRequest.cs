using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Requests.Projects
{
    public class AddProjectRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
