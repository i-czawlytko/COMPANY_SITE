using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_ASP.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "BidStatusId",
                table: "Bids",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BidStatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidStatus", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BidStatusId",
                table: "Bids",
                column: "BidStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_BidStatus_BidStatusId",
                table: "Bids",
                column: "BidStatusId",
                principalTable: "BidStatus",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_BidStatus_BidStatusId",
                table: "Bids");

            migrationBuilder.DropTable(
                name: "BidStatus");

            migrationBuilder.DropIndex(
                name: "IX_Bids_BidStatusId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "BidStatusId",
                table: "Bids");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Bids",
                nullable: true);
        }
    }
}
