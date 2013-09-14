using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Sp { get; set; }
        public int En { get; set; }
        public int At { get; set; }
        public int Pa { get; set; }
        public int Bl { get; set; }
        public int Sh { get; set; }
        public int Ca { get; set; }
        public int Re { get; set; }
    }
}