using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNasColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Tb_Tasks",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tb_Tasks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Tb_Tasks",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "dataCriacao",
                table: "Tb_Tasks",
                newName: "DataCriacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Tb_Tasks",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tb_Tasks",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tb_Tasks",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Tb_Tasks",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Tb_Tasks",
                newName: "dataCriacao");

            migrationBuilder.AlterColumn<string>(
                name: "dataCriacao",
                table: "Tb_Tasks",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
