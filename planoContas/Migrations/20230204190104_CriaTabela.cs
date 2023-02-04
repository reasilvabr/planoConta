using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planoContas.Migrations
{
    /// <inheritdoc />
    public partial class CriaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    CodigoConta = table.Column<string>(type: "varchar(50)", nullable: false),
                    CodigoContaPai = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    AceitaLancamento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.CodigoConta);
                    table.ForeignKey(
                        name: "FK_Contas_Contas_CodigoContaPai",
                        column: x => x.CodigoContaPai,
                        principalTable: "Contas",
                        principalColumn: "CodigoConta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_CodigoContaPai",
                table: "Contas",
                column: "CodigoContaPai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
