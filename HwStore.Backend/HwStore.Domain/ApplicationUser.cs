using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Domain
{
    public class ApplicationUser : IdentityUser<int>
    {
        public UserAddress? Address { get; set; }
    }
}
