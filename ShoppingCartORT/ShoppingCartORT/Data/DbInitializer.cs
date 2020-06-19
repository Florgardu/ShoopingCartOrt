using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCartORT.Models;

namespace ShoppingCartORT.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShoppingCartORTContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Productos.Any())
            {
                return;
            }
            var productos = new Producto[]
            {
                new Producto { nombre = "Leche", descripcion = "leche de almendras", precio = 150, imagePath ="lecheAlmendra.jpg" },
                new Producto { nombre = "Huevos", descripcion = "huevos blancos", precio = 50, imagePath ="huevos.jpg"  },
                new Producto { nombre = "Chocolate", descripcion = "70% cacao", precio = 100, imagePath ="chocolatePuro.jpg" },
                new Producto { nombre = "Blend de té seleccionado", descripcion = "Macbook Pro Retina display", precio = 300, imagePath ="te.jpg" },
                new Producto { nombre = "Cereales", descripcion = "Cereales de miel", precio = 200, imagePath ="cereales.jpg"},
                new Producto { nombre = "Vino tinto reserva", descripcion = "vino de roble francés", precio = 800, imagePath ="vinotinto.jpg" },
                new Producto { nombre = "Quesos gourmet", descripcion = "Picada de Quesos", precio = 1200, imagePath ="queso.jpg" },
            };
            foreach (Producto s in productos)
            {
                context.Productos.Add(s);
            }

            var UsuarioAdministrador = new Usuario { nombre = "Administrador", apellido = "Groso", dni = 37848976, mail = "admin@gmail.com", password = "admin123", rol = "ADMIN" };
            context.Usuarios.Add(UsuarioAdministrador);

            /*List<Item> items = new List<Item>();
            
            var item = new Item
            {
                cantidad = 2,
                producto = context.Productos.FirstOrDefault(prod => prod.productoID == 1)
            };

            items.Add(item);

            var pedido = new Pedido { nombre = "pedido001", usuario = { usucontext.Usuarios.FirstOrDefault(usu => usu.usuarioID == 1).usuarioID }, items = items };

            context.Pedidos.Add(pedido);*/

            var cantidadInsertada = context.SaveChanges();


        }
    }

}

