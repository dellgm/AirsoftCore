using AirsoftCore.Application.Categories.Queries.GetAllCategories;
using AirsoftCore.Application.Products.Queries.GetAllProducts;
using AirsoftCore.Application.ShoppingCarts.Commands.AddItemToCart;
using AirsoftCore.WebUI.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AirsoftCore.WebUI.Pages.Products
{

    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        public const string CartSessionKey = "CartId";

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ProductsListViewModel ProductsViewModel { get; private set; }
        public IEnumerable<SelectListItem> ProductGroups { get; private set; }
        public IEnumerable<SelectListItem> ProductTypes { get; private set; }
        public IEnumerable<SelectListItem> Brands { get; private set; }
        public IEnumerable<SelectListItem> ShowOnly { get; private set; }

        public async Task OnGetAsync(int? id, ProductFilter filter)
        {
            ShowOnly = GetShowOnly();
            ProductGroups = await GetProductGroup();
            ProductTypes = await GetProductType();
            Brands = await GetBrands();

            ProductsViewModel = await _mediator.Send(new GetAllProductsQuery
            {
                Page = id,
                Brands = filter.Brands,
                Types = filter.Types,
                ShowOnly = filter.ShowOnly,
                Search = filter.Search
            });
        }

        public async Task<IActionResult> OnGetAddToCartAsync(int id)
        {
            var result = await _mediator.Send(new AddItemToCartCommand { CartId = GetCartId(), ProductId = id });

            return RedirectToPage("/ShoppingCart/Index");
        }

        public string GetCartId()
        {
            if (HttpContext.Session.GetString(CartSessionKey) == null)
            {
                var tempCartId = Guid.NewGuid();
                HttpContext.Session.SetString(CartSessionKey, tempCartId.ToString());
            }

            return HttpContext.Session.GetString(CartSessionKey);
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
    }
}