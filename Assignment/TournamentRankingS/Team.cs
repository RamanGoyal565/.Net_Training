namespace TournamentRankingS
{
    public class Match
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1OldPoints { get; set; }
        public int Team2OldPoints { get; set; }

        public Match(Team t1, Team t2)
        {
            Team1 = t1;
            Team2 = t2;
        }

        public Match Clone()
        {
            return new Match(Team1, Team2)
            {
                Team1OldPoints = Team1.Points,
                Team2OldPoints = Team2.Points
            };
        }
    }
    public class Team : IComparable<Team>
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public int CompareTo(Team other)
        {
            // TODO: Compare by points descending, then by name
            int compare = other.Points.CompareTo(this.Points);
            if (compare == 0)
                return other.Name.CompareTo(this.Name);
            return compare;
        }
    }
}