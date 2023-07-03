using Microsoft.EntityFrameworkCore.Migrations;

namespace RamSoft.CodingTest.Core.Migrations
{
    public partial class changedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SccrumTasks_Statuses_StatusId",
                table: "SccrumTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SccrumTasks",
                table: "SccrumTasks");

            migrationBuilder.RenameTable(
                name: "SccrumTasks",
                newName: "ScrumTasks");

            migrationBuilder.RenameIndex(
                name: "IX_SccrumTasks_StatusId",
                table: "ScrumTasks",
                newName: "IX_ScrumTasks_StatusId");

            migrationBuilder.AddColumn<string>(
                name: "StatusName",
                table: "ScrumTasks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScrumTasks",
                table: "ScrumTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumTasks_Statuses_StatusId",
                table: "ScrumTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrumTasks_Statuses_StatusId",
                table: "ScrumTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScrumTasks",
                table: "ScrumTasks");

            migrationBuilder.DropColumn(
                name: "StatusName",
                table: "ScrumTasks");

            migrationBuilder.RenameTable(
                name: "ScrumTasks",
                newName: "SccrumTasks");

            migrationBuilder.RenameIndex(
                name: "IX_ScrumTasks_StatusId",
                table: "SccrumTasks",
                newName: "IX_SccrumTasks_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SccrumTasks",
                table: "SccrumTasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SccrumTasks_Statuses_StatusId",
                table: "SccrumTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
