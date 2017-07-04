using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class AlkoholRecipeDefinition : UserVersionedEntity, ISoftDeletable
    {
        public virtual string Name { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual ISet<AlkoholRecipe> AlkoholRecipies { get; set; }
    }

    public class AlkoholRecipeDefinitionMapping : EntityClassMapping<AlkoholRecipeDefinition>
    {
        public AlkoholRecipeDefinitionMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<AlkoholRecipeDefinition>(b =>
            {
                b.Property(x => x.CreatedTime);
                b.Property(x => x.ModifiedTime);
                b.Property(x => x.IsDeleted);
                b.Property(x => x.Name);
                b.HasMany(x => x.AlkoholRecipies)
                    .WithOne(x => x.AlkoholRecipeDefinition)
                    .HasForeignKey(x=>x.AlkoholRecipeDefinitionId);
            });
        }
    }
}
