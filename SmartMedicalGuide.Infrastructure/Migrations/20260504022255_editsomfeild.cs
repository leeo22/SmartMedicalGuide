using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editsomfeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "DoctorSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForBooking",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "DoctorAppointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "Chats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId1",
                table: "DoctorSchedules",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAppointments_DoctorId1",
                table: "DoctorAppointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_DoctorId1",
                table: "Chats",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Doctors_DoctorId1",
                table: "Chats",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId1",
                table: "DoctorAppointments",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId1",
                table: "DoctorSchedules",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Doctors_DoctorId",
                table: "Reviews",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Patients_PatientId",
                table: "Reviews",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Doctors_DoctorId1",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorId1",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId1",
                table: "DoctorSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Doctors_DoctorId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Patients_PatientId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSchedules_DoctorId1",
                table: "DoctorSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAppointments_DoctorId1",
                table: "DoctorAppointments");

            migrationBuilder.DropIndex(
                name: "IX_Chats_DoctorId1",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsAvailableForBooking",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Chats");
        }
    }
}
