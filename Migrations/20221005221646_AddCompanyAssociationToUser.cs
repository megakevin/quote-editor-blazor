using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoteEditorBlazor.Migrations
{
    public partial class AddCompanyAssociationToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "company_id",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_company_id",
                table: "AspNetUsers",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_users_companies_company_id",
                table: "AspNetUsers",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_users_companies_company_id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "ix_asp_net_users_company_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "company_id",
                table: "AspNetUsers");
        }
    }
}
