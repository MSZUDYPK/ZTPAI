using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CultureSpot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INIT2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers");

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_UserId",
                table: "Organizers",
                column: "UserId",
                unique: true);
        }
    }
}
