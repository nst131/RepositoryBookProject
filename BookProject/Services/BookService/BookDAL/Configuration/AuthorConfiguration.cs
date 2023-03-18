using BookDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDAL.Configuration
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        private const string tableName = nameof(Author); 

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SerName).HasMaxLength(256).IsRequired();

            builder.HasData(new Author[]
            {
                new Author{ Id = 1, Name = "Edgar", SerName = "Elen"},
                new Author{ Id = 2, Name = "Valter", SerName = "Scot"},
                new Author{ Id = 3, Name = "Gein", SerName = "Ostin"}
            });
        }
    }
}
