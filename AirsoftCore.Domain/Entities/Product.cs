using System.Collections.Generic;

namespace AirsoftCore.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductTypeId { get; set; }
        public int BrandId { get; set; }
        public string Descr { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public byte[] Image { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }
    }
}
