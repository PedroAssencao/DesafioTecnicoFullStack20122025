using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    cat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    cat_finalidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__DD5DDDBDB4C6B17A", x => x.cat_id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    pes_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pes_nome = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    pes_idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pessoas__410B66F8CB6BFB3B", x => x.pes_id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    tra_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tra_descricao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    tra_valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tra_tipo = table.Column<int>(type: "int", nullable: false),
                    pes_id = table.Column<int>(type: "int", nullable: false),
                    cat_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transaco__9E078C13C03A993F", x => x.tra_id);
                    table.ForeignKey(
                        name: "FK_Transacoes_Categorias",
                        column: x => x.cat_id,
                        principalTable: "Categorias",
                        principalColumn: "cat_id");
                    table.ForeignKey(
                        name: "FK_Transacoes_Pessoas",
                        column: x => x.pes_id,
                        principalTable: "Pessoas",
                        principalColumn: "pes_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_cat_id",
                table: "Transacoes",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_pes_id",
                table: "Transacoes",
                column: "pes_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
