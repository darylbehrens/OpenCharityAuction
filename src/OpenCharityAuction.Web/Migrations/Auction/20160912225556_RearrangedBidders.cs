using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    public partial class RearrangedBidders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Bidders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Bidders");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bidders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bidders");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Bidders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Bidders",
                nullable: false,
                defaultValue: "");
        }
    }
}
