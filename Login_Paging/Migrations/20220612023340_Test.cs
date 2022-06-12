using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Login_Paging.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoaVM_Identification_Id",
                table: "HangHoaVM");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDung_Identification_Id",
                table: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Identification");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDung_UserName",
                table: "NguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_UserName",
                table: "NguoiDung",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NguoiDung_UserName",
                table: "NguoiDung");

            migrationBuilder.CreateTable(
                name: "Identification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identification", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_UserName",
                table: "NguoiDung",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoaVM_Identification_Id",
                table: "HangHoaVM",
                column: "Id",
                principalTable: "Identification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDung_Identification_Id",
                table: "NguoiDung",
                column: "Id",
                principalTable: "Identification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
