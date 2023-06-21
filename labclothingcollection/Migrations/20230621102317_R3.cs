using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace labclothingcollection.Migrations
{
    /// <inheritdoc />
    public partial class R3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Identificador", "Cpf", "Email", "Genero", "Nascimento", "Nome", "Status", "Telefone", "Tipo" },
                values: new object[,]
                {
                    { 1, "365412365", "teste@teste.com", "masculino", new DateTime(1990, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "João da Silva", "Ativo", "9512328", "Administrador" },
                    { 2, "874596321", "exemplo@example.com", "feminino", new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Souza", "Ativo", "987654321", "Gerente" },
                    { 3, "123456789", "usuario@dominio.com", "masculino", new DateTime(1998, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Santos", "Inativo", "456789123", "Criador" },
                    { 4, "987654321", "exemplo2@example.com", "feminino", new DateTime(1987, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana Rodrigues", "Ativo", "321654987", "Outro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Identificador",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Identificador",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Identificador",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Identificador",
                keyValue: 4);
        }
    }
}
