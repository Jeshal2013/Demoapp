using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleDemoWithoutIdentity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string  firstName { get; set; }
        public string lastName { get; set; }

        public string? Adddress { get; set; }
    }
}
