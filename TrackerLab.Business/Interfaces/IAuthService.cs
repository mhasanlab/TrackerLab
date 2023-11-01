using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Business.Interfaces
{
    public interface IAuthService
    {
        Task HasAccessToProject(string userId, int projectId);
        Task HasAccessToIssue(string userId, int id);
    }
}
