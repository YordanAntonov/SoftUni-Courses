using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Footballers.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PositionType",
                table: "Footballers",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "BestSkillType",
                table: "Footballers",
                newName: "BestSkill");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Footballers",
                newName: "PositionType");

            migrationBuilder.RenameColumn(
                name: "BestSkill",
                table: "Footballers",
                newName: "BestSkillType");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                table: "Coaches",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
