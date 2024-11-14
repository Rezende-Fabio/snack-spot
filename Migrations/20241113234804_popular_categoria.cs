using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snack_spot.Migrations
{
    /// <inheritdoc />
    public partial class popular_categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Categoria\" (\"Nome\", \"Descricao\") VALUES"+
                "('Natural', 'Lanche feito com ingredientes naturais e pão integral'),"+
                "('Caseiro', 'Lanche feito com ingredientes feitos por nós'),"+
                "('Gourmet', 'Lanche feito com ingredientes diferenciados com um tamanho maior');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Categoria\"");
        }
    }
}
