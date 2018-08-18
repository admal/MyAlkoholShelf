using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    [Obsolete]
    public class IngredientUnit : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Symbol { get; set; }

        public virtual ISet<Ingredient_IngredientUnit> Ingredients { get; set; }
    }

    public class IngredientUnitMapping : EntityClassMapping<IngredientUnit>
    {
        public IngredientUnitMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<IngredientUnit>(b =>
            {
                b.Property(x => x.Name);
                b.Property(x => x.Symbol);
                b.HasMany(x => x.Ingredients).WithOne(x => x.IngredientUnit);
            });
        }
    }
}
