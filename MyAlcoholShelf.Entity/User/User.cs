using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAlcoholShelf.Common;

namespace MyAlkoholShelf.Entity
{
    public abstract class UserVersionedEntity : VersionedEntity
    {
        public virtual User CreatedBy { get; set; }
    }

    public class User : VersionedEntity
    {
        public User()
        {
            AlkoholRecipeDefinitions = ISetHelpers.EnsureExists(AlkoholRecipeDefinitions);
            UserIngredients = ISetHelpers.EnsureExists(UserIngredients);
        }

        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email{ get; set; }

        public virtual ISet<AlkoholRecipeDefinition> AlkoholRecipeDefinitions{ get; set; }
        public virtual ISet<Ingredient> UserIngredients { get; set; }
    }

    public class UserMapping : EntityClassMapping<User>
    {
        public UserMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<User>(b =>
            {
                b.Property(x => x.CreatedTime);
                b.Property(x => x.ModifiedTime);
                b.Property(x => x.UserName);
                b.Property(x => x.FirstName);
                b.Property(x => x.Email);

                b.HasMany(x => x.AlkoholRecipeDefinitions)
                    .WithOne(x => x.CreatedBy)
                    .HasForeignKey(x => x.Id);

                b.HasMany(x => x.UserIngredients)
                    .WithOne(x => x.CreatedBy)
                    .HasForeignKey(x => x.Id);
            });
        }
    }
}
