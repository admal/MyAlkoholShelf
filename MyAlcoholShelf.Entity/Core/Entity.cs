using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public interface IEntityMap
    {

    }
    public abstract class Entity
    {
        public virtual long Id { get; set; }
    }

    public abstract class EntityClassMapping<T> : IEntityMap where T : Entity
    {
        public EntityClassMapping(ModelBuilder builder)
        {
            builder.Entity<T>(b =>
            {
                var name = typeof(T).Name;
                b.ToTable(name);
                b.HasKey(e => e.Id);
            });
        }
    }

    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }

    public abstract class VersionedEntity : Entity
    {
        public VersionedEntity()
        {
            CreatedTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }
        
        public virtual DateTime CreatedTime { get; set; }
        public virtual DateTime ModifiedTime { get; set; }
    }
}
