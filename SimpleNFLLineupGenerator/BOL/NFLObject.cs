using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNFLLineupGenerator.BOL
{
    public class NFLObject
    {
        public string PlayerFDId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public string Opponent { get; set; }
        public int Salary { get; set; }
        public double FantasyPoints { get; set; }
    }
}
