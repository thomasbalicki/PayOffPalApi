using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PayOffPalApi.Migrations
{
    /// <inheritdoc />
    public partial class seededDbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DebtCategories",
                columns: new[] { "DebtCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Student Loans" },
                    { 2, "Credit Card" },
                    { 3, "Vehicle Loan" }
                });

            migrationBuilder.InsertData(
                table: "Debts",
                columns: new[] { "DebtId", "AmountOwed", "DateAdded", "DebtCategoryId", "DebtName", "InterestRate", "MonthlyPayment" },
                values: new object[,]
                {
                    { 1, 40000.00m, new DateTime(2023, 11, 28, 20, 28, 28, 570, DateTimeKind.Local).AddTicks(3042), 1, "Discover Student Loan", 10.0, 300.00m },
                    { 2, 2500.00m, new DateTime(2023, 11, 28, 20, 28, 28, 570, DateTimeKind.Local).AddTicks(3112), 2, "Apple Credit Card", 20.0, 100.00m },
                    { 3, 6000.00m, new DateTime(2023, 11, 28, 20, 28, 28, 570, DateTimeKind.Local).AddTicks(3115), 3, "Landmark Credit Union Loan", 20.0, 270.00m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "AmountPaid", "DebtId", "PaymentDate" },
                values: new object[,]
                {
                    { 1, 100.00m, 2, new DateTime(2023, 11, 28, 20, 28, 28, 570, DateTimeKind.Local).AddTicks(3145) },
                    { 2, 300.00m, 1, new DateTime(2023, 11, 28, 20, 28, 28, 570, DateTimeKind.Local).AddTicks(3150) },
                    { 3, 270.00m, 3, new DateTime(2023, 11, 28, 20, 28, 28, 570, DateTimeKind.Local).AddTicks(3154) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Debts",
                keyColumn: "DebtId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Debts",
                keyColumn: "DebtId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Debts",
                keyColumn: "DebtId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DebtCategories",
                keyColumn: "DebtCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DebtCategories",
                keyColumn: "DebtCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DebtCategories",
                keyColumn: "DebtCategoryId",
                keyValue: 3);
        }
    }
}
