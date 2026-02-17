using TournamentRankingS;

class Program
{
    public static void Main()
    {
        Tournament tournament = new Tournament();
        Team teamA = new Team { Name = "Team Alpha", Points = 0 };
        Team teamB = new Team { Name = "Team Beta", Points = 0 };
        Match match1 = new Match(teamA, teamB);
        tournament.ScheduleMatch(match1);
        tournament.RecordMatchResult(match1, 3, 1); // Team A wins
        Console.WriteLine(tournament.GetTeamRanking(teamB));
        var rankings = tournament.GetRankings();
        Console.WriteLine(rankings[0].Name); // Should output: Team Alpha

        tournament.UndoLastMatch();
        Console.WriteLine(teamA.Points);
    }
}