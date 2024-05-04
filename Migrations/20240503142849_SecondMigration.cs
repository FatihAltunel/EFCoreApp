using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_CourseId",
                table: "CourseRegisters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_StudentId",
                table: "CourseRegisters",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Courses_CourseId",
                table: "CourseRegisters",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Students_StudentId",
                table: "CourseRegisters",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Courses_CourseId",
                table: "CourseRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Students_StudentId",
                table: "CourseRegisters");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegisters_CourseId",
                table: "CourseRegisters");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegisters_StudentId",
                table: "CourseRegisters");
        }
    }
}
