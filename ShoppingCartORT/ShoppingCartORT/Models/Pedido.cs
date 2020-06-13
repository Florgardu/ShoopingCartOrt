using System;
using System.Collections.Generic;
namespace ShoppingCartORT.Models
{
    public class Pedido
    {
        public int pedidoID { get; set; }
        public string nombre { get; set; }
        public Usuario usuario { get; set; }
        public List<Item> items { get; set; }
    }
}
