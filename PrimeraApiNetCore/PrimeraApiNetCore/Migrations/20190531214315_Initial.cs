using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeraApiNetCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 10, nullable: true),
                    Puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Alias = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoPlanificacion = table.Column<string>(nullable: false),
                    CalendarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planificaciones_Calendarios_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendariosUsuarios",
                columns: table => new
                {
                    CalendarioId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Propietario = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendariosUsuarios", x => new { x.CalendarioId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_CalendariosUsuarios_Calendarios_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendariosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetasUsuarios",
                columns: table => new
                {
                    RecetaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Propietario = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetasUsuarios", x => new { x.RecetaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_RecetasUsuarios_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetasUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanificacionReceta",
                columns: table => new
                {
                    PlanificacionId = table.Column<int>(nullable: false),
                    RecetaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanificacionReceta", x => new { x.RecetaId, x.PlanificacionId });
                    table.ForeignKey(
                        name: "FK_PlanificacionReceta_Planificaciones_PlanificacionId",
                        column: x => x.PlanificacionId,
                        principalTable: "Planificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanificacionReceta_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendariosUsuarios_UsuarioId",
                table: "CalendariosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Planificaciones_CalendarioId",
                table: "Planificaciones",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanificacionReceta_PlanificacionId",
                table: "PlanificacionReceta",
                column: "PlanificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetasUsuarios_UsuarioId",
                table: "RecetasUsuarios",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendariosUsuarios");

            migrationBuilder.DropTable(
                name: "PlanificacionReceta");

            migrationBuilder.DropTable(
                name: "RecetasUsuarios");

            migrationBuilder.DropTable(
                name: "Planificaciones");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Calendarios");
        }
    }
}
