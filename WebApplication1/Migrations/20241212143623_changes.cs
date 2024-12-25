using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_YourEntities",
                table: "YourEntities");

            migrationBuilder.RenameTable(
                name: "YourEntities",
                newName: "Libraries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries");

            migrationBuilder.RenameTable(
                name: "Libraries",
                newName: "YourEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YourEntities",
                table: "YourEntities",
                column: "Id");
        }
    }
}
