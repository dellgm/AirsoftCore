using AirsoftCore.Application.Categories.Commands.CreateCategory;
using AirsoftCore.WebUI.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AirsoftCore.WebUI.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }


        [BindProperty]
        public BrandCreate Brand { get; set; }


        //public async Task<IActionResult> OnGetAsync()
        //{
        //    var result = await _mediator.Send(new GetAllCategoriesQuery());

        //    if (result == null)
        //    {
        //        Article = new ArticleCreate
        //        {
        //            Topic = UrlHelpers.SlugToTopic(slug)
        //        };
        //    }
        //    else
        //    {
        //        // TODO: Convert this to use a PageRoute
        //        return Redirect($"/{slug}/Edit");
        //    }

        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Brand.Descr))
            {
                ModelState.AddModelError("Brand.Descr", "Description must be not empty.");

                return Page();
            }

            await _mediator.Send(new CreateBrandCommand { Descr = Brand.Descr });

            return RedirectToPage("/Index");
        }
    }
}