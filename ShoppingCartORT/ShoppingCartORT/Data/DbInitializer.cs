using System;
using System.Linq;
using ShoppingCartORT.Models;

namespace ShoppingCartORT.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShoppingCartORTContext context)
        {
            context.Database.EnsureCreated();

            if (context.Productos.Any())
            {
                return;
            }
            var productos = new Producto[]
            {
                new Producto { nombre = "Leche", descripcion = "leche de almendras", precio = 150 },
                new Producto { nombre = "Huevos", descripcion = "huevos blancos", precio = 50 },
                new Producto { nombre = "Chocolate", descripcion = "70% cacao", precio = 100 },
            };
            foreach (Producto s in productos)
            {
                context.Productos.Add(s);
            }
            var cantidadInsertada = context.SaveChanges();


        }
    }

}

