using OpenCharityAuction.Web.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.Models.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly Data.AuctionContext AuctionContext;

        public AuctionService(Data.AuctionContext context)
        {
            AuctionContext = context;
        }
    }
}
