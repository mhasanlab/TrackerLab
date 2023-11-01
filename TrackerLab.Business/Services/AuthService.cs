using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Business.Interfaces;
using TrackerLab.Data;

namespace TrackerLab.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task HasAccessToProject(string userId, int projectId)
        {
            var userIsInProject = await _context.ProjectUsers.AnyAsync(pu => pu.ProjectId == projectId && pu.UserId == userId);

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }

        public async Task HasAccessToIssue(string userId, int issueId)
        {
            var userIsInProject = await _context.ProjectUsers.AnyAsync(pu => pu.UserId == userId
                                                                             && pu.ProjectId == _context.Issues.FirstOrDefault(b => b.Id == issueId).ProjectId);

            if (!userIsInProject)
            {
                throw new UnauthorizedAccessException("You are not part of this project");
            }
        }

    }
}
