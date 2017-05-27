using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlkoholShelf.Entity
{
    public static class UserExtensions
    {
        public static IQueryable<T> WhereUserEntities<T>(this IQueryable<T> entities, User user) where T : UserVersionedEntity
        {
            return entities.Where(x => x.CreatedBy == user);
        }
        public static IQueryable<T> WhereUserEntities<T>(this IQueryable<T> entities, long userId) where T : UserVersionedEntity
        {
            return entities.Where(x => x.CreatedBy.Id == userId);
        }

    }
}
