using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private static UserDAO instance = null!;

        private static readonly object instanceLock = new object();
        private readonly BirdFarmShopContext _context;

        public UserDAO()
        {
            _context = new BirdFarmShopContext();
        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _context.TblUsers
                .Include(t => t.District)
                .Include(t => t.Role)
                .Include(t => t.Ward).ToList();

            List<UserDTO> userList = new List<UserDTO>();
            foreach (var user in users)
            {
                var _user = new UserDTO()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserAddress = user.UserAddress + ", " + user.Ward!.WardName + ", " + user.District!.DistrictName,
                    FullName = user.FullName,
                    UserStatus = user.UserStatus,
                    RoleId = user.RoleId,
                    RoleName = user.Role.RoleName!,
                    Pass = user.Pass,
                    Email = user.Email,
                    Phone = user.Phone,
                };

                userList.Add(_user);
            }

            return userList;
        }
    }
}
