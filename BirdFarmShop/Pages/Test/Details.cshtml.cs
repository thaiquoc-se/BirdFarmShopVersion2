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
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DetailsModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

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
    }
}
