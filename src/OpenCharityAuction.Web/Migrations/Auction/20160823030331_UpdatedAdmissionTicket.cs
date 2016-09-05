using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    public partial class UpdatedAdmissionTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AdmissionTickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AdmissionTickets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AdmissionTickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "AdmissionTickets",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AdmissionTickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AdmissionTickets");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AdmissionTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Cost",
                table: "AdmissionTickets",
                nullable: false);
        }
    }
}
