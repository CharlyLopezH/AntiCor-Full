using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnticorAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ruspej_DT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adscripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetoRespo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelRiesgo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomicilioLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruspej_DT", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ruspej_DT");
        }
    }
}
