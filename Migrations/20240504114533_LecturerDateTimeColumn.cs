using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class LecturerDateTimeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Lecturers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Lecturers");
        }
    }
}
