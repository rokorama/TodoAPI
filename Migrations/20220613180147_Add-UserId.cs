using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Users_UserId",
                table: "TodoTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
