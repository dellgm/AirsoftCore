using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AirsoftCore.WebUI.ViewModels
{
    public class ProductCreate
    {
        [Required]
        public string Descr { get; set; }

        [Required]
        public string Model { get; set; }

        public decimal Price { get; set; }

        public short Stock { get; set; }

        public int ProductGroupId { get; set; }

        public int ProductTypeId { get; set; }

        public int BrandId { get; set; }

        public IFormFile Image { get; set; }
    }
}
