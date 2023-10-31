using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Models;
using TrackerLab.Data.Extensions;

namespace TrackerLab.Data.EntityConfigs
{
    public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ConfigureAudit();

            builder.ToTable("Comments");

            builder.Property(x => x.Text)
                .IsRequired();
        }
    }
}
