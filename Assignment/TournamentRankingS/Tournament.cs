using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentRankingS
{
    public class Tournament
    {
        private SortedList<int, Team> _rankings = new SortedList<int, Team>();
        private LinkedList<Match> _schedule = new LinkedList<Match>();
        private Stack<Match> _undoStack = new Stack<Match>();

        // Add match to schedule
        public void ScheduleMatch(Match match)
        {
            // TODO: Add to linked list
            _schedule.AddLast(match);
        }

        // Record match result and update rankings
        public void RecordMatchResult(Match match, int team1Score, int team2Score)
        {
            _undoStack.Push(match.Clone());
            // TODO: Update team points and re-sort rankings
            if (team1Score > team2Score)
                match.Team1.Points += 3;
            else if (team1Score < team2Score)
                match.Team2.Points += 3;
            else
            {
                match.Team1.Points += 1;
                match.Team2.Points += 1;
            }
            RebuildRankings();
        }

        // Undo last match
        public void UndoLastMatch()
        {
            // TODO: Use stack to revert last match
            if (_undoStack.Count == 0)
                return;
            Match match = _undoStack.Pop();
            match.Team1.Points =match.Team1OldPoints ;
            match.Team2.Points =match.Team2OldPoints ;
            RebuildRankings();
        }
        private void RebuildRankings()
        {
            _rankings.Clear();
            List<Team> sorted = _schedule.SelectMany(m => new[] { m.Team1, m.Team2 }).Distinct().OrderBy(t => t).ToList();
            for(int i=0;i<sorted.Count;i++) 
                _rankings.Add(i,sorted[i]);
        }
        // Get ranking position using binary search
        public int GetTeamRanking(Team team)
        {
            // TODO: Implement ranking lookup
            return _rankings.IndexOfValue(team)+1;
        }
        public SortedList<int,Team> GetRankings()
        {
            return _rankings;
        }
    }
}
