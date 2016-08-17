using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Web.ViewModels
{
    public class AddEventViewModel
    {
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime? EventDate { get; set; }

        public string UserId { get; set; }
    }
}
