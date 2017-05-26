using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class IngredientUnit : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Symbol { get; set; }
        public virtual ISet<User_IngredientUnit> Users { get; set; }
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
                b.HasMany(x => x.Users).WithOne(x => x.IngredientUnit);
            })
        }
    }
}
