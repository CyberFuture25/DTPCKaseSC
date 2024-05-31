using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DTPCKase1._4.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "ImageUrl", "desc_prod", "nom_prod", "prec_prod", "stck_prod" },
                values: new object[,]
                {
                    { 1, 2, "", "Lumina Luxe es una carcasa para PC elegante y sofisticada diseñada para cautivar al entusiasta de los juegos que hay en cada chica gamer.", "Lumina Luxe", 580.0, 10 },
                    { 2, 2, "", "NovaFrost Nexus is the epitome of elegance and performance, tailored specifically for the discerning gamer girl. Its striking white chassis exudes a sense of purity and ", "NovaFrost Nexus", 600.0, 15 },
                    { 3, 2, "", "Esta carcasa para PC se inspira en el icónico Portal Gun de Rick de \"Rick y Morty\", y presenta líneas elegantes y elementos futuristas que recuerdan la estética del programa.", "Portal Gun Inspired PC Case", 700.0, 6 },
                    { 4, 2, "", "Abraza el poder de Dragon Balls con esta carcasa para PC inspirada en la icónica serie de anime. Con colores vibrantes, líneas elegantes y detalles intrincados que recuerdan al universo Dragon Ball, este estuche te transporta al mundo de Goku, Vegeta y sus batallas épicas contra enemigos poderosos.", "Dragon Ball Inspired PC Case", 699.0, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
