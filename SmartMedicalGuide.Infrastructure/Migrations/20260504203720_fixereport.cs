using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixereport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "MedicalReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MedicalReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "MedicalReports",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MedicalReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "MedicalReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MedicalReports");

            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "MedicalReports");
        }
    }
}
