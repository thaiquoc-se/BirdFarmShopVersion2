using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessObjects.DTOs;
using Repositories.IRepository;

namespace BirdFarmShop.Pages.Admin.UserManagement
{
    public class ShowUserListModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public ShowUserListModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<UserDTO> TblUser { get;set; } = default!;

        
        public string isAdmin = null!;

        public IActionResult OnGet()
        {
            try
            {
                isAdmin = HttpContext.Session.GetString("isAdmin")!;
                if (isAdmin != "AD")
                {
                   return NotFound();
                }
                if(isAdmin == null)
                {
                  return  NotFound();
                }
            }
            catch
            {
                NotFound();
            }
            TblUser = _userRepository.GetAllUsers().Where(u => !u.RoleId.Equals("AD")).ToList();
            return Page();
        }
    }
}
