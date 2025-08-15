using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Master1Tech.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamSizeMin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamSizeMin",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamSizeMin",
                table: "Companies");
        }
    }
}
