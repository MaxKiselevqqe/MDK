using CIS.Data;
using CIS.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace CIS.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private ApplicationDbContext _context;
       public CatalogueController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Games> Get(string query = "")
        {
            return _context.Games.Where(s => s.Name.Contains(query)).ToList();
        }
    }
}
