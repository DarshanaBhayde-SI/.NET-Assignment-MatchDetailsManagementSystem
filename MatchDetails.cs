using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    internal class MatchDetails
    {
        public int MatchId { get; set; }
        public string Sport { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Location { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
