using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixPaymentR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payment_AppointmentType_AppointmentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "AppointmentType",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "DoctorAppointmentId",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LabAppointmentId",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_DoctorAppointmentId",
                table: "Payment",
                column: "DoctorAppointmentId",
                unique: true,
                filter: "[DoctorAppointmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_LabAppointmentId",
                table: "Payment",
                column: "LabAppointmentId",
                unique: true,
                filter: "[LabAppointmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_DoctorAppointment_DoctorAppointmentId",
                table: "Payment",
                column: "DoctorAppointmentId",
                principalTable: "DoctorAppointment",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_LabAppointment_LabAppointmentId",
                table: "Payment",
                column: "LabAppointmentId",
                principalTable: "LabAppointment",
                principalColumn: "LabAppointmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_DoctorAppointment_DoctorAppointmentId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_LabAppointment_LabAppointmentId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_DoctorAppointmentId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_LabAppointmentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "DoctorAppointmentId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "LabAppointmentId",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentType",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AppointmentType_AppointmentId",
                table: "Payment",
                columns: new[] { "AppointmentType", "AppointmentId" },
                unique: true);
        }
    }
}
