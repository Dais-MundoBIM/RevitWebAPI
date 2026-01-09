using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase_Web.Migrations
{
    /// <inheritdoc />
    public partial class Ajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 🛑 IMPORTANTE: ELIMINA EL BLOQUE migrationBuilder.CreateTable(...) COMPLETO Y REEMPLAZALO CON ESTO:

            // Asumimos que la tabla ya existe (por eso el error) y solo cambiamos la columna Phone a tipo 'text' (string)
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "text", // Tipo de PostgreSQL para string
                nullable: false,
                oldClrType: typeof(int), // Indica que el tipo anterior era un entero
                oldType: "integer");
        }

        /// <inheritdoc />
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Hacemos el cambio inverso si necesitamos revertir
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Contacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
