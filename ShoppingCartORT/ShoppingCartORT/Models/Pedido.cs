using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCartORT.Data;

namespace ShoppingCartORT.Models
{
    public class Pedido
    {
        public int pedidoID { get; set; }
        public string nombre { get; set; }
        public Usuario usuario { get; set; }
        public List<Item> items { get; set; }

     
    
        public double ObtenerTotalPedido()
        {
            double SumaTotalPedido = 0;
            double ValorItem = 0;


            foreach (Item item in items)
            {
                ValorItem = item.ObtenerTotal();
                SumaTotalPedido = SumaTotalPedido + ValorItem;
            }

            return SumaTotalPedido;
        }



    }




}
