using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Models;
using TrackerLab.Data.Extensions;
using TrackerLab.Data.Helpers;

namespace TrackerLab.Data
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly string _currentUserId;
        private readonly IDateProvider _dateProvider;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDateProvider dateProvider, IHttpContextAccessor httpContext = null) : base(options)
        {
            _dateProvider = dateProvider;
            _currentUserId = httpContext?.HttpContext?.User?.UserId();
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            builder.Seed();
        }

      
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CreateAuditTrail();
            try
            {
                ChangeTracker.AutoDetectChangesEnabled = false;
                return await base.SaveChangesAsync(cancellationToken);
            }
            finally
            {
                ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        private void CreateAuditTrail()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntitie>())
            {
                var currentTime = _dateProvider.UtcDate;

                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.SetProperty(x => x.Modified, currentTime);
                        entry.SetProperty(x => x.ModifiedById, _currentUserId);

                        if (entry.Entity.Deleted?.AddMinutes(5) > currentTime)
                        {
                            entry.SetProperty(x => x.DeletedById, _currentUserId);
                        }

                        break;

                    case EntityState.Added:

                        entry.SetProperty(x => x.Created, currentTime);
                        entry.SetProperty(x => x.CreatedById, _currentUserId);
                        break;
                }
            }
        }
    }
}
