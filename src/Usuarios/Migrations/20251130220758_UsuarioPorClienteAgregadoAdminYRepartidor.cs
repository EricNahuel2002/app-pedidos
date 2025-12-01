using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuarios.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioPorClienteAgregadoAdminYRepartidor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Usuarios",
                newName: "FechaCreacion");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Usuarios",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Usuarios",
                newName: "IdCliente");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Usuarios",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP(6)");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Usuarios",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Usuarios",
                newName: "UserId");
        }

    }
}
