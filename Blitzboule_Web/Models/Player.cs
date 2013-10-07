using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Models
{
    public enum Position
    {
        LF, RF, MF, LD, RD, GL
    }

    public class Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
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

        public Player() { }
        public Player(Position position, Team team)
        {
            switch (position)
            {
                case Position.LF:
                    Name = "Attaquant 1";
                    Hp = 100; Sp = 60; En = 10; At = 3; Pa = 3; Bl = 3; Sh = 10; Ca = 1; Re = 60;
                    break;
                case Position.RF:
                    Name = "Attaquant 2";
                    Hp = 100; Sp = 60; En = 10; At = 3; Pa = 3; Bl = 3; Sh = 10; Ca = 1; Re = 60;
                    break;

                case Position.MF:
                    Name = "Milieu";
                    Hp = 100; Sp = 60; En = 5; At = 5; Pa = 10; Bl = 5; Sh = 5; Ca = 1; Re = 60;
                    break;

                case Position.LD:
                    Name = "Défenseur 1";
                    Hp = 100; Sp = 60; En = 3; At = 10; Pa = 3; Bl = 10; Sh = 3; Ca = 1; Re = 60;
                    break;
                case Position.RD:
                    Name = "Défenseur 2";
                    Hp = 100; Sp = 60; En = 3; At = 10; Pa = 3; Bl = 10; Sh = 3; Ca = 1; Re = 60;
                    break;

                case Position.GL:
                    Name = "Gardien";
                    Hp = 100; Sp = 60; En = 5; At = 5; Pa = 5; Bl = 5; Sh = 5; Ca = 10; Re = 60;
                    break;
            }

            TeamId = team.Id;
        }
    }
}