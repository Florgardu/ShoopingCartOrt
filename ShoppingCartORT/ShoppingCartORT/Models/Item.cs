using System;
using System.Collections.Generic;
namespace ShoppingCartORT.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public int cantidad { get; set; }
        public Producto producto { get; set; }
    }
}
