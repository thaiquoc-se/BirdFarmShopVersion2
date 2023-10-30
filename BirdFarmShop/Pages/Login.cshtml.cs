﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositories.IRepository;
using Services.IServices;

namespace BirdFarmShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        public LoginModel(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [BindProperty]
        public TblUser user { get; set; } = default!;
        public string ErrorMessage { get; private set; }

        public IActionResult OnPost()
        {
            
            if(!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Pass))
            {
                try
                {
                    var check = _userService.checkLogin(user.UserName, user.Pass);
                    if (check != null)
                    {
                        if (check.RoleId.Equals("US"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            return RedirectToPage("HomePage");
                        }
                        if (check.RoleId.Equals("AD"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            HttpContext.Session.SetString("isAdmin", check.RoleId);
                            return RedirectToPage("Admin/UserManagement/ShowUserList");
                        }
                        if (check.RoleId.Equals("MN"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            HttpContext.Session.SetString("isManager", check.RoleId);
                            return RedirectToPage("Manager/StaffManagement/Index");
                        }
                        if (check.RoleId.Equals("ST"))
                        {
                            HttpContext.Session.SetInt32("UserID", check.UserId);
                            HttpContext.Session.SetString("isStaff", check.RoleId);
                            return RedirectToPage("Staff/BirdManagement/Index");
                        }
                    }
                    ErrorMessage = "Incorect User Name or Password Please Try Again";
                    return Page();
                }
                catch
                {
                    ErrorMessage = "Incorect User Name or Password Please Try Again";
                    return Page();
                }
               
                
            }

            return Page();
        }
    }
}
