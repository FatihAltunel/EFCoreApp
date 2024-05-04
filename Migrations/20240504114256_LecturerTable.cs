using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class LecturerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LecturerName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LecturerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lecturers_LecturerId",
                table: "Courses",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lecturers_LecturerId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LecturerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Courses");
        }
    }
}
