using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiabetWebSite.Migrations
{
    /// <inheritdoc />
    public partial class AddFindRiscResultsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FindRiscResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRiskPoints = table.Column<int>(type: "int", nullable: false),
                    DegreeOfRisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenYearRiskRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoutineScreening = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindRiscResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    FindRiscResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswer_FindRiscResults_FindRiscResultId",
                        column: x => x.FindRiscResultId,
                        principalTable: "FindRiscResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_FindRiscResultId",
                table: "UserAnswer",
                column: "FindRiscResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.DropTable(
                name: "FindRiscResults");
        }
    }
}
