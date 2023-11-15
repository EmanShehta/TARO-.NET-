using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taro.Repository.Identity.Migrations
{
    public partial class EditVideosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videos_courses_CourseId",
                table: "videos");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "videos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_videos_courses_CourseId",
                table: "videos",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videos_courses_CourseId",
                table: "videos");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "videos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_videos_courses_CourseId",
                table: "videos",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id");
        }
    }
}
