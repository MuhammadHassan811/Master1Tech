using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Master1Tech.Server.Migrations
{
    /// <inheritdoc />
    public partial class addCompanyIndustryFocuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyIndustryFocuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FocusPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    IndustryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIndustryFocuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyIndustryFocuses_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyIndustryFocuses_Industries_IndustryID",
                        column: x => x.IndustryID,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustryFocuses_CompanyID",
                table: "CompanyIndustryFocuses",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIndustryFocuses_IndustryID",
                table: "CompanyIndustryFocuses",
                column: "IndustryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyIndustryFocuses");
        }
    }
}
