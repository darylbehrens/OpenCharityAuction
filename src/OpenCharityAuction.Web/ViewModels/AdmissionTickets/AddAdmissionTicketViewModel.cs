using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.ViewModels
{
    public class AddAdmissionTicketViewModel
    {
        [Required]
        [Display(Name = "Ticket Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ticket Cost")]
        public decimal Cost { get; set; }
    }
}
