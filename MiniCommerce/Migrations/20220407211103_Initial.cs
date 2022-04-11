using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCommerce.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Categories",
          columns: table => new
          {
            Id = table.Column<int>(type: "INTEGER", nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(type: "TEXT", nullable: false),
            Description = table.Column<string>(type: "TEXT", nullable: false),
            CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
            UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Categories", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Products",
          columns: table => new
          {
            Id = table.Column<int>(type: "INTEGER", nullable: false)
                  .Annotation("Sqlite:Autoincrement", true),
            Name = table.Column<string>(type: "TEXT", nullable: false),
            Description = table.Column<string>(type: "TEXT", nullable: false),
            Price = table.Column<decimal>(type: "NUMERIC", nullable: true),
            CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
            CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
            UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Products", x => x.Id);
            table.ForeignKey(
                      name: "FK_Products_Categories_CategoryId",
                      column: x => x.CategoryId,
                      principalTable: "Categories",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Products_CategoryId",
          table: "Products",
          column: "CategoryId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Products");

      migrationBuilder.DropTable(
          name: "Categories");
    }
  }
}
