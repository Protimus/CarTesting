using ApplicationTest.Data.Models;
using ApplicationTest.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace ApplicationTest.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Car> _repository;
        private readonly IToastNotification _toastNotification;

        public EditModel(IRepository<Car> repository, IToastNotification toastNotification)
        {
            _repository = repository;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var car = await _repository.ReadAsync(id.Value);

            if (car == null)
                return NotFound();

            Car = car;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                await _repository.UpdateAsync(Car);
                if (Car.Price <= 5000)
                    this._toastNotification.AddSuccessToastMessage("Great job!");
                else
                {
                    return RedirectToPage("./Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                var car = await _repository.ReadAsync(Car.Id);
                if (car == null)
                    return NotFound();
                else
                    throw;
            }

            return Page();

            //return RedirectToPage("./Index");
        }
    }
}
