using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class Ingredient : UserVersionedEntity
    {
        public virtual string Name { get; set; }
        public virtual ISet<Ingredient_IngredientUnit> IngredientUnits { get; set; }
    }

    public class IngredientMapping : EntityClassMapping<Ingredient>
    {
        public IngredientMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<Ingredient>(b =>
            {
                b.Property(x => x.CreatedTime);
                b.Property(x => x.ModifiedTime);
                b.Property(x => x.Name);
                b.HasOne(x => x.CreatedBy).WithMany(x => x.Ingredients);
                b.HasMany(x => x.IngredientUnits).WithOne(x => x.Ingredient);
            });
        }
    }
}
