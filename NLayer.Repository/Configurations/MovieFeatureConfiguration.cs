﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class MovieFeatureConfiguration : IEntityTypeConfiguration<MovieFeature>
    {
        public void Configure(EntityTypeBuilder<MovieFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Movie).WithOne(x => x.MovieFeature).HasForeignKey<MovieFeature>(x => x.MoviesId);
        }
    }
}
