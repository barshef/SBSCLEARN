using Microsoft.EntityFrameworkCore.Migrations;

namespace SBSCLEARN.Persistence.Migrations
{
    public partial class AddedScoreDetailsObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreDetail_Courses_CourseId",
                table: "ScoreDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreDetail_Users_UserId",
                table: "ScoreDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreDetail",
                table: "ScoreDetail");

            migrationBuilder.RenameTable(
                name: "ScoreDetail",
                newName: "ScoreDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreDetail_UserId",
                table: "ScoreDetails",
                newName: "IX_ScoreDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreDetails",
                table: "ScoreDetails",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreDetails_Courses_CourseId",
                table: "ScoreDetails",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreDetails_Users_UserId",
                table: "ScoreDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreDetails_Courses_CourseId",
                table: "ScoreDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreDetails_Users_UserId",
                table: "ScoreDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScoreDetails",
                table: "ScoreDetails");

            migrationBuilder.RenameTable(
                name: "ScoreDetails",
                newName: "ScoreDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreDetails_UserId",
                table: "ScoreDetail",
                newName: "IX_ScoreDetail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScoreDetail",
                table: "ScoreDetail",
                columns: new[] { "CourseId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreDetail_Courses_CourseId",
                table: "ScoreDetail",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreDetail_Users_UserId",
                table: "ScoreDetail",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
