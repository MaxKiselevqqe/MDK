using Microsoft.AspNetCore.Identity;

namespace CIS.Models
{
    public class Cart
    {
        
            public int Id { get; set; }
            public Games Games { get; set; }
            public IdentityUser User { get; set; }
        public int Quantity     { get; set; }
        }
    }
