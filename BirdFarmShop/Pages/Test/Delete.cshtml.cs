using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Test
{
    public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DeleteModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TblComment TblComment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TblComments == null)
            {
                return NotFound();
            }

            var tblcomment = await _context.TblComments.FirstOrDefaultAsync(m => m.CommentId == id);

            if (tblcomment == null)
            {
                return NotFound();
            }
            else 
            {
                TblComment = tblcomment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TblComments == null)
            {
                return NotFound();
            }
            var tblcomment = await _context.TblComments.FindAsync(id);

            if (tblcomment != null)
            {
                TblComment = tblcomment;
                _context.TblComments.Remove(TblComment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
