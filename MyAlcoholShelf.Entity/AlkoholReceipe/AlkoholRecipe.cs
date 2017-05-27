using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class AlkoholRecipe : VersionedEntity, ISoftDeletable
    {
        public virtual string Recipe { get; set; }
        public virtual string AdditionalInfo { get; set; }

        public virtual long PreparationPeriodTicks { get; set; }
        /// <summary>
        /// Ile ma alkohol leżakować
        /// </summary>
        [NotMapped]
        public virtual TimeSpan PreparationPeriod
        {
            get { return TimeSpan.FromTicks(PreparationPeriodTicks); }
            set { PreparationPeriodTicks = value.Ticks; }
        }
        public virtual bool IsDeleted { get; set; }

        public virtual AlkoholRecipeDefinition AlkoholRecipeDefinition { get; set; }
        public virtual ISet<AlkoholInstance> AlkoholInstances { get; set; }
        public virtual ISet<AlkoholRecipe_Ingredient> Ingredients { get; set; }
    }

    public class AlkoholRecipeMapping : EntityClassMapping<AlkoholRecipe>
    {
        public AlkoholRecipeMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<AlkoholRecipe>(b =>
            {
                b.Property(x => x.CreatedTime);
                b.Property(x => x.ModifiedTime);
                b.Property(x => x.Recipe);
                b.Property(x => x.AdditionalInfo);
                b.Property(x => x.PreparationPeriodTicks);
                b.Property(x => x.IsDeleted);

                b.HasOne(x => x.AlkoholRecipeDefinition)
                    .WithMany(x => x.AlkoholRecipies);

                b.HasMany(x => x.AlkoholInstances)
                    .WithOne(x => x.AlkoholRecipe);
                b.HasMany(x => x.Ingredients)
                    .WithOne(x => x.AlkoholRecipe);
            });
        }
    }
}
