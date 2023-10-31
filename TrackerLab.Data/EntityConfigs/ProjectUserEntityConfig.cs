using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Models;

namespace TrackerLab.Data.EntityConfigs
{
    public class ProjectUserEntityConfig : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProjectId });

            builder.HasOne<Project>()
                .WithMany()
                .HasForeignKey(x => x.ProjectId);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

        }
    }
}
