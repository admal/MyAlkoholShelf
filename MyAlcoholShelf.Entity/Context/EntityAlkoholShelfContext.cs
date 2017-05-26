using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class EntityAlkoholShelfContext : DbContext
    {
        public EntityAlkoholShelfContext(DbContextOptions options) : base(options)
        {
        }


        private void RegisterMaps(ModelBuilder builder)
        {
            var maps = typeof(EntityAlkoholShelfContext).GetTypeInfo().Assembly.DefinedTypes
                .Where(type => 
                    !string.IsNullOrWhiteSpace(type.Namespace) && 
                    type.IsClass && 
                    !type.IsAbstract &&
                    typeof(IEntityMap).GetTypeInfo().IsAssignableFrom(type))
                .ToList();

            foreach (var item in maps)
                Activator.CreateInstance(item.AsType(),  new object[] { builder });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            RegisterMaps(builder);

            base.OnModelCreating(builder);
        }
    }
}
