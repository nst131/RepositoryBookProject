using BookDAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDAL.Configuration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        private const string tableName = nameof(Book);

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ISBN).HasMaxLength(13).IsRequired();
            builder.Property(x => x.IBAN).HasMaxLength(30).IsRequired();
            builder.Property(x => x.TimeAccepted).HasColumnType("datetime");
            builder.Property(x => x.TimeGiveAway).HasColumnName("datetime");

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(new Book[]
            {
                new Book{ 
                    Id = 1, 
                    AuthorId = 1, 
                    Name = "Ребекка", 
                    Description = "Каждая женщина мечтает выйти замуж по любви. Однако далеко не всегда такие мечты сбываются. Очень часто это связано с материальным положением невесты, которая из-за бедности может выйти замуж за нелюбимого человека, обладающего богатством и статусом.",
                    GenreId = 1,
                    ISBN = "5-237-01064-1",
                    IBAN = "BY NBRB 123456"
                },

                new Book
                {
                    Id = 2,
                    AuthorId = 1,
                    Name = "Шарлота",
                    Description = "У меня был четкий план: помолвка с влиятельным лордом и блистательное возвращение ко двору. Восстановить былую славу и влияние рода Ньер, завязать нужные знакомства и сбросить с себя клеймо неудачников. Все это полетело в Бездну, не успев начаться. Поцелуй с незнакомцем, нападение лесных разбойников. И вот я уже не леди, а пленница",
                    GenreId = 1,
                    ISBN = "5-237-01064-2",
                    IBAN = "BY NBRB 123456"
                },

                new Book
                {
                    Id = 3,
                    AuthorId = 2,
                    Name = "Айвенго",
                    Description = "Время Англии 11 века по-своему притягательно: тут и рыцарские турниры, и крестовые походы, и благородные разбойники, и прекрасные дамы. Те, кому нравится читать об этой эпохе, не смогут пройти мимо великолепного романа Вальтера Скотта «Айвенго», который принес писателю мировую славу",
                    GenreId = 5,
                    ISBN = "5-237-01064-3",
                    IBAN = "BY NBRB 123456"
                },
                
                new Book 
                {
                    Id = 4,
                    AuthorId = 2,
                    Name = "Комната с призраком",
                    Description = "Готический ужас и тайна составляют основу содержания книги известного английского исследователя Питера Хэйнинга. Потусторонний мир очаровывает своими видениями: демонические силы и посещения со злой целью;",
                    GenreId = 5,
                    ISBN = "5-237-01064-4",
                    IBAN = "BY NBRB 123456"
                },

                new Book
                {
                    Id = 5,
                    AuthorId = 3,
                    Name = "Уотсоны",
                    Description = "Джейн Остин, в которых она, молодая девушка, еще только ищет свой стиль, - Собрание писем и самая ироничная на свете История Англии,",
                    GenreId = 2,
                    ISBN = "5-237-01064-5",
                    IBAN = "BY NBRB 123456"
                }
            });
        }
    }
}
