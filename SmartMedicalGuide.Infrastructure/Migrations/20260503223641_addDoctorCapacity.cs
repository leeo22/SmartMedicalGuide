using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDoctorCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Wallets",
                newName: "WithdrawnBalance");

            migrationBuilder.AddColumn<decimal>(
                name: "AvailableBalance",
                table: "Wallets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DoctorAccountNumber",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBalance",
                table: "Wallets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "BookingSource",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPostponed",
                table: "DoctorAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NewAppointmentDate",
                table: "DoctorAppointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OriginalAppointmentDate",
                table: "DoctorAppointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostponeReason",
                table: "DoctorAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorCapacitySettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    WorkDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyCapacity = table.Column<int>(type: "int", nullable: false),
                    ShiftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxLimit = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorCapacitySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorCapacitySettings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorCapacitySettings_DoctorId",
                table: "DoctorCapacitySettings",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorCapacitySettings");

            migrationBuilder.DropColumn(
                name: "AvailableBalance",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DoctorAccountNumber",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "BookingSource",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "IsPostponed",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "NewAppointmentDate",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "OriginalAppointmentDate",
                table: "DoctorAppointments");

            migrationBuilder.DropColumn(
                name: "PostponeReason",
                table: "DoctorAppointments");

            migrationBuilder.RenameColumn(
                name: "WithdrawnBalance",
                table: "Wallets",
                newName: "Balance");
        }
    }
}
