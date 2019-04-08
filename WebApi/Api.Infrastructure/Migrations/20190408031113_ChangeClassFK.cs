using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infrastructure.Migrations
{
    public partial class ChangeClassFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdTermCourseSubject",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdTermCourseSubject",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
