using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodieMania.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foodie",
                table: "Foodie");

            migrationBuilder.RenameTable(
                name: "Foodie",
                newName: "Foodies");

            migrationBuilder.RenameIndex(
                name: "IX_Foodie_Name",
                table: "Foodies",
                newName: "IX_Foodies_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foodies",
                table: "Foodies",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foodies",
                table: "Foodies");

            migrationBuilder.RenameTable(
                name: "Foodies",
                newName: "Foodie");

            migrationBuilder.RenameIndex(
                name: "IX_Foodies_Name",
                table: "Foodie",
                newName: "IX_Foodie_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foodie",
                table: "Foodie",
                column: "Id");
        }
    }
}
