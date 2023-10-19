using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HackathonVGTU.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Auditorium",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Lesson",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "TeacherEntityId",
                table: "Schedules",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessonEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Auditorium = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LessonOrder = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonEntity_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonEntity_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherEntityId",
                table: "Schedules",
                column: "TeacherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonEntity_ScheduleId",
                table: "LessonEntity",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonEntity_TeacherId",
                table: "LessonEntity",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherEntityId",
                table: "Schedules",
                column: "TeacherEntityId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherEntityId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "LessonEntity");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_TeacherEntityId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherEntityId",
                table: "Schedules");

            migrationBuilder.AddColumn<string>(
                name: "Auditorium",
                table: "Schedules",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lesson",
                table: "Schedules",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
