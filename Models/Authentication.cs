
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iDss.X.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int branchid { get; set; }
        public string grouptype { get; set; }
        public DateTime? passexpireddate { get; set; }
        public bool passexpired { get; set; } = false;
        public int loginattempt { get; set; }
        public string securitycode { get; set; }
    }
}
