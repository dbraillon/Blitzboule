using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Name { get; set; }
        public bool IsHuman { get; set; }

        public Player[] Players { get; set; }
    }
}