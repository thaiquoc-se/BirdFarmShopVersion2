using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Staff.BirdManagement
{
    public class IndexModel : PageModel
    {
        private readonly IBirdService _birdService;

        public IndexModel(IBirdService birdService)
        {
            _birdService = birdService;
        }

        public IList<Bird> Bird { get;set; } = default!;

        public void OnGet()
        {
            
                Bird = _birdService.GetAllBirds();
                
        }
    }
}
