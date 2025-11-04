using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoPreguntasIntento25.Migrations
{
    /// <inheritdoc />
    public partial class BancoPreguntas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListasPreguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespuestaCorrecta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespuestaIncorrecta1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespuestaIncorrecta2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespuestaIncorrecta3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asignatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidad = table.Column<int>(type: "int", nullable: false),
                    SubUnidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasPreguntas", x => x.PreguntaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_Usuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListasPreguntas");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
