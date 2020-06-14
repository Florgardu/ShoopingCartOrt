using System;
namespace ShoppingCartORT.Models
{
    public class Producto
    {
        public int productoID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string imagePath { get; set; }

    }
}
