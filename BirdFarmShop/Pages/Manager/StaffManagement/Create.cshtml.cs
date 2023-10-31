using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Manager.StaffManagement
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
        ViewData["DistrictName"] = new SelectList(_context.TblDistricts, "DistrictId", "DistrictName");
        ViewData["RoleId"] = new SelectList(_context.TblRoles, "RoleId", "RoleId");
        ViewData["WardName"] = new SelectList(_context.TblWards, "WardId", "WardName");
            return Page();
        }

        [BindProperty]
        public TblUser TblUser { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TblUsers == null || TblUser == null)
            {
                return Page();
            }

            _context.TblUsers.Add(TblUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
