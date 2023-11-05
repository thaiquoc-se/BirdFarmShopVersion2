using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Test
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public CreateModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BirdId"] = new SelectList(_context.Birds, "BirdId", "BirdDescription");
        ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public TblComment TblComment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblComments == null || TblComment == null)
            {
                return Page();
            }

            _context.TblComments.Add(TblComment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
