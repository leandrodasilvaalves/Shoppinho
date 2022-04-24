using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoppinho.Lojas.Api.Migrations
{
    public partial class IniciarBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(120)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(120)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(9)", nullable: true),
                    DataCadastro = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UltimaAtualizacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(100)", nullable: true),
                    LojaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Lojas_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Lojas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    CodigoPais = table.Column<string>(type: "varchar(100)", nullable: false),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Whatsapp = table.Column<bool>(type: "bit", nullable: false),
                    LojaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => new { x.CodigoPais, x.DDD, x.Numero });
                    table.ForeignKey(
                        name: "FK_Telefones_Lojas_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Lojas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_LojaId",
                table: "Enderecos",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_LojaId",
                table: "Telefones",
                column: "LojaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Lojas");
        }
    }
}