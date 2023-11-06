using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.CommentManagement
{
    public class IndexModel : PageModel
    {
        private readonly ICommentService _commentService;
        private string isAdmin;

        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IList<TblComment> TblComment { get;set; } = default!;

        public IActionResult OnGet()
        {
            try
            {
                isAdmin = HttpContext.Session.GetString("isAdmin")!;
                if (isAdmin != "AD")
                {
                    return NotFound();
                }
                if (isAdmin == null)
                {
                    return NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            TblComment = _commentService.GetAllCommnets();
            return Page();
        }
    }
}
