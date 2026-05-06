using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addclincxsandfoviret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Doctors_DoctorId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_PatientId_DoctorId",
                table: "Favorites");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Favorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Favorites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ClinicImageUrl",
                table: "Clinics",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ClosingTime",
                table: "Clinics",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clinics",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clinics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clinics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Clinics",
                type: "decimal(10,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Clinics",
                type: "decimal(11,8)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OpeningTime",
                table: "Clinics",
                type: "time",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PatientId_DoctorId",
                table: "Favorites",
                columns: new[] { "PatientId", "DoctorId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Doctors_DoctorId",
                table: "Favorites",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Patients_PatientId",
                table: "Favorites",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Doctors_DoctorId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Patients_PatientId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_PatientId_DoctorId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ClinicImageUrl",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Clinics");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Favorites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Favorites",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PatientId_DoctorId",
                table: "Favorites",
                columns: new[] { "PatientId", "DoctorId" },
                unique: true,
                filter: "[PatientId] IS NOT NULL AND [DoctorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Doctors_DoctorId",
                table: "Favorites",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");
        }
    }
}
