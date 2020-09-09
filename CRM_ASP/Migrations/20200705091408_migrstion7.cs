using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_ASP.Migrations
{
    public partial class migrstion7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_BidStatus_BidStatusId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidStatus",
                table: "BidStatus");

            migrationBuilder.RenameTable(
                name: "BidStatus",
                newName: "Statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Statuses_BidStatusId",
                table: "Bids",
                column: "BidStatusId",
                principalTable: "Statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Statuses_BidStatusId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "BidStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidStatus",
                table: "BidStatus",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_BidStatus_BidStatusId",
                table: "Bids",
                column: "BidStatusId",
                principalTable: "BidStatus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
