using System.Collections.Generic;

namespace AirsoftCore.Application.ShoppingCarts.Queries.GetShoppingCart
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartDto> ShoppingCartItems { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalPriceWithVat { get; set; }
    }
}
