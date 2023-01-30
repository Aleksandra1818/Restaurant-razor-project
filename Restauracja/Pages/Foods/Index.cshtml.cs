using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restauracja.Data;
using Restauracja.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restauracja.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly Restauracja.Data.RestauracjaContext _context;

        public IndexModel(Restauracja.Data.RestauracjaContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? FoodCategory { get; set; }

        public async Task OnGetAsync()
        {
            var foods = from m in _context.Food
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                foods = foods.Where(s => s.Name.Contains(SearchString) || s.Description.Contains(SearchString));
            }

            IQueryable<string> categoryQuery = from m in _context.Food
                                            orderby m.Category
                                            select m.Category;

            if (!string.IsNullOrEmpty(FoodCategory))
            {
                foods = foods.Where(x => x.Category == FoodCategory);
            }
            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());
            Food = await foods.ToListAsync();
        }
    }
}
