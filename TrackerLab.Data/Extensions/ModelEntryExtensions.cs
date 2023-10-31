using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Data.Extensions
{
    public static class ModelEntryExtensions
    {
        public static void SetProperty<TEntity, TProperty>(this EntityEntry<TEntity> entry,
            Expression<Func<TEntity, TProperty>> propertyExpression,
            TProperty value)
            where TEntity : class
        {
            entry.Property(propertyExpression).CurrentValue = value;
        }
    }
}
