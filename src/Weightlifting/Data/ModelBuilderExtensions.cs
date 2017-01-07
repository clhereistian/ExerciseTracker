using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weightlifting.Data
{
    public static class ModelBuilderExtensions
    {
        public static void RemoveTableNamePlurals(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (entity.ClrType != null)
                {
                    entity.Relational().TableName = entity.ClrType.Name;
                }
            }
                
        }
    }
}
