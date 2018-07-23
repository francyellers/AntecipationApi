using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AntecipationApi.Migrations
{
    public partial class InitialCreate : Migration
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
                    StartDateAnalysis = table.Column<DateTime>(nullable: false),
                    EndDateAnalysis = table.Column<DateTime>(nullable: false),
                    Result = table.Column<bool>(nullable: false),
                    TotalValueTransactions = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    TotalValueTransfer = table.Column<decimal>(type: "decimal(9, 2)", nullable: false)
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
                    DateTransfer = table.Column<DateTime>(nullable: false),
                    AcquirerConfirmation = table.Column<bool>(nullable: false),
                    TransactionValue = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    ValueTransfer = table.Column<decimal>(type: "decimal(9, 2)", nullable: false),
                    ParcelNumber = table.Column<int>(nullable: false),
                    SolicitationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Solicitations_SolicitationId",
                        column: x => x.SolicitationId,
                        principalTable: "Solicitations",
                        principalColumn: "SolicitationId",
                        onDelete: ReferentialAction.Cascade);
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
