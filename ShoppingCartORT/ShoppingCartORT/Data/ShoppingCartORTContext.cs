using System;
using ShoppingCartORT.Models;
using Microsoft.EntityFrameworkCore;



namespace ShoppingCartORT.Data
{

    public class ShoppingCartORTContext : DbContext
    {
        public ShoppingCartORTContext()
        {
        }

        public ShoppingCartORTContext(DbContextOptions<ShoppingCartORTContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Items { get; set; }

    }



}
