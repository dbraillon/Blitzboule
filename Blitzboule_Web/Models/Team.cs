using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public class Team
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int DivisionId { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 3)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public bool IsHuman { get; set; }

        [ScaffoldColumn(false)]
        public Player[] Players { get; set; }
    }
}