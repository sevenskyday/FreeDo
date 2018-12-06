using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShare.Data.Migrations
{
    public partial class DataContext20180925 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SubName = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    CoverImage = table.Column<string>(nullable: true),
                    Publish = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RealPrice = table.Column<decimal>(nullable: false),
                    AminId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    CreateDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
