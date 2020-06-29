using System;
namespace ShoppingCartORT.Models
{
    public class PedidosDisplay
    {
        public string nombrePedido { get; set; } // Sale del obj pedido
        public string nombreUsuario { get; set; } // Sale del contexto
        public string producto { get; set; } // Es el nombre del producto, se obtiene de ese obj
        public int cantidad { get; set; } // sale del obj item para el producto en cuestion
        public double precio { get; set; } // cantidad * precio unitario de producto
    }
}
