using System;
using System.Linq;


namespace ShoppingCartORT.Data
{
    public class DbInitializer
    {
        public static void Initialize(ShoppingCartORTContext context)
        {
            context.Database.EnsureCreated();
        }
}

}
