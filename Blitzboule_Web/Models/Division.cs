using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public enum League
    {
        DIAMOND, PLATINE, GOLD, SILVER, BRONZE
    }

    public class Division
    {
        public int Id { get; set; }
        public League League { get; set; }
        public string Name { get; set; }
    }
}