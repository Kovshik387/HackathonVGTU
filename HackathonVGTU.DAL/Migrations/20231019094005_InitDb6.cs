using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonVGTU.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDb6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonEntity_Schedules_ScheduleId",
                table: "LessonEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonEntity_Teachers_TeacherId",
                table: "LessonEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonEntity",
                table: "LessonEntity");

            migrationBuilder.RenameTable(
                name: "LessonEntity",
                newName: "Lessons");

            migrationBuilder.RenameIndex(
                name: "IX_LessonEntity_TeacherId",
                table: "Lessons",
                newName: "IX_Lessons_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonEntity_ScheduleId",
                table: "Lessons",
                newName: "IX_Lessons_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Schedules_ScheduleId",
                table: "Lessons",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Schedules_ScheduleId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Teachers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "LessonEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_TeacherId",
                table: "LessonEntity",
                newName: "IX_LessonEntity_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_ScheduleId",
                table: "LessonEntity",
                newName: "IX_LessonEntity_ScheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonEntity",
                table: "LessonEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonEntity_Schedules_ScheduleId",
                table: "LessonEntity",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonEntity_Teachers_TeacherId",
                table: "LessonEntity",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
