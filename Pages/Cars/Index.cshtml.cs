using ApplicationTest.Data.Models;
using ApplicationTest.Data.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApplicationTest.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Car> _repository;

        public IndexModel(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _repository.ReadAllAsync();
        }
    }
}
