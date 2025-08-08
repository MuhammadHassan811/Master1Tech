using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Master1Tech.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugColumnToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Companies");
        }
    }
}
