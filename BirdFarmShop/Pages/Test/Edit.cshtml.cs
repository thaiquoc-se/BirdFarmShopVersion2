using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Test
{
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public EditModel(BusinessObjects.Models.BirdFarmShopContext context)
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

            var tblcomment =  await _context.TblComments.FirstOrDefaultAsync(m => m.CommentId == id);
            if (tblcomment == null)
            {
                return NotFound();
            }
            TblComment = tblcomment;
           ViewData["BirdId"] = new SelectList(_context.Birds, "BirdId", "BirdDescription");
           ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCommentExists(TblComment.CommentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblCommentExists(int id)
        {
          return (_context.TblComments?.Any(e => e.CommentId == id)).GetValueOrDefault();
        }
    }
}
