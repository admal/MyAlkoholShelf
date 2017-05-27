using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAlkoholShelf.Entity
{
    public static class AlkoholInstanceExtensions
    {
        public static IQueryable<AlkoholInstance> WhereAlkoholInstancesForUser(this IQueryable<AlkoholInstance> query,
            long userId)
        {
            return query.Where(x => x.AlkoholRecipe.AlkoholRecipeDefinition.CreatedBy.Id == userId);
        }
    }
}
