using AirsoftCore.Application.Categories.Queries.GetAllCategories;
using AirsoftCore.Application.Products.Commands.CreateProduct;
using AirsoftCore.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public ProductCreate Product { get; set; }

        public SelectList BrandSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            BrandSelectList = await PopulateDropDownList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                BrandSelectList = await PopulateDropDownList(Product.BrandId);

                return Page();
            }

            if (Product.Image == null)
            {
                ModelState.AddModelError("Product.Image", "Upload picture.");

                BrandSelectList = await PopulateDropDownList(Product.BrandId);

                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await Product.Image.CopyToAsync(memoryStream);

                await _mediator.Send(new CreateProductCommand
                {
                    Descr = Product.Descr,
                    Model = Product.Model,
                    Stock = Product.Stock,
                    Image = memoryStream.ToArray(),
                    Price = Product.Price,
                    BrandId = Product.BrandId,
                    ProductGroupId = Product.ProductGroupId,
                    ProductTypeId = Product.ProductTypeId
                });
            }

            return RedirectToPage("/Index");
        }

        private async Task<SelectList> PopulateDropDownList(object selected = null)
        {
            var categories = await _mediator.Send(new GetAllBrandsQuery());

            return new SelectList(categories.Brands, "BrandId", "Descr", selected);
        }
    }
}