using BirdFarmShop.Entities;
using BirdFarmShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdFarmShop.Pages
{
    public class CheckOutModel : PageModel
    {
        public List<Item> cart { get; set; }
        public decimal Total { get; set; }
        public IActionResult OnPost()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            Total = cart.Sum(i => i.bird.Price * i.Quantity);
            

            return RedirectToPage("ShowAllBirds");
        }
    }
}
