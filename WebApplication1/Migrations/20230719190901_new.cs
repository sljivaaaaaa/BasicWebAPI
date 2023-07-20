using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CountryID",
                table: "Contacts",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Companies_CompanyId",
                table: "Contacts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Countries_CountryID",
                table: "Contacts",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Companies_CompanyId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Countries_CountryID",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CountryID",
                table: "Contacts");
        }
    }
}
