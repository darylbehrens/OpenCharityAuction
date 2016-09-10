using OpenCharityAuction.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.ViewModels
{
    public class EditEventViewModel : AddEventViewModel
    {
        public int Id { get; set; }
    }
}
