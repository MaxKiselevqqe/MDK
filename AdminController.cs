using CIS.Data;
using CIS.Models;
using Microsoft.AspNetCore.Mvc;
namespace CIS.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("addnewgame", Name="addnewgame")]
        public async Task<IActionResult> AddNewGame(Games data)
        {
            _context.Games.Add(data); 
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
