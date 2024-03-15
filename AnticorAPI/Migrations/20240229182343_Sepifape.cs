using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnticorAPI.Migrations
{
    /// <inheritdoc />
    public partial class Sepifape : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SegundoAp",
                table: "Sepifape_DT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SegundoAp",
                table: "Sepifape_DT",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
