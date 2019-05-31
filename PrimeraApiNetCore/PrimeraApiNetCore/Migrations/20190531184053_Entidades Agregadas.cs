using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeraApiNetCore.Migrations
{
    public partial class EntidadesAgregadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planificacion",
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
                    table.PrimaryKey("PK_Planificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planificacion_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Alias = table.Column<string>(nullable: false),
                    CalendarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 10, nullable: true),
                    Puntuacion = table.Column<int>(nullable: false),
                    PlanificacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receta_Planificacion_PlanificacionId",
                        column: x => x.PlanificacionId,
                        principalTable: "Planificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarioUsuario",
                columns: table => new
                {
                    CalendarioId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Propietario = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarioUsuario", x => new { x.CalendarioId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_CalendarioUsuario_Calendario_CalendarioId",
                        column: x => x.CalendarioId,
                        principalTable: "Calendario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarioUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetaUsuario",
                columns: table => new
                {
                    RecetaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Propietario = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaUsuario", x => new { x.RecetaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_RecetaUsuario_Receta_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Receta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarioUsuario_UsuarioId",
                table: "CalendarioUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Planificacion_CalendarioId",
                table: "Planificacion",
                column: "CalendarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_PlanificacionId",
                table: "Receta",
                column: "PlanificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaUsuario_UsuarioId",
                table: "RecetaUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CalendarioId",
                table: "Usuario",
                column: "CalendarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarioUsuario");

            migrationBuilder.DropTable(
                name: "RecetaUsuario");

            migrationBuilder.DropTable(
                name: "Receta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Planificacion");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });
        }
    }
}
