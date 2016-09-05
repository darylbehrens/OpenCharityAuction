using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace OpenCharityAuction.Web.Data
{
    public class AuctionContext : DbContext
    {
        public AuctionContext()
        {

        }

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
        }

        // public DbSet<Entities.Models.Bidder> Bidders { get; set; }

        public DbSet<Entities.Models.Event> Events { get; set; }
        public DbSet<Entities.Models.AdmissionTicket> AdmissionTickets { get; set; }
        public DbSet<Entities.Models.Meal> Meals { get; set; }
    }
}
