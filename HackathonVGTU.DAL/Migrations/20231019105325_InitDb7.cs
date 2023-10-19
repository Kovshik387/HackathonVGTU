using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonVGTU.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherEntityId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TeacherEntityId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherEntityId",
                table: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherEntityId",
                table: "Schedules",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherEntityId",
                table: "Schedules",
                column: "TeacherEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherEntityId",
                table: "Schedules",
                column: "TeacherEntityId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
