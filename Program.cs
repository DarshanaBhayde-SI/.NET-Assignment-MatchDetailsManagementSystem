namespace MatchDetailsManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            MatchManagement matchManager = new MatchManagement();

            char toContinue = 'Y';
            do
            {
                Console.WriteLine("************************** Choose an option **************************");
                Console.WriteLine("1. Add a Match");
                Console.WriteLine("2. Display All Matches");
                Console.WriteLine("3. Get Match by ID");
                Console.WriteLine("4. Update Match Score");
                Console.WriteLine("5. Remove Match by ID");
                Console.WriteLine("6. Sort Matches");
                Console.WriteLine("7. Filter Matches");
                Console.WriteLine("8. Display Statistics");
                Console.WriteLine("9. Search Matches");
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        MatchDetails newMatch = new MatchDetails();

                        newMatch.MatchId = ui.GetMatchId();
                        newMatch.Sport = ui.GetSport();
                        newMatch.MatchDateTime = ui.GetMatchDateTime();
                        newMatch.Location = ui.GetLocation();
                        newMatch.HomeTeam = ui.GetHomeTeam();
                        newMatch.AwayTeam = ui.GetAwayTeam();
                        newMatch.HomeTeamScore = ui.GetHomeTeamScore();
                        newMatch.AwayTeamScore = ui.GetAwayTeamScore();

                        matchManager.AddMatch(newMatch);
                        break;

                    case 2:
                        matchManager.DisplayAllMatches();
                        break;

                    case 3:
                        int id = ui.GetMatchId();
                        matchManager.GetMatchById(id);
                        break;

                    case 4:
                        int MatchId = ui.GetMatchId();
                        int HomeTeamScore = ui.GetHomeTeamScore();
                        int AwayTeamScore = ui.GetAwayTeamScore();
                        matchManager.UpdateMatchScore(MatchId, HomeTeamScore, AwayTeamScore);
                        break;

                    case 5:
                        Console.Write("Enter Match ID to remove: ");
                        int removeId = ui.GetMatchId();
                        matchManager.RemoveMatchById(removeId);
                        break;

                    case 6:

                        int sortContinue = 1;
                        do
                        {
                            Console.WriteLine("************************** Choose an option Sort **************************");
                            Console.WriteLine("location ->  Sort matches by location");
                            Console.WriteLine("sport    ->  Sort matches by sport");
                            Console.WriteLine("date     ->  matches by match date");
                            string criteria = Console.ReadLine();
                            Console.WriteLine("Ascending? (true/false)");
                            bool ascending = bool.Parse(Console.ReadLine());
                            matchManager.SortMatches(criteria, ascending);
                            matchManager.DisplayAllMatches();
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------- Press 1 to continue sorting: ---------------------------------------");
                            sortContinue = int.Parse(Console.ReadLine());

                        } while (sortContinue == 1);
                        break;

                    case 7:
                        int filterContinue = 1;
                        do
                        {
                            Console.WriteLine("************************** Choose an option to filter **************************");
                            Console.WriteLine("location ->  Filter matches by location");
                            Console.WriteLine("sport    ->  Filter matches by sport");
                            Console.WriteLine("date     ->  Filter matches by match date");
                            string filterCriteria = Console.ReadLine();
                            Console.WriteLine("Enter value: ");
                            string value = Console.ReadLine();
                            List<MatchDetails> filteredMatches = matchManager.FilterMatches(filterCriteria, value);
                            Console.WriteLine("\nFiltered Matches:");
                            foreach (var match in filteredMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}  Sport: {match.Sport}, MatchDateTime: {match.MatchDateTime}, Location: {match.Location}, HomeTeam: {match.HomeTeam}, AwayTeam: {match.AwayTeam}, HomeTeamScore: {match.HomeTeamScore}, AwayTeamScore: {match.AwayTeamScore}");
                            }
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------- Press 1 to continue sorting: ---------------------------------------");
                            sortContinue = int.Parse(Console.ReadLine());

                        } while (filterContinue == 1);
                        break;

                    case 8:
                        int statisticContinue = 1;
                        do
                        {
                            Console.WriteLine("************************** Choose an option to display statistic **************************:");
                            Console.WriteLine("averagescore");
                            Console.WriteLine("highestscore");
                            Console.WriteLine("lowestscore");
                            string statisticsCriteria = Console.ReadLine();
                            matchManager.CalculateStatistics(statisticsCriteria);
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------- Press 1 to continue statistics: ---------------------------------------");
                            sortContinue = int.Parse(Console.ReadLine());

                        } while (statisticContinue == 1);
                        break;

                    case 9:
                        int searchContinue = 1;
                        do
                        {
                            Console.WriteLine("************************** Enter value to search **************************:");
                            string keyword = Console.ReadLine();
                            List<MatchDetails> searchedMatches = matchManager.SearchMatches(keyword);
                            Console.WriteLine("\nSearched Matches:");
                            foreach (var match in searchedMatches)
                            {
                                Console.WriteLine($"Match ID: {match.MatchId}  Sport: {match.Sport}, MatchDateTime: {match.MatchDateTime}, Location: {match.Location}, HomeTeam: {match.HomeTeam}, AwayTeam: {match.AwayTeam}, HomeTeamScore: {match.HomeTeamScore}, AwayTeamScore: {match.AwayTeamScore}");
                            }
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------- Press 1 to continue sorting: ---------------------------------------");
                            sortContinue = int.Parse(Console.ReadLine());

                        } while (searchContinue == 1);
                        break;


                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("--------------------------------------- Enter y to continue: ---------------------------------------");
                toContinue = Convert.ToChar(Console.ReadLine());


            } while (toContinue == 'y' || toContinue == 'Y');

            Console.ReadKey();
        }
    }
}