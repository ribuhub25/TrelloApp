using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrelloApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioGilgamesh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "Snapero@gmail.com", "Gilgamesh", "snap" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
