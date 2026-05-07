using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDiagnosisHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceType",
                table: "Transactions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionReference",
                table: "Transactions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FollowUpDate",
                table: "Prescriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Prescriptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "PrescriptionItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "PrescriptionItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PrescriptionItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId1",
                table: "PrescriptionItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "PrescriptionItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "LabServices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "LabServices",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "LabServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "LabServices",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LabServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LabServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Labs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Labs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Labs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Labs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LabImageUrl",
                table: "Labs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Labs",
                type: "decimal(10,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Labs",
                type: "decimal(11,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "Labs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingSource",
                table: "LabAppointments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancellationReason",
                table: "LabAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LabAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LabId1",
                table: "LabAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "LabAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RescheduledByUserId",
                table: "LabAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfExp",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiagnosisHistories",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiDiagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confidence = table.Column<double>(type: "float", nullable: true),
                    ResponseTimeMs = table.Column<int>(type: "int", nullable: true),
                    IsFromFallback = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectedDoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisHistories", x => x.DiagnosisId);
                    table.ForeignKey(
                        name: "FK_DiagnosisHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisHistories_Doctors_SelectedDoctorId",
                        column: x => x.SelectedDoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IsDeleted",
                table: "Prescriptions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_Status",
                table: "Prescriptions",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionItems_PrescriptionId1",
                table: "PrescriptionItems",
                column: "PrescriptionId1");

            migrationBuilder.CreateIndex(
                name: "IX_LabAppointments_LabId1",
                table: "LabAppointments",
                column: "LabId1");

            migrationBuilder.CreateIndex(
                name: "IX_LabAppointments_RescheduledByUserId",
                table: "LabAppointments",
                column: "RescheduledByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisHistories_SelectedDoctorId",
                table: "DiagnosisHistories",
                column: "SelectedDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisHistories_UserId",
                table: "DiagnosisHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabAppointments_AspNetUsers_RescheduledByUserId",
                table: "LabAppointments",
                column: "RescheduledByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabAppointments_Labs_LabId1",
                table: "LabAppointments",
                column: "LabId1",
                principalTable: "Labs",
                principalColumn: "LabId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionItems_Prescriptions_PrescriptionId1",
                table: "PrescriptionItems",
                column: "PrescriptionId1",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabAppointments_AspNetUsers_RescheduledByUserId",
                table: "LabAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_LabAppointments_Labs_LabId1",
                table: "LabAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionItems_Prescriptions_PrescriptionId1",
                table: "PrescriptionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Patients_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "DiagnosisHistories");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_IsDeleted",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_Status",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionItems_PrescriptionId1",
                table: "PrescriptionItems");

            migrationBuilder.DropIndex(
                name: "IX_LabAppointments_LabId1",
                table: "LabAppointments");

            migrationBuilder.DropIndex(
                name: "IX_LabAppointments_RescheduledByUserId",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReferenceType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionReference",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FollowUpDate",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "PrescriptionId1",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PrescriptionItems");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "LabServices");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "LabServices");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "LabServices");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "LabServices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LabServices");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LabServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "LabImageUrl",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "Labs");

            migrationBuilder.DropColumn(
                name: "BookingSource",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "LabId1",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "RescheduledByUserId",
                table: "LabAppointments");

            migrationBuilder.DropColumn(
                name: "YearOfExp",
                table: "Doctors");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
