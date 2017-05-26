using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class AlkoholRecipe_Ingredient : Entity
    {
        public virtual AlkoholRecipe AlkoholRecipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual int Quantity { get; set; }
    }

    public class AlkoholRecipe_IngredientMapping : EntityClassMapping<AlkoholRecipe_Ingredient>
    {
        public AlkoholRecipe_IngredientMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<AlkoholRecipe_Ingredient>(b =>
            {
                b.Property(x => x.Quantity);
                b.HasOne(x => x.AlkoholRecipe).WithMany(x => x.Ingredients).HasForeignKey(x => x.Id);
                b.HasOne(x => x.Ingredient);
            });
        }
    }
}
