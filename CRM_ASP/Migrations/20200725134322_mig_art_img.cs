using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_ASP.Migrations
{
    public partial class mig_art_img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imageData",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageData",
                table: "Articles");
        }
    }
}
