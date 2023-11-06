using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.CommentManagement
{
    public class IndexModel : PageModel
    {
        private readonly ICommentService _commentService;
        private string isManager;

        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IList<TblComment> TblComment { get;set; } = default!;

        public IActionResult OnGet()
        {
            try
            {
                isManager = HttpContext.Session.GetString("isManager")!;
                if (isManager != "MN")
                {
                    return NotFound();
                }
                if (isManager == null)
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
