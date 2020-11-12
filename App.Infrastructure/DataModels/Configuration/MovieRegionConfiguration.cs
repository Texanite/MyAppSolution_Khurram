using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DataModels.Configuration
{
    public class MovieRegionConfiguration : IEntityTypeConfiguration<MoviesRegion>
    {
        public void Configure(EntityTypeBuilder<MoviesRegion> builder)
        {
            builder.ToTable("MovieRegion");

            builder.HasKey(column => column.Id);

            builder
                .HasOne(movieRegion => movieRegion.Movie)
                .WithMany(movie => movie.MoviesRegions)
                .HasForeignKey(moviesRegion => moviesRegion.MovieId);
        }
    }
}
