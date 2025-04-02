using CIS.Data;
using CIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIS.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> uManager)
        {
            _userManager = uManager;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] int gameId)
        {
            var userId = _userManager.GetUserId(User);

            var item = _context.Carts.Where(x => x.User.Id == userId && x.Games.Id == gameId).FirstOrDefault();

            if (item == null)
            {
                item = new Cart();
                item.User = await _userManager.GetUserAsync(User);
                item.Games = _context.Games.Where(x => x.Id == gameId).FirstOrDefault();
                item.Quantity = 1;
                _context.Add(item);
                _context.SaveChanges();
                return Ok();
            }

            item.Quantity++;
            _context.Carts.Update(item);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPost("remove", Name = "remove")]
        public async Task<IActionResult>Remove([FromBody] int gameId)
        {
            var userId = _userManager.GetUserId(User);

           var item = _context.Carts.Where(x => x.Id == gameId).FirstOrDefault();

            if (item == null) { return BadRequest(); 
            }
            if (item.Quantity <= 1) _context.Carts.Remove(item);
            else
            {
                item.Quantity--;
                _context.Carts.Add(item);
            }
               _context.SaveChanges();
            return Ok(); 
        }
        [HttpGet]
        public List<Cart> GetCart()
        {
            var userId = _userManager.GetUserId(User);
            return _context.Carts.Include(x => x.Games).Where(x => x.User.Id == userId).ToList();
        }
    }
}