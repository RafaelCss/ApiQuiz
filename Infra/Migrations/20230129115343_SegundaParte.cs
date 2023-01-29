using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class SegundaParte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ClassLevelCascadeMode",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RuleLevelCascadeMode",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "ClassLevelCascadeMode",
                table: "Perguntas");

            migrationBuilder.DropColumn(
                name: "RuleLevelCascadeMode",
                table: "Perguntas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassLevelCascadeMode",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleLevelCascadeMode",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Perguntas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassLevelCascadeMode",
                table: "Perguntas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleLevelCascadeMode",
                table: "Perguntas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
