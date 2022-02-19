using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Campus.API.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_WorkGroup_WorkGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherInfo_WorkGroup_WorkGroupId",
                table: "TeacherInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkGroupId",
                table: "TeacherInfo",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkGroupId",
                table: "Activities",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_WorkGroup_WorkGroupId",
                table: "Activities",
                column: "WorkGroupId",
                principalTable: "WorkGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherInfo_WorkGroup_WorkGroupId",
                table: "TeacherInfo",
                column: "WorkGroupId",
                principalTable: "WorkGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_WorkGroup_WorkGroupId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherInfo_WorkGroup_WorkGroupId",
                table: "TeacherInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkGroupId",
                table: "TeacherInfo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkGroupId",
                table: "Activities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_WorkGroup_WorkGroupId",
                table: "Activities",
                column: "WorkGroupId",
                principalTable: "WorkGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherInfo_WorkGroup_WorkGroupId",
                table: "TeacherInfo",
                column: "WorkGroupId",
                principalTable: "WorkGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
