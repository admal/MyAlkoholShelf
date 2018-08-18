using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    [Obsolete]
    public class Ingredient_IngredientUnit : Entity
    {
        public virtual Ingredient Ingredient { get; set; }
        public virtual IngredientUnit IngredientUnit { get; set; }
    }

    public class Ingredient_IngredientUnitMapping : EntityClassMapping<Ingredient_IngredientUnit>
    {
        public Ingredient_IngredientUnitMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<Ingredient_IngredientUnit>(b =>
            {
                b.HasOne(x => x.Ingredient).WithMany(x => x.IngredientUnits);
                b.HasOne(x => x.IngredientUnit).WithMany(x => x.Ingredients);
            });
        }
    }
}
