using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportUnite.DAL.Migrations
{
    public partial class jordy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles1_RoleId1",
                table: "AspNetRoleClaims1");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles1_RoleId1",
                table: "AspNetUserRoles1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles1",
                table: "AspNetRoles1");

            migrationBuilder.RenameTable(
                name: "AspNetRoles1",
                newName: "AspNetRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles1",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                table: "AspNetRoleClaims1",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles1",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId1",
                table: "AspNetRoleClaims1");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles1",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles1",
                table: "AspNetRoles1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles1_RoleId1",
                table: "AspNetRoleClaims1",
                column: "RoleId",
                principalTable: "AspNetRoles1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles1_RoleId",
                table: "AspNetUserRoles1",
                column: "RoleId",
                principalTable: "AspNetRoles1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
