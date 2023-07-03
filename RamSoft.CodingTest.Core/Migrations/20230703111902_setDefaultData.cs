using Microsoft.EntityFrameworkCore.Migrations;

namespace RamSoft.CodingTest.Core.Migrations
{
    public partial class setDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrumTasks_Statuses_StatusId",
                table: "ScrumTasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ScrumTasks",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ScrumTasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "StatusId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ScrumTasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "StatusId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumTasks_Statuses_StatusId",
                table: "ScrumTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrumTasks_Statuses_StatusId",
                table: "ScrumTasks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "ScrumTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "ScrumTasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ScrumTasks",
                keyColumn: "TaskId",
                keyValue: 2,
                column: "StatusId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumTasks_Statuses_StatusId",
                table: "ScrumTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
