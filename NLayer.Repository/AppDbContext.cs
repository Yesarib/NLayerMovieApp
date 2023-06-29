using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieFeature> MovieFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<MovieFeature>().HasData(new MovieFeature()
            {
                Id=1,
                ImdbRating = 8,
                Overview = "Uzun Bir Açıklama",
                Year = 2012,
                MoviesId = 1,
            },
            new MovieFeature()
            {
                Id = 2,
                ImdbRating = 9,
                Overview = "Uzun Bir Açıklama 2",
                Year = 2014,
                MoviesId = 2,
            },
            new MovieFeature()
            {
                Id = 3,
                ImdbRating = 7,
                Overview = "Uzun Bir Açıklama 3",
                Year = 2014,
                MoviesId = 3,
            },
            new MovieFeature()
            {
                Id = 4,
                ImdbRating = 8,
                Overview = "Uzun Bir Açıklama 4",
                Year = 2019,
                MoviesId = 4,
            },
            new MovieFeature()
            {
                Id = 5,
                ImdbRating = 7,
                Overview = "Uzun Bir Açıklama 5",
                Year = 2015,
                MoviesId = 5,
            }


            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
 