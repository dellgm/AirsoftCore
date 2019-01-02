namespace AirsoftCore.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int ShoppingCartId { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
