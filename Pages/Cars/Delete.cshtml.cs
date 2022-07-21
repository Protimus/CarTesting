using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationTest.Data;
using ApplicationTest.Data.Models;
using ApplicationTest.Data.Repositories;
using NToastNotify;

namespace ApplicationTest.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Car> _repository;
        private readonly IToastNotification _toastNotification;

        public DeleteModel(IRepository<Car> repository, IToastNotification toastNotification)
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
            else 
                Car = car;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var car = await _repository.ReadAsync(id.Value);

            if (car != null)
            {
                Car = car;
                await _repository.DeleteAsync(car.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
