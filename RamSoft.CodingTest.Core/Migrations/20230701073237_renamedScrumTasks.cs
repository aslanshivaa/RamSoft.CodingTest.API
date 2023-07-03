using Microsoft.EntityFrameworkCore.Migrations;

namespace RamSoft.CodingTest.Core.Migrations
{
    public partial class renamedScrumTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "SccrumTasks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StatusId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SccrumTasks_Statuses_StatusId",
                table: "SccrumTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SccrumTasks",
                table: "SccrumTasks");

            migrationBuilder.RenameTable(
                name: "SccrumTasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_SccrumTasks_StatusId",
                table: "Tasks",
                newName: "IX_Tasks_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
