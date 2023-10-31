using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Models;

namespace TrackerLab.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var userId = "757b2158-40c3-4917-9523-5861973a4d2e";
            var userId2 = "42e5f9c6-78a1-4ec1-bdc8-105f43d791ca";

            var users = new List<IdentityUser>
            {
                new IdentityUser { Id = userId, Email = "mainul@gmail.com", NormalizedEmail = "MAINUL@GMAIL.COM", UserName = "mainul@gmail.com", NormalizedUserName = "MAINUL@GMAIL.COM"},
                new IdentityUser { Id = userId2, Email = "csmainul@gmail.com", UserName= "csmainul@gmail.com", NormalizedEmail="CSMAINUL@GMAIL.COM", NormalizedUserName ="CSMAINUL@GMAIL.COM" }
            }.AddPasswordHash();

            builder.Entity<IdentityUser>().HasData(users);

            builder.Entity<Project>().HasData(
                    new Project { Id = 1, Title = "TrackerLab" },
                    new Project { Id = 2, Title = "Plannial" },
                    new Project { Id = 3, Title = "SweatSpace" }
                );

            builder.Entity<ProjectUser>().HasData(
                new ProjectUser { ProjectId = 1, UserId = userId },
                new ProjectUser { ProjectId = 2, UserId = userId },
                new ProjectUser { ProjectId = 3, UserId = userId2 }
                );

            builder.Entity<Issue>().HasData(
                   new Issue { Id = 1, Title = "Implement project controllers", ProjectId = 1, CreatedById = userId, IssueTypeId = 3 },
                    new Issue { Id = 2, Title = "update project title", Description = "Better domaine events pattern", ProjectId = 1, CreatedById = userId, IssueTypeId = 1 },
                    new Issue { Id = 3, Title = "How you doing?", ProjectId = 2, CreatedById = userId2, IssueTypeId = 1 }
                    );

            builder.Entity<Comment>().HasData(
                new { Id = 1, Text = "This has been implemented", Created = DateTime.UtcNow, IssueId = 1, CreatedById = userId },
                new { Id = 2, Text = "Nope", Created = DateTime.UtcNow, IssueId = 1, CreatedById = userId },
                new { Id = 3, Text = "Any progress?", Created = DateTime.UtcNow, IssueId = 2, CreatedById = userId2 }
                );

            builder.Entity<IssueType>().HasData(
                new IssueType { Id = 1, ProjectId = 1, Title = "refactor", Color = "#977FE4" },
                new IssueType { Id = 2, ProjectId = 1, Title = "Issue", Color = "#b14639ff" },
                new IssueType { Id = 3, ProjectId = 1, Title = "feature", Color = "#35ceceff" },
                new IssueType { Id = 4, ProjectId = 2, Title = "feature", Color = "#35ceceff" },
                new IssueType { Id = 5, ProjectId = 2, Title = "Issue", Color = "#b14639ff" },
                new IssueType { Id = 6, ProjectId = 2, Title = "refactor", Color = "#977FE4" }
                );
        }

        private static List<IdentityUser> AddPasswordHash(this List<IdentityUser> users)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, "PW123456");
            }

            return users;
        }
    }
}
