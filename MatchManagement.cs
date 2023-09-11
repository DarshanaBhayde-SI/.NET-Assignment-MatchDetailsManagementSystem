using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDetailsManagementSystem
{
    internal class MatchManagement
    {

        public static List<MatchDetails> matches = new List<MatchDetails>()
        {
            new MatchDetails() { MatchId = 1, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Mumbai", HomeTeam = "India", AwayTeam = "Australia", HomeTeamScore = 300, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 2, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Pune", HomeTeam = "India", AwayTeam = "England", HomeTeamScore = 200, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 3, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Gujrat", HomeTeam = "India", AwayTeam = "Pakistan", HomeTeamScore = 600, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 4, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "NewYork", HomeTeam = "India", AwayTeam = "NewZealand", HomeTeamScore = 400, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 5, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Mumbai", HomeTeam = "India", AwayTeam = "SriLanka", HomeTeamScore = 350, AwayTeamScore = 200},
            new MatchDetails() { MatchId = 6, Sport = "Cricket", MatchDateTime = DateTime.Now.AddHours(1), Location = "Ahemdabad", HomeTeam = "India", AwayTeam = "WestIndies", HomeTeamScore = 200, AwayTeamScore = 200},
        };

        public void AddMatch(MatchDetails match)
        {
            if (match.MatchId <= 0 || matches.Any(m => m.MatchId == match.MatchId))
            {
                Console.WriteLine("Invalid Match ID. Match ID must be a positive unique integer.");
                return;
            }
            if (string.IsNullOrEmpty(match.Sport))
            {
                Console.WriteLine("Sport cannot be empty or null.");
                return;
            }
            if (string.IsNullOrEmpty(match.Location))
            {
                Console.WriteLine("Location cannot be empty or null.");
                return;
            }
            if (string.IsNullOrEmpty(match.HomeTeam))
            {
                Console.WriteLine("HomeTeam cannot be empty or null.");
                return;
            }
            if (string.IsNullOrEmpty(match.AwayTeam))
            {
                Console.WriteLine("AwayTeam cannot be empty or null.");
                return;
            }
            if (match.HomeTeam == match.AwayTeam)
            {
                Console.WriteLine("Home Team and Away Team should be different!!");
                return;
            }
            if (match.HomeTeamScore < 0 || match.AwayTeamScore < 0)
            {
                Console.WriteLine("HomeTeamScore & AwayTeamScore must be non-negative integers");
                return;
            }
            if (match.Location.Length > 15)
            {
                Console.WriteLine("Maximum 15 characters can be added for location");
                return;
            }
            if (match.HomeTeam.Length > 15)
            {
                Console.WriteLine("Maximum 15 characters can be added for HomeTeam");
                return;
            }
            if (match.AwayTeam.Length > 15)
            {
                Console.WriteLine("Maximum 15 characters can be added for AwayTeam");
                return;
            }
            if (match.Sport.Length > 15)
            {
                Console.WriteLine("Maximum 15 characters can be added for Sport");
                return;
            }
            matches.Add(match);
            Console.WriteLine("Match Added Successfully.");
        }

        public void DisplayAllMatches()
        {
            foreach (var match in matches)
            {
                Console.WriteLine($"Match ID: {match.MatchId}  Sport: {match.Sport}, MatchDateTime: {match.MatchDateTime}, Location: {match.Location}, HomeTeam: {match.HomeTeam}, AwayTeam: {match.AwayTeam}, HomeTeamScore: {match.HomeTeamScore}, AwayTeamScore: {match.AwayTeamScore}");
            }
        }

        public void GetMatchById(int matchId)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                Console.WriteLine($"Match ID: {match.MatchId}  Sport: {match.Sport}, MatchDateTime: {match.MatchDateTime}, Location: {match.Location}, HomeTeam: {match.HomeTeam}, AwayTeam: {match.AwayTeam}, HomeTeamScore: {match.HomeTeamScore}, AwayTeamScore: {match.AwayTeamScore}");
            }
            else
            {
                Console.WriteLine("Match Not Found.");
            }
        }

        public void UpdateMatchScore(int matchId, int homeTeamScore, int awayTeamScore)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                match.HomeTeamScore = homeTeamScore;
                match.AwayTeamScore = awayTeamScore;
                Console.WriteLine("Match Scores Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Match not found.");
            }
        }

        public void RemoveMatchById(int matchId)
        {
            var match = matches.FirstOrDefault(m => m.MatchId == matchId);
            if (match != null)
            {
                matches.Remove(match);
                Console.WriteLine("Match Removed Successfully.");
            }
            else
            {
                Console.WriteLine("Match not found.");
            }
        }

        public void SortMatches(string criteria, bool ascending)
        {
            switch (criteria.ToLower())
            {
                case "date":
                    matches = ascending ? matches.OrderBy(m => m.MatchDateTime).ToList() : matches.OrderByDescending(m => m.MatchDateTime).ToList();
                    break;
                case "sport":
                    matches = ascending ? matches.OrderBy(m => m.Sport).ToList() : matches.OrderByDescending(m => m.Sport).ToList();
                    break;
                case "location":
                    matches = ascending ? matches.OrderBy(m => m.Location).ToList() : matches.OrderByDescending(m => m.Location).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid Sorting Criteria.");
                    break;
            }
        }

        public List<MatchDetails> FilterMatches(string criteria, string value)
        {
            switch (criteria.ToLower())
            {
                case "sport":
                    return matches.Where(m => m.Sport.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                case "location":
                    return matches.Where(m => m.Location.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                case "daterange":
                    DateTime startDate;
                    DateTime endDate;
                    if (DateTime.TryParse(value.Split('-')[0], out startDate) && DateTime.TryParse(value.Split('-')[1], out endDate))
                    {
                        return matches.Where(m => m.MatchDateTime >= startDate && m.MatchDateTime <= endDate).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid date range format. Use format 'yyyy-mm-dd - yyyy-mm-dd'.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid filtering criteria.");
                    break;
            }
            return new List<MatchDetails>();
        }

        public void CalculateStatistics(string criteria)
        {
            switch (criteria.ToLower())
            {
                case "averagescore":
                    double homeAvg = matches.Average(m => m.HomeTeamScore);
                    double awayAvg = matches.Average(m => m.AwayTeamScore);
                    Console.WriteLine($"Average Score - Home: {homeAvg}, Away: {awayAvg}");
                    break;
                case "highestscore":
                    int highestHomeScore = matches.Max(m => m.HomeTeamScore);
                    int highestAwayScore = matches.Max(m => m.AwayTeamScore);
                    Console.WriteLine($"Highest Score - Home: {highestHomeScore}, Away: {highestAwayScore}");
                    break;
                case "lowestscore":
                    int lowestHomeScore = matches.Min(m => m.HomeTeamScore);
                    int lowestAwayScore = matches.Min(m => m.AwayTeamScore);
                    Console.WriteLine($"Lowest Score - Home: {lowestHomeScore}, Away: {lowestAwayScore}");
                    break;
                default:
                    Console.WriteLine("Invalid statistics criteria."); 
                    break;
            }
        }

        public List<MatchDetails> SearchMatches(string keyword)
        {
            return matches.Where(m =>
                m.Sport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                m.HomeTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                m.AwayTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                m.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

    }
}
