using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DespesaViagem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class create1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeViagem = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DescricaoViagem = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Adiantamento = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDespesas = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    StatusViagem = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatriculaFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomeDespesa = table.Column<string>(type: "varchar(30)", nullable: false),
                    DescricaoDespesa = table.Column<string>(type: "varchar(200)", nullable: false),
                    TotalDespesa = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataDespesa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoDespesa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesas_Viagem_Id",
                        column: x => x.Id,
                        principalTable: "Viagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespesaHospedagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    QuantidadeDias = table.Column<int>(type: "integer", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaHospedagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DespesaHospedagem_Despesas_Id",
                        column: x => x.Id,
                        principalTable: "Despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCasa = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_DespesaHospedagem_Id",
                        column: x => x.Id,
                        principalTable: "DespesaHospedagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "DespesaHospedagem");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Viagem");
        }
    }
}
