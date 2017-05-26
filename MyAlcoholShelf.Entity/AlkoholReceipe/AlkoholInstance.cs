﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyAlkoholShelf.Entity
{
    public class AlkoholInstance : VersionedEntity
    {
        public virtual int Quantity { get; set; }

        /// <summary>
        /// Do kiedy ma conajmniej leżakować
        /// </summary>
        public DateTime FinishDate => CreatedTime.Add(AlkoholReceipe.PreparationPeriod);

        public virtual AlkoholRecipe AlkoholReceipe { get; set; }
    }

    public class AlkoholInstanceMapping : EntityClassMapping<AlkoholInstance>
    {
        public AlkoholInstanceMapping(ModelBuilder builder) : base(builder)
        {
            builder.Entity<AlkoholInstance>(b =>
            {
                b.Property(x => x.CreatedTime);
                b.Property(x => x.ModifiedTime);
                b.Property(x => x.Quantity);
                b.HasOne(x => x.AlkoholReceipe)
                    .WithMany(x => x.AlkoholInstances);
            });
        }
    }
}
