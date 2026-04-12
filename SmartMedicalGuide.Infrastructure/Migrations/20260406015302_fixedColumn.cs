using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Key",
                table: "SystemSettings",
                newName: "KeyName");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Clinic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_UserId",
                table: "Clinic",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinic_User_UserId",
                table: "Clinic",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinic_User_UserId",
                table: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_Clinic_UserId",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clinic");

            migrationBuilder.RenameColumn(
                name: "KeyName",
                table: "SystemSettings",
                newName: "Key");
        }
    }
}
