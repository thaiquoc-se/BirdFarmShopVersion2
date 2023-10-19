using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepository;
using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace BirdFarmShop.Pages.Manager.StaffManagement
{
    
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> TblUser { get;set; } = default!;

        public void OnGet()
        {
            TblUser = _userRepository.GetAllUsers().Where(u => u.RoleId.Equals("ST")).ToList();
        }
    }
}
