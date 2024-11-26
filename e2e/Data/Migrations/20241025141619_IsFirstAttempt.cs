using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e2e.Migrations
{
    /// <inheritdoc />
    public partial class IsFirstAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstAttempt",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstAttempt",
                table: "AspNetUsers");
        }
    }
}
