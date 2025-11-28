using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroBankingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditTransactionTypeFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionsType",
                table: "Transactions",
                newName: "TransactionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transactions",
                newName: "TransactionsType");
        }
    }
}
