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
                new Producto { nombre = "Computadora", descripcion = "Macbook Pro Retina display", precio = 250000 },
                new Producto { nombre = "Iphone XS", descripcion = "Nuevo Iphone XS", precio = 150000 },
                new Producto { nombre = "TV 50 Pulgadas SONY", descripcion = "Televisión de 50 Pulgadas 4k SONY", precio = 80000 },
                new Producto { nombre = "Remera Billabong M", descripcion = "Remera Billabong Talle M - Surf Experience", precio = 1200 },
            };
            foreach (Producto s in productos)
            {
                context.Productos.Add(s);
            }
            var cantidadInsertada = context.SaveChanges();


        }
    }

}

