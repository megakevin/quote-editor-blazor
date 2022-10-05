using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteEditorBlazor.Migrations
{
    public partial class AddCompanyAssociationToQuote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "company_id",
                table: "quotes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_quotes_company_id",
                table: "quotes",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "fk_quotes_companies_company_id",
                table: "quotes",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_quotes_companies_company_id",
                table: "quotes");

            migrationBuilder.DropIndex(
                name: "ix_quotes_company_id",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "company_id",
                table: "quotes");
        }
    }
}
