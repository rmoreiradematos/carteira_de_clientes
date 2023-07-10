using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace carteira_de_clientes.Migrations
{
    /// <inheritdoc />
    public partial class BancoChavaoInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Senha" },
                values: new object[] { "rodrigo@gmail.com", "-1029791530" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Senha" },
                values: new object[] { "rmoreiradematos@gmail.com", "-692273398" });
        }
    }
}
