using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    public partial class updatedEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Events",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Events",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Events",
                nullable: true);
        }
    }
}
