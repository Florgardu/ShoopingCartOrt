using System;
using System.Collections.Generic;
namespace ShoppingCartORT.Models
{
    public class PedidoDTO
    {
        public List<PedidoItemDTO> pedidos { get; set; } // lista de pedidos para mostrar
        public double precio { get; set; } // cantidad * precio unitario de producto
    }
}
