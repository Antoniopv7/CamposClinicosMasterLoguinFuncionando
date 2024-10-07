using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gestion_Del_Presupuesto.Migrations
{
    /// <inheritdoc />
    public partial class _3eraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centro_Costos_Presupuestos_PresupuestoId_Presupuesto",
                table: "Centro_Costos");

            migrationBuilder.AlterColumn<int>(
                name: "PresupuestoId_Presupuesto",
                table: "Centro_Costos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "PresupuestoAsignado",
                table: "Centro_Costos",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "Costo",
                columns: table => new
                {
                    Id_Costo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costo", x => x.Id_Costo);
                    table.ForeignKey(
                        name: "FK_Costo_Convenios_Id_Convenio",
                        column: x => x.Id_Convenio,
                        principalTable: "Convenios",
                        principalColumn: "Id_Convenio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturacion",
                columns: table => new
                {
                    Id_Facturacion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cliente = table.Column<string>(type: "text", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    NumeroFactura = table.Column<int>(type: "integer", nullable: false),
                    Id_Convenio = table.Column<int>(type: "integer", nullable: true),
                    Institucion = table.Column<string>(type: "text", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturacion", x => x.Id_Facturacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costo_Id_Convenio",
                table: "Costo",
                column: "Id_Convenio");

            migrationBuilder.AddForeignKey(
                name: "FK_Centro_Costos_Presupuestos_PresupuestoId_Presupuesto",
                table: "Centro_Costos",
                column: "PresupuestoId_Presupuesto",
                principalTable: "Presupuestos",
                principalColumn: "Id_Presupuesto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centro_Costos_Presupuestos_PresupuestoId_Presupuesto",
                table: "Centro_Costos");

            migrationBuilder.DropTable(
                name: "Costo");

            migrationBuilder.DropTable(
                name: "Facturacion");

            migrationBuilder.AlterColumn<int>(
                name: "PresupuestoId_Presupuesto",
                table: "Centro_Costos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PresupuestoAsignado",
                table: "Centro_Costos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddForeignKey(
                name: "FK_Centro_Costos_Presupuestos_PresupuestoId_Presupuesto",
                table: "Centro_Costos",
                column: "PresupuestoId_Presupuesto",
                principalTable: "Presupuestos",
                principalColumn: "Id_Presupuesto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
