﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkCardAPI.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_WorkCards_WorkCardId",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "WorkCardId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_WorkCards_WorkCardId",
                table: "Operations",
                column: "WorkCardId",
                principalTable: "WorkCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_WorkCards_WorkCardId",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "WorkCardId",
                table: "Operations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_WorkCards_WorkCardId",
                table: "Operations",
                column: "WorkCardId",
                principalTable: "WorkCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
