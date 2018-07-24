using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntecipationApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitations",
                columns: table => new
                {
                    SolicitationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    StartDateAnalysis = table.Column<DateTime>(nullable: true),
                    EndDateAnalysis = table.Column<DateTime>(nullable: true),
                    Result = table.Column<bool>(nullable: true),
                    TotalValueTransactions = table.Column<decimal>(type: "decimal(9, 2)", nullable: true),
                    TotalValueTransfer = table.Column<decimal>(type: "decimal(9, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitations", x => x.SolicitationId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransctionDate = table.Column<DateTime>(nullable: false),
                    DateTransfer = table.Column<DateTime>(nullable: true),
                    AcquirerConfirmation = table.Column<bool>(nullable: true),
                    TransactionValue = table.Column<decimal>(type: "decimal(9, 2)", nullable: true),
                    ValueTransfer = table.Column<decimal>(type: "decimal(9, 2)", nullable: true),
                    ParcelNumber = table.Column<int>(nullable: true),
                    SolicitationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Solicitations_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitations",
                        principalColumn: "SolicitationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SolicitationId",
                table: "Transactions",
                column: "SolicitationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Solicitations");
        }
    }
}
