using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenCharityAuction.Web.Migrations.Auction
{
    public partial class UpdatedMealswithEventId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Meals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Meals",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_EventId",
                table: "Meals",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Events_EventId",
                table: "Meals",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Events_EventId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_EventId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Meals",
                nullable: false);
        }
    }
}
