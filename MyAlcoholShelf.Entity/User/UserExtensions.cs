using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlkoholShelf.Entity
{
    public static class UserExtensions
    {
        public static IQueryable<UserVersionedEntity> WhereUserEntities(this IQueryable<UserVersionedEntity> entities, User user)
        {
            return entities.Where(x => x.CreatedBy == user);
        }
        public static IQueryable<UserVersionedEntity> WhereUserEntities(this IQueryable<UserVersionedEntity> entities, long userId)
        {
            return entities.Where(x => x.CreatedBy.Id == userId);
        }

    }
}
