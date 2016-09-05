using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCharityAuction.Entities.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Short Name

        public string Description { get; set; } // Long Description

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
