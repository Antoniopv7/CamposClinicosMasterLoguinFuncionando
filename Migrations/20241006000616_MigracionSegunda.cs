using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class MigracionSegunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campo_Clinicos",
                columns: table => new
                {
                    Id_Campo_Clinico = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo_Clinicos", x => x.Id_Campo_Clinico);
                });

            migrationBuilder.CreateTable(
                name: "InstitucionesSalud",
                columns: table => new
                {
                    Id_Institucion_Salud = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitucionesSalud", x => x.Id_Institucion_Salud);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id_Presupuesto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MontoInicial = table.Column<float>(type: "real", nullable: false),
                    MontoActual = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id_Presupuesto);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Permisos = table.Column<string>(type: "text", nullable: false),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id_Rol);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Contraseña = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Centro_Costos",
                columns: table => new
                {
                    Id_Centro_Costo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PresupuestoAsignado = table.Column<float>(type: "real", nullable: false),
                    Responsable = table.Column<string>(type: "text", nullable: false),
                    Id_Presupuesto = table.Column<int>(type: "integer", nullable: false),
                    PresupuestoId_Presupuesto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centro_Costos", x => x.Id_Centro_Costo);
                    table.ForeignKey(
                        name: "FK_Centro_Costos_Presupuestos_PresupuestoId_Presupuesto",
                        column: x => x.PresupuestoId_Presupuesto,
                        principalTable: "Presupuestos",
                        principalColumn: "Id_Presupuesto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historial_Actividad",
                columns: table => new
                {
                    Id_Historial_Actividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Accion = table.Column<string>(type: "text", nullable: false),
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial_Actividad", x => x.Id_Historial_Actividad);
                    table.ForeignKey(
                        name: "FK_Historial_Actividad_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Institucion = table.Column<string>(type: "text", nullable: false),
                    TipoConvenio = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Id_Presupuesto = table.Column<int>(type: "integer", nullable: false),
                    Id_Institucion_Salud = table.Column<int>(type: "integer", nullable: false),
                    Id_Centro_Costo = table.Column<int>(type: "integer", nullable: false),
                    PresupuestoId_Presupuesto = table.Column<int>(type: "integer", nullable: false),
                    Institucion_SaludId_Institucion_Salud = table.Column<int>(type: "integer", nullable: false),
                    Centro_CostoId_Centro_Costo = table.Column<int>(type: "integer", nullable: false),
                    Campo_ClinicoId_Campo_Clinico = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id_Convenio);
                    table.ForeignKey(
                        name: "FK_Convenios_Campo_Clinicos_Campo_ClinicoId_Campo_Clinico",
                        column: x => x.Campo_ClinicoId_Campo_Clinico,
                        principalTable: "Campo_Clinicos",
                        principalColumn: "Id_Campo_Clinico");
                    table.ForeignKey(
                        name: "FK_Convenios_Centro_Costos_Centro_CostoId_Centro_Costo",
                        column: x => x.Centro_CostoId_Centro_Costo,
                        principalTable: "Centro_Costos",
                        principalColumn: "Id_Centro_Costo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Convenios_InstitucionesSalud_Institucion_SaludId_Institucio~",
                        column: x => x.Institucion_SaludId_Institucion_Salud,
                        principalTable: "InstitucionesSalud",
                        principalColumn: "Id_Institucion_Salud",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Convenios_Presupuestos_PresupuestoId_Presupuesto",
                        column: x => x.PresupuestoId_Presupuesto,
                        principalTable: "Presupuestos",
                        principalColumn: "Id_Presupuesto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devengados",
                columns: table => new
                {
                    Id_Devengado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false),
                    MontoComprometido = table.Column<decimal>(type: "numeric", nullable: false),
                    PagosRealizados = table.Column<decimal>(type: "numeric", nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "numeric", nullable: false),
                    DevengadoId_Devengado = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devengados", x => x.Id_Devengado);
                    table.ForeignKey(
                        name: "FK_Devengados_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devengados_Devengados_DevengadoId_Devengado",
                        column: x => x.DevengadoId_Devengado,
                        principalTable: "Devengados",
                        principalColumn: "Id_Devengado");
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id_Estudiante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Carrera = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: true),
                    ConvenioId_Convenio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id_Estudiante);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Convenios_ConvenioId_Convenio",
                        column: x => x.ConvenioId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesRetribucion",
                columns: table => new
                {
                    Id_Solicitud_Retribucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Solicitante = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    ConvenioId_Convenio = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesRetribucion", x => x.Id_Solicitud_Retribucion);
                    table.ForeignKey(
                        name: "FK_SolicitudesRetribucion_Convenios_ConvenioId_Convenio",
                        column: x => x.ConvenioId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campo_ClinicoEstudiante",
                columns: table => new
                {
                    Campo_ClinicosId_Campo_Clinico = table.Column<int>(type: "integer", nullable: false),
                    EstudiantesId_Estudiante = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo_ClinicoEstudiante", x => new { x.Campo_ClinicosId_Campo_Clinico, x.EstudiantesId_Estudiante });
                    table.ForeignKey(
                        name: "FK_Campo_ClinicoEstudiante_Campo_Clinicos_Campo_ClinicosId_Cam~",
                        column: x => x.Campo_ClinicosId_Campo_Clinico,
                        principalTable: "Campo_Clinicos",
                        principalColumn: "Id_Campo_Clinico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campo_ClinicoEstudiante_Estudiantes_EstudiantesId_Estudiante",
                        column: x => x.EstudiantesId_Estudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "Id_Estudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retribuciones",
                columns: table => new
                {
                    Id_Retribucion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    Id_Solicitud_Retribucion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retribuciones", x => x.Id_Retribucion);
                    table.ForeignKey(
                        name: "FK_Retribuciones_Convenios_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retribuciones_SolicitudesRetribucion_Id_Solicitud_Retribuci~",
                        column: x => x.Id_Solicitud_Retribucion,
                        principalTable: "SolicitudesRetribucion",
                        principalColumn: "Id_Solicitud_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id_Pago = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Id_Retribucion = table.Column<int>(type: "integer", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    RetribucionId_Retribucion = table.Column<int>(type: "integer", nullable: false),
                    ConvenioId_Convenio = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_Pagos_Convenios_ConvenioId_Convenio",
                        column: x => x.ConvenioId_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio");
                    table.ForeignKey(
                        name: "FK_Pagos_Retribuciones_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Retribuciones_RetribucionId_Retribucion",
                        column: x => x.RetribucionId_Retribucion,
                        principalTable: "Retribuciones",
                        principalColumn: "Id_Retribucion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campo_ClinicoEstudiante_EstudiantesId_Estudiante",
                table: "Campo_ClinicoEstudiante",
                column: "EstudiantesId_Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Centro_Costos_PresupuestoId_Presupuesto",
                table: "Centro_Costos",
                column: "PresupuestoId_Presupuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Campo_ClinicoId_Campo_Clinico",
                table: "Convenios",
                column: "Campo_ClinicoId_Campo_Clinico");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Centro_CostoId_Centro_Costo",
                table: "Convenios",
                column: "Centro_CostoId_Centro_Costo");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Institucion_SaludId_Institucion_Salud",
                table: "Convenios",
                column: "Institucion_SaludId_Institucion_Salud");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_PresupuestoId_Presupuesto",
                table: "Convenios",
                column: "PresupuestoId_Presupuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Devengados_ConvenioId",
                table: "Devengados",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Devengados_DevengadoId_Devengado",
                table: "Devengados",
                column: "DevengadoId_Devengado");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_ConvenioId_Convenio",
                table: "Estudiantes",
                column: "ConvenioId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Historial_Actividad_Id_Usuario",
                table: "Historial_Actividad",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ConvenioId_Convenio",
                table: "Pagos",
                column: "ConvenioId_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Id_Convenio",
                table: "Pagos",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_RetribucionId_Retribucion",
                table: "Pagos",
                column: "RetribucionId_Retribucion");

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_Id_Convenio",
                table: "Retribuciones",
                column: "Id_Convenio");

            migrationBuilder.CreateIndex(
                name: "IX_Retribuciones_Id_Solicitud_Retribucion",
                table: "Retribuciones",
                column: "Id_Solicitud_Retribucion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesRetribucion_ConvenioId_Convenio",
                table: "SolicitudesRetribucion",
                column: "ConvenioId_Convenio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campo_ClinicoEstudiante");

            migrationBuilder.DropTable(
                name: "Devengados");

            migrationBuilder.DropTable(
                name: "Historial_Actividad");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Retribuciones");

            migrationBuilder.DropTable(
                name: "SolicitudesRetribucion");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Campo_Clinicos");

            migrationBuilder.DropTable(
                name: "Centro_Costos");

            migrationBuilder.DropTable(
                name: "InstitucionesSalud");

            migrationBuilder.DropTable(
                name: "Presupuestos");
        }
    }
}
