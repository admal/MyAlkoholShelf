using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class User_IngredientUnit : Entity
    {
        public virtual User User { get; set; }
        public virtual IngredientUnit IngredientUnit { get; set; }
    }

    public class User_IngredientUnitMapping : EntityClassMapping<User_IngredientUnit>
    {
        public User_IngredientUnitMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<User_IngredientUnit>(b =>
            {
                b.HasOne(x => x.IngredientUnit).WithMany(x => x.Users);
                b.HasOne(x => x.User).WithMany(x => x.UserIngredients);
            })
        }
    }
}
