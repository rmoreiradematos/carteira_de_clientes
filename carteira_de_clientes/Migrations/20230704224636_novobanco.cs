using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carteira_de_clientes.Migrations
{
    /// <inheritdoc />
    public partial class novobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordens_Servicos_ServicoId",
                table: "Ordens");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "OrdemDeServicos");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Servicos",
                newName: "PrecoServico");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "Ordens",
                newName: "FuncionarioServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordens_ServicoId",
                table: "Ordens",
                newName: "IX_Ordens_FuncionarioServicoId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Funcionarios",
                newName: "Funcao");

            migrationBuilder.AddColumn<string>(
                name: "DataLimite",
                table: "Ordens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DataRealizada",
                table: "Ordens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Ordens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Ordens",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PrecoOrdem",
                table: "Ordens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FuncionarioServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioServicos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioServicos_FuncionarioId",
                table: "FuncionarioServicos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioServicos_ServicoId",
                table: "FuncionarioServicos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordens_FuncionarioServicos_FuncionarioServicoId",
                table: "Ordens",
                column: "FuncionarioServicoId",
                principalTable: "FuncionarioServicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordens_FuncionarioServicos_FuncionarioServicoId",
                table: "Ordens");

            migrationBuilder.DropTable(
                name: "FuncionarioServicos");

            migrationBuilder.DropColumn(
                name: "DataLimite",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "DataRealizada",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "PrecoOrdem",
                table: "Ordens");

            migrationBuilder.RenameColumn(
                name: "PrecoServico",
                table: "Servicos",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "FuncionarioServicoId",
                table: "Ordens",
                newName: "ServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordens_FuncionarioServicoId",
                table: "Ordens",
                newName: "IX_Ordens_ServicoId");

            migrationBuilder.RenameColumn(
                name: "Funcao",
                table: "Funcionarios",
                newName: "Role");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    DateContract = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateLimit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrdemDeServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemDeServicos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemDeServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClienteId",
                table: "Contratos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ServicoId",
                table: "Contratos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServicos_FuncionarioId",
                table: "OrdemDeServicos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServicos_ServicoId",
                table: "OrdemDeServicos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordens_Servicos_ServicoId",
                table: "Ordens",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
