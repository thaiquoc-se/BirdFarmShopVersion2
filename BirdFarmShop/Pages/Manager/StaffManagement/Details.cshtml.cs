﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace BirdFarmShop.Pages.Manager.StaffManagement
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Models.BirdFarmShopContext _context;

        public DetailsModel(BusinessObjects.Models.BirdFarmShopContext context)
        {
            _context = context;
        }

      public TblUser TblUser { get; set; } = default!;
        public string isManager;

        public async Task<IActionResult> OnGetAsync(int? id)
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
            if (id == null || _context.TblUsers == null)
            {
                return NotFound();
            }

            var tbluser = await _context.TblUsers.FirstOrDefaultAsync(m => m.UserId == id);
            if (tbluser == null)
            {
                return NotFound();
            }
            else 
            {
                TblUser = tbluser;
            }
            return Page();
        }
    }
}