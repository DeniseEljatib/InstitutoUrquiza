using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstitutoUrquiza.Migrations
{
    public partial class InstitutoUrquizaContextInstitutoUrquizaDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 20, nullable: false),
                    Dni = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Nivel = table.Column<int>(nullable: false),
                    cuotaAlDia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(maxLength: 20, nullable: false),
                    Dni = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    esActivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horario = table.Column<DateTime>(nullable: false),
                    Salon = table.Column<int>(nullable: false),
                    ProfesorId = table.Column<int>(nullable: false),
                    Actividad = table.Column<int>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clases_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clases_EstudianteId",
                table: "Clases",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_ProfesorId",
                table: "Clases",
                column: "ProfesorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
