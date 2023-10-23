using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter Your UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Please Enter Your Confirm Password")]
        public string ConfirmPass { get; set; }

        public string WardId { get; set; }
        public string DistrictId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Address")]
        public string UserAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
    }
}
