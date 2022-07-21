using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationTest.Data;
using ApplicationTest.Data.Models;
using ApplicationTest.Data.Repositories;

namespace ApplicationTest.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Car> _repository;

        public CreateModel(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Car == null)
            {
                return Page();
            }

            await _repository.CreateAsync(Car);
            return RedirectToPage("./Index");
        }
    }
}
