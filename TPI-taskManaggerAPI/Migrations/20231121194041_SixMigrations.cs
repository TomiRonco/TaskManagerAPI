using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPItaskManaggerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SixMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_AdminId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AdminId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AdminId1",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId1",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "AdminId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AdminId1",
                table: "Tasks",
                column: "AdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_AdminId1",
                table: "Tasks",
                column: "AdminId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
