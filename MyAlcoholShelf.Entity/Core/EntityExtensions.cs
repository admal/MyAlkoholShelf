using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlkoholShelf.Entity
{
    public static class EntityExtensions
    {
        public static IQueryable<T> WhereNotDeleted<T>(this IQueryable<T> entities) where T : Entity, ISoftDeletable
        {
            return entities.Where(x => !x.IsDeleted);
        }
    }
}
