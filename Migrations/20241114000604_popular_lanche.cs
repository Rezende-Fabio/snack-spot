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
                "('Pão Natural', 'Pão de forma integral, queijo, alface e tomate', 'Pão de forma integral, queijo, alface e tomate', 15.50, 'https://images.pexels.com/photos/3010753/pexels-photo-3010753.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', 'https://images.pexels.com/photos/3010753/pexels-photo-3010753.jpeg?auto=compress&cs=tinysrgb&w=500&h=127&dpr=1', true, false, 3),"+
                "('Misto PQO', 'Pão, queijo e ovo', 'Pão feito por nós, queijo feito por nossa fabrica e o ovo foi coletado de nossa granja', 25.90, 'https://images.pexels.com/photos/12336021/pexels-photo-12336021.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', 'https://images.pexels.com/photos/12336021/pexels-photo-12336021.jpeg?auto=compress&cs=tinysrgb&w=500&h=127&dpr=1', true, true, 4),"+
                "('California', 'Pão, hambúrguer, cebola e queijo', 'Pão de brioche, hambúrguer de patinho com pimenta do reino ao ponto, queijo prato derretido e cebola rocha empanada', 45.90, 'https://images.pexels.com/photos/1639557/pexels-photo-1639557.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1', 'https://images.pexels.com/photos/1639557/pexels-photo-1639557.jpeg?auto=compress&cs=tinysrgb&w=500&h=127&dpr=1', true, false, 5);");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Lanche\"");
        }
    }
}
