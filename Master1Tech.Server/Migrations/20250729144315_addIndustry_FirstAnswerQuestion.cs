using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Master1Tech.Server.Migrations
{
    /// <inheritdoc />
    public partial class addIndustry_FirstAnswerQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstAnswerQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstAnswerQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstAnswerQuestions_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstAnswerQuestions_CompanyID",
                table: "FirstAnswerQuestions",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstAnswerQuestions");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
