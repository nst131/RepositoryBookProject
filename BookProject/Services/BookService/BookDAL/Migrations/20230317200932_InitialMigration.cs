using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookDAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    TimeAccepted = table.Column<DateTime>(type: "datetime", nullable: true),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name", "SerName" },
                values: new object[,]
                {
                    { 1, "Edgar", "Elen" },
                    { 2, "Valter", "Scot" },
                    { 3, "Gein", "Ostin" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Romance" },
                    { 2, "Drama" },
                    { 3, "Comedy" },
                    { 4, "Detective" },
                    { 5, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Description", "GenreId", "IBAN", "ISBN", "Name", "TimeAccepted", "datetime" },
                values: new object[,]
                {
                    { 1, 1, "Каждая женщина мечтает выйти замуж по любви. Однако далеко не всегда такие мечты сбываются. Очень часто это связано с материальным положением невесты, которая из-за бедности может выйти замуж за нелюбимого человека, обладающего богатством и статусом.", 1, "BY NBRB 123456", "5-237-01064-1", "Ребекка", null, null },
                    { 2, 1, "У меня был четкий план: помолвка с влиятельным лордом и блистательное возвращение ко двору. Восстановить былую славу и влияние рода Ньер, завязать нужные знакомства и сбросить с себя клеймо неудачников. Все это полетело в Бездну, не успев начаться. Поцелуй с незнакомцем, нападение лесных разбойников. И вот я уже не леди, а пленница", 1, "BY NBRB 123456", "5-237-01064-2", "Шарлота", null, null },
                    { 5, 3, "Джейн Остин, в которых она, молодая девушка, еще только ищет свой стиль, - Собрание писем и самая ироничная на свете История Англии,", 2, "BY NBRB 123456", "5-237-01064-5", "Уотсоны", null, null },
                    { 3, 2, "Время Англии 11 века по-своему притягательно: тут и рыцарские турниры, и крестовые походы, и благородные разбойники, и прекрасные дамы. Те, кому нравится читать об этой эпохе, не смогут пройти мимо великолепного романа Вальтера Скотта «Айвенго», который принес писателю мировую славу", 5, "BY NBRB 123456", "5-237-01064-3", "Айвенго", null, null },
                    { 4, 2, "Готический ужас и тайна составляют основу содержания книги известного английского исследователя Питера Хэйнинга. Потусторонний мир очаровывает своими видениями: демонические силы и посещения со злой целью;", 5, "BY NBRB 123456", "5-237-01064-4", "Комната с призраком", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
