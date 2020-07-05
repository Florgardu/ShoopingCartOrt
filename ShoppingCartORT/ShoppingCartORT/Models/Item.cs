using System;
using System.Collections.Generic;
namespace ShoppingCartORT.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public int cantidad { get; set; }
        public Producto producto { get; set; }
        public Pedido pedido { get; set; } // Agregamos al pedido que corresponde.


        public double ObtenerTotal()
        {
            double precioTotalItem = this.producto.precio * this.cantidad;
            return precioTotalItem;
        }
    }

}
