using System;
using System.Collections.Generic;
namespace ShoppingCartORT.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public List<Producto> productos { get; set; }
    }
}
