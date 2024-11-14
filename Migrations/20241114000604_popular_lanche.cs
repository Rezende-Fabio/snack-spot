using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snack_spot.Migrations
{
    /// <inheritdoc />
    public partial class popular_lanche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Lanche\" (\"Nome\", \"DescricaoCurta\", \"DescricaoDetalhada\", \"Preco\", \"ImageUrl\", \"ThumbnailUrl\", \"IsLanchePreferido\", \"EmEstoque\", \"CategoriaId\") VALUES"+
                "('Pão Natural', 'Pão de forma integral, queijo, alface e tomate', 'Pão de forma integral, queijo, alface e tomate', 15.50, '', '', true, false, 3),"+
                "('Misto PQO', 'Pão, queijo e ovo', 'Pão feito por nós, queijo feito por nossa fabrica e o ovo foi coletado de nossa granja', 25.90, '', '', true, true, 4),"+
                "('California', 'Pão, hambúrguer, cebola e queijo', 'Pão de brioche, hambúrguer de patinho com pimenta do reino ao ponto, queijo prato derretido e cebola rocha empanada', 45.90, '', '', true, false, 5);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Lanche\"");
        }
    }
}
