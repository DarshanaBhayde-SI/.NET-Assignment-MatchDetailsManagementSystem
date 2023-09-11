using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    internal class UserInterface
    {
        public int GetMatchId()
        {
            Console.Write("Enter Match ID: ");
            int matchId = int.Parse(Console.ReadLine());
            return matchId;
        }

        public string GetSport()
        {
            Console.Write("Enter Sport: ");
            string sport = Console.ReadLine();
            return sport;
        }

        public DateTime GetMatchDateTime()
        {
            Console.Write("Enter Match Date and Time: ");
            DateTime matchDateTime = Convert.ToDateTime(Console.ReadLine());
            return matchDateTime;
        }

        public string GetLocation()
        {
            Console.Write("Enter Location of Match: ");
            string location = Console.ReadLine();
            return location;
        }

        public string GetHomeTeam()
        {
            Console.Write("Enter Home Team: ");
            string homeTeam = Console.ReadLine();
            return homeTeam;
        }

        public string GetAwayTeam()
        {
            Console.Write("Enter Away Team: ");
            string awayTeam = Console.ReadLine();
            return awayTeam;
        }

        public int GetHomeTeamScore()
        {
            Console.Write("Enter Home Team Score: ");
            int homeTeamScore = int.Parse(Console.ReadLine());
            return homeTeamScore;
        }

        public int GetAwayTeamScore()
        {
            Console.Write("Enter Away Team Score: ");
            int awayTeamScore = int.Parse(Console.ReadLine());
            return awayTeamScore;
        }
    }
}
