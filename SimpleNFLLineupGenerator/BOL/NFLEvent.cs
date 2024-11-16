using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNFLLineupGenerator.BOL
{
    public class NFLEvent
    {
        public string EntryId { get; set; }
        public string ContestId { get; set; }
        public string ContestName { get; set; }
        public string QB { get; set; }
        public string RB1 { get; set; }
        public string RB2{ get; set; }
        public string RB3 { get; set; }
        public string WR1 { get; set; }
        public string WR2 { get; set; }
        public string WR3 { get; set; }
        public string TE { get; set; }
        public string FLEX { get; set; }
        public string D { get; set; }
    }
}
