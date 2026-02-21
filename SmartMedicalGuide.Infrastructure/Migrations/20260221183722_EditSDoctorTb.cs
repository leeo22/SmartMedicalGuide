using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSDoctorTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Doctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
