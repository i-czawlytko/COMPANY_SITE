using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM_ASP.Migrations
{
    public partial class img_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imageData",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageData",
                table: "Projects");
        }
    }
}
