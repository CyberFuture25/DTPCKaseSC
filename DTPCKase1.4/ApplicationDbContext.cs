using System.Collections.Generic;
using DTPCKase1._4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DTPCKase1._4
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                  modelBuilder.Entity<Categoria>().HasData(
                  new Categoria { Id = 1, nom_categoria = "PC Cases", DisplayOrder = 1 },
                  new Categoria { Id = 2, nom_categoria = "Laptop Skins", DisplayOrder = 2 },
                  new Categoria { Id = 3, nom_categoria = "Mousepads", DisplayOrder = 3 }
                  );

            modelBuilder.Entity<Producto>().HasData(
  new Producto
  {
      Id = 1,
      nom_prod = "Lumina Luxe",
      desc_prod = "Lumina Luxe es una carcasa para PC elegante y sofisticada diseñada para " +
      "cautivar al entusiasta de los juegos que hay en cada chica gamer.",
      stck_prod = 10,
      prec_prod = 580,
      CategoriaId = 2,
      ImageUrl = ""

  },
  new Producto
  {
      Id = 2,
      nom_prod = "NovaFrost Nexus",
      desc_prod = "NovaFrost Nexus is the epitome of elegance and performance, tailored specifically for the discerning gamer girl. Its striking white chassis exudes a sense of purity and ",
      stck_prod = 15,
      prec_prod = 600,
      CategoriaId = 2,
      ImageUrl = ""

  },
  new Producto
  {
      Id = 3,
      nom_prod = "Portal Gun Inspired PC Case",
      desc_prod = "Esta carcasa para PC se inspira en el icónico Portal Gun de Rick de \"Rick y Morty\", y presenta líneas elegantes y elementos futuristas que recuerdan la estética del programa.",
      stck_prod = 6,
      prec_prod = 700,
      CategoriaId = 2,
      ImageUrl = ""


  },
  new Producto
  {
      Id = 4,
      nom_prod = "Dragon Ball Inspired PC Case",
      desc_prod = "Abraza el poder de Dragon Balls con esta carcasa para PC inspirada en la icónica serie de anime. Con colores vibrantes, líneas elegantes y detalles intrincados que recuerdan al universo Dragon Ball, este estuche te transporta al mundo de Goku, Vegeta y sus batallas épicas contra enemigos poderosos.",
      stck_prod = 25,
      prec_prod = 699,
      CategoriaId = 2,
      ImageUrl = ""

  }
  );


        }
    }
}
