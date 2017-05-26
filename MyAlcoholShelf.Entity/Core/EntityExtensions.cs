using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlkoholShelf.Entity
{
    public static class EntityExtensions
    {
        public static IQueryable<ISoftDeletable> WhereNotDeleted(this IQueryable<ISoftDeletable> entities)
        {
            return entities.Where(x => !x.IsDeleted);
        }
    }
}
