using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data.Models;

namespace TrackerLab.Data.Extensions
{
    public static class EntityConfigurationExtensions
    {
        public static void ConfigureAudit<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : AuditableEntitie
        {
            builder.HasIndex(x => x.Deleted);

            builder.HasOne(x => x.CreatedBy)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.CreatedById);

            builder.HasOne(x => x.ModifiedBy)
              .WithMany()
              .HasForeignKey(x => x.ModifiedById);

            builder.HasOne(x => x.DeletedBy)
                .WithMany()
                .HasForeignKey(x => x.DeletedById);

            builder.HasQueryFilter(x => !x.Deleted.HasValue);
        }
    }
}
