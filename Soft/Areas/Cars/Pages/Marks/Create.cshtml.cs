﻿using System.Threading.Tasks;
using Loppprojekt.Domain.Cars.Marks;
using Loppprojekt.Pages.Cars.Marks;
using Microsoft.AspNetCore.Mvc;

namespace Loppprojekt.Soft.Areas.Cars.Pages.Marks
{
    public class CreateModel : MarksPage
    {
        public CreateModel(IMarksRepository r) : base(r)
        {
        }

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await addObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }
    }
}
