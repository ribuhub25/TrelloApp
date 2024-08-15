using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrelloApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAtlasuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 4, "atlas@gmail.com", "Javi", "atlas" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
