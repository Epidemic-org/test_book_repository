using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test_book_repository_webapi.Migrations
{
    public partial class initialmigratios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioBook",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Announcer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioBook", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ganre",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GanreName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdGanre = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ShortDiscription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    BookPublisher = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SampleFile = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IsShown = table.Column<byte[]>(type: "binary(2)", fixedLength: true, maxLength: 2, nullable: false),
                    IdAudioBook = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.id);
                    table.ForeignKey(
                        name: "FK__Book__IdAudioBoo__3D5E1FD2",
                        column: x => x.IdAudioBook,
                        principalTable: "AudioBook",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Book__9558E7F299CC00E2",
                table: "Book",
                column: "IdAudioBook",
                unique: true,
                filter: "[IdAudioBook] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Ganre");

            migrationBuilder.DropTable(
                name: "AudioBook");
        }
    }
}
