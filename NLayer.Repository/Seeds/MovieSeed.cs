using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds
{
    internal class MovieSeed : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasData(
                new Movies { Id = 1, Title = "Jumanji", CategoryId=1, CreatedDate=DateTime.Now },
                new Movies { Id = 2, Title = "Interstellar", CategoryId=2, CreatedDate = DateTime.Now },
                new Movies { Id = 3, Title = "The Martian", CategoryId=2, CreatedDate = DateTime.Now },
                new Movies { Id = 4, Title = "Pacific Rim", CategoryId = 3, CreatedDate = DateTime.Now },
                new Movies { Id = 5, Title = "Hitman's Bodyguard",CategoryId=3, CreatedDate = DateTime.Now });
        }
    }
}
