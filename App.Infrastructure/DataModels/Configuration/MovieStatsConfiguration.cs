using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DataModels.Configuration
{
    public class MovieStatsConfiguration : IEntityTypeConfiguration<MovieStats>
    {
        public void Configure(EntityTypeBuilder<MovieStats> builder)
        {
            builder.ToTable("MovieStats");

            builder.HasKey(column => column.Id);

            builder
                .HasOne(movieStat => movieStat.Movie)
                .WithMany(movie => movie.MovieStats)
                .HasForeignKey(MovieStats => MovieStats.MovieId);
        }
    }

}
