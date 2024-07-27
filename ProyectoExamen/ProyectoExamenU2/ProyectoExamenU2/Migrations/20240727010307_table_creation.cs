using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoExamenU2.Migrations
{
    /// <inheritdoc />
    public partial class table_creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    identity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_amount = table.Column<double>(type: "float", nullable: false),
                    comission_rate = table.Column<double>(type: "float", nullable: false),
                    interest_rate = table.Column<double>(type: "float", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursement_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_payment_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                    table.ForeignKey(
                        name: "FK_loans_clients_client_id",
                        column: x => x.client_id,
                        principalSchema: "dbo",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "amortization_plans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installment_number = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    interest = table.Column<double>(type: "float", nullable: false),
                    principal = table.Column<double>(type: "float", nullable: false),
                    level_payment_without_SVSD = table.Column<double>(type: "float", nullable: false),
                    level_payment_with_SVSD = table.Column<double>(type: "float", nullable: false),
                    principal_balance = table.Column<double>(type: "float", nullable: false),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortization_plans", x => x.id);
                    table.ForeignKey(
                        name: "FK_amortization_plans_loans_loan_id",
                        column: x => x.loan_id,
                        principalSchema: "dbo",
                        principalTable: "loans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amortization_plans_loan_id",
                schema: "dbo",
                table: "amortization_plans",
                column: "loan_id");

            migrationBuilder.CreateIndex(
                name: "IX_loans_client_id",
                schema: "dbo",
                table: "loans",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amortization_plans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "loans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "dbo");
        }
    }
}
