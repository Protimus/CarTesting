using ApplicationTest.Data.Models;
using ApplicationTest.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApplicationTest.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Car> _repository;

        public DetailsModel(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _repository.ReadAsync(id.Value);
            if (car == null)
                return NotFound();
            else
                Car = car;

            return Page();
        }
    }
}
