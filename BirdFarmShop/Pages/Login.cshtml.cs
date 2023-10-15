using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public LoginModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
