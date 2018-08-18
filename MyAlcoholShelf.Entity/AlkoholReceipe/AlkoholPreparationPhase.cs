using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class AlkoholPreparationPhase : Entity, ISoftDeletable
    {
        public virtual string Name { get; set; }

        public virtual long PhasePeriodTicks { get; set; }
        /// <summary>
        /// Ile faza tworzenia alkoholu ma trwać
        /// </summary>
        [NotMapped]
        public virtual TimeSpan PhasePeriod
        {
            get => TimeSpan.FromTicks(PhasePeriodTicks);
            set => PhasePeriodTicks = value.Ticks;
        }

        public virtual bool IsDeleted { get; set; }

        public virtual AlkoholRecipe AlkoholRecipe { get; set; }
        public virtual long AlkoholRecipeId { get; set; }

        /// <summary>
        /// All alkohol instances that period is current.
        /// <b>It is better not to use that, Entity Core just forces to create such property!</b>
        /// </summary>
        public virtual ISet<AlkoholInstance> AlkoholInstances { get; set; }
    }

    public class AlkoholPreparationPhaaseMapping : EntityClassMapping<AlkoholPreparationPhase>
    {
        public AlkoholPreparationPhaaseMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<AlkoholPreparationPhase>(
                b =>
                {
                    b.Property(x => x.Name);
                    b.Property(x => x.PhasePeriodTicks);
                    b.Property(x => x.IsDeleted);
                    b.HasOne(x => x.AlkoholRecipe)
                        .WithMany(x => x.PreparationPhases)
                        .HasForeignKey(x => x.AlkoholRecipeId);
                    b.HasMany(x => x.AlkoholInstances)
                        .WithOne(x => x.CurrentPreparationPhase)
                        .HasForeignKey(x => x.CurrentPreparationPhaseId);
                }
            );
        }
    }
}
