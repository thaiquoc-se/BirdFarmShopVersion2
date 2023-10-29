using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Services.IServices;

namespace BirdFarmShop.Pages.Admin.OrderManagement
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private string isAdmin;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<TblOrder> TblOrder { get;set; } = default!;

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
            TblOrder = _orderService.GetAllOrders();
            return Page();
        }
    }
}
