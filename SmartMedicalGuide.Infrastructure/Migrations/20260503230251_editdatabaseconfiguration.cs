using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editdatabaseconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LabId",
                table: "MedicalReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "MedicalReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "WorkDays",
                table: "DoctorCapacitySettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShiftType",
                table: "DoctorCapacitySettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookingType",
                table: "DoctorCapacitySettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "DoctorCapacitySettings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChatName",
                table: "Chats",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_DoctorId",
                table: "MedicalReports",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_LabId",
                table: "MedicalReports",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_PatientId",
                table: "MedicalReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorCapacitySettings_DoctorId1",
                table: "DoctorCapacitySettings",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorCapacitySettings_Doctors_DoctorId1",
                table: "DoctorCapacitySettings",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Labs_LabId",
                table: "MedicalReports",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "LabId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorCapacitySettings_Doctors_DoctorId1",
                table: "DoctorCapacitySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Doctors_DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Labs_LabId",
                table: "MedicalReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalReports_Patients_PatientId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_DoctorId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_LabId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_MedicalReports_PatientId",
                table: "MedicalReports");

            migrationBuilder.DropIndex(
                name: "IX_DoctorCapacitySettings_DoctorId1",
                table: "DoctorCapacitySettings");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "DoctorCapacitySettings");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LabId",
                table: "MedicalReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "MedicalReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkDays",
                table: "DoctorCapacitySettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ShiftType",
                table: "DoctorCapacitySettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BookingType",
                table: "DoctorCapacitySettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ChatName",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValue: "");
        }
    }
}
