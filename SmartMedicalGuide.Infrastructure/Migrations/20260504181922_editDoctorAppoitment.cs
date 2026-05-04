using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editDoctorAppoitment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CancellationReason",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RescheduledByUserId",
                table: "DoctorAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_DoctorId",
                table: "Favorites",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointments_RescheduledByUserId",
                table: "DoctorAppointments",
                column: "RescheduledByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_AspNetUsers_RescheduledByUserId",
                table: "DoctorAppointments",
                column: "RescheduledByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Doctors_DoctorId",
                table: "Favorites",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_AspNetUsers_RescheduledByUserId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Doctors_DoctorId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_DoctorId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAppointments_RescheduledByUserId",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "RescheduledByUserId",
                table: "DoctorAppointments");
        }
    }
}
