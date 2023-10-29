using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Manager.BirdManagement
{
    public class IndexModel : PageModel
    {
        private readonly IBirdService _birdService;
        private string isManager;

        public IndexModel(IBirdService birdService)
        {
            _birdService = birdService;
        }

        public IList<Bird> Bird { get;set; } = default!;

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

            Bird = _birdService.GetAllBirds();
            return Page();
        }
    }
}
