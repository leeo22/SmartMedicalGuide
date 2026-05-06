using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMedicalGuide.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editwallets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DoctorAccountNumber",
                table: "Wallets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountHolderName",
                table: "Wallets",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Wallets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Wallets",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Wallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Wallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalletId1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId1",
                table: "Transactions",
                column: "WalletId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_WalletId1",
                table: "Transactions",
                column: "WalletId1",
                principalTable: "Wallets",
                principalColumn: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_WalletId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountHolderName",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "WalletId1",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorAccountNumber",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
