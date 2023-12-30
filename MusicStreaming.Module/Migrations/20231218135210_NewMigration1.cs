using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStreaming.Module.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_CreatedByID",
                table: "Playlists");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_CreatedByID",
                table: "Playlists",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_CreatedByID",
                table: "Playlists");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_CreatedByID",
                table: "Playlists",
                column: "CreatedByID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
