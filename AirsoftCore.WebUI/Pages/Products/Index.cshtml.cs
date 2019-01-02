using AirsoftCore.Application.Categories.Queries.GetAllCategories;
using AirsoftCore.Application.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Pages.Products
{
    public class ProductFilter
    {
        public IList<int> Brands { get; set; }
        public IList<int> Types { get; set; }
        public int ShowOnly { get; set; }
        public string Search { get; set; }
    }

    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ProductsListViewModel Products { get; private set; }
        //public IPagedList<Product> Products { get; set; }
        public int ProductGroup { get; set; }
        public IEnumerable<SelectListItem> ProductGroups { get; set; }
        public int ProductType { get; set; }
        public IEnumerable<SelectListItem> ProductTypes { get; set; }
        public int Brand { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public int Show { get; set; }
        public IEnumerable<SelectListItem> ShowOnly { get; set; }

        public async Task OnGetAsync(int? page, ProductFilter filter)
        {
            var viewModel = await _mediator.Send(new GetAllProductsQuery());

            var products = viewModel.Products;

            if (filter.Brands != null && filter.Brands.Any())
            {
                products = products.Where(t => filter.Brands.Contains(t.BrandId));
            }

            if (filter.Types != null && filter.Types.Any())
            {
                products = products.Where(t => filter.Types.Contains(t.ProductTypeId));
            }

            if (filter.ShowOnly > 0)
            {
                products = products.Take(filter.ShowOnly);
            }

            if (!string.IsNullOrEmpty(filter.Search))
            {
                products = products.Where(p => p.Descr == filter.Search);
            }

            ShowOnly = GetShowOnly();
            ProductGroups = await GetProductGroup();
            ProductTypes = await GetProductType();
            Brands = await GetBrands();

            viewModel.Products = products;

            Products = viewModel;
        }

        private async Task<IEnumerable<SelectListItem>> GetProductGroup()
        {
            var viewModel = await _mediator.Send(new GetAllBrandsQuery());

            var productGroup = viewModel.Brands.Select(n =>
                new SelectListItem
                {
                    Value = n.BrandId.ToString(),
                    Text = n.Descr
                }).ToList();

            var productGroupTip = new SelectListItem
            {
                Value = null,
                Text = @"Show"
            };

            productGroup.Insert(0, productGroupTip);

            return productGroup;
        }

        private IEnumerable<SelectListItem> GetShowOnly()
        {
            var showOnly = new List<SelectListItem>();

            showOnly.Add(
                new SelectListItem
                {
                    Value = 10.ToString(),
                    Text = @"10"
                });

            showOnly.Add(
                new SelectListItem
                {
                    Value = 25.ToString(),
                    Text = @"25"
                });

            showOnly.Add(
                new SelectListItem
                {
                    Value = 50.ToString(),
                    Text = @"50"
                });

            var showOnlyTip = new SelectListItem
            {
                Value = null,
                Text = @"Show"
            };

            showOnly.Insert(0, showOnlyTip);

            return showOnly;
        }

        private async Task<IEnumerable<SelectListItem>> GetProductType(ICollection<int> selected = null)
        {
            var viewModel = await _mediator.Send(new GetAllBrandsQuery());

            var productType = viewModel.Brands.Select(n =>
                new SelectListItem
                {
                    Value = n.BrandId.ToString(),
                    Text = n.Descr
                }).ToList();

            var productTypeTip = new SelectListItem
            {
                Value = null,
                Text = @"Choose product type"
            };

            productType.Insert(0, productTypeTip);

            foreach (var selectListItem in productType)
            {
                if (selected != null && selected.Any())
                {
                    if (selected.Contains(Convert.ToInt32(selectListItem.Value)))
                    {
                        selectListItem.Selected = true;
                    }
                }
            }

            return productType;
        }

        private async Task<IEnumerable<SelectListItem>> GetBrands(ICollection<int> selected = null)
        {
            var viewModel = await _mediator.Send(new GetAllBrandsQuery());

            var brands = viewModel.Brands.Select(n =>
                new SelectListItem
                {
                    Value = n.BrandId.ToString(),
                    Text = n.Descr
                }).ToList();

            var productGroupTip = new SelectListItem
            {
                Value = null,
                Text = @"Choose brand"
            };

            brands.Insert(0, productGroupTip);

            foreach (var selectListItem in brands)
            {
                if (selected != null && selected.Any())
                {
                    if (selected.Contains(Convert.ToInt32(selectListItem.Value)))
                    {
                        selectListItem.Selected = true;
                    }
                }
            }

            return brands;
        }
    }
}