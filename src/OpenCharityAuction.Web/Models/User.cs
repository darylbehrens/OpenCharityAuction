using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OpenCharityAuction.Web.Models
{
    public class User : IdentityUser
    {
        public int? ActiveEventId { get; set; }
    }

    public class Role: IdentityRole
    {

    }
}
