using BookDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDAL.Configuration
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        private const string tableName = nameof(Genre);

        public void Configure(EntityTypeBuilder<Genre> builder)
        {

            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();

            builder.HasData(new Genre[]
            {
                new Genre{ Id = 1, Name = "Romance" },
                new Genre{ Id = 2, Name = "Drama"},
                new Genre{ Id = 3, Name = "Comedy"},
                new Genre{ Id = 4, Name = "Detective"},
                new Genre{ Id = 5, Name = "Adventure"}
            });
        }
    }
}
