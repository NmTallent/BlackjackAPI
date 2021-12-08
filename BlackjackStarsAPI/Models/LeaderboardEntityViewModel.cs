namespace BlackjackStarsAPI.Controllers
{
    internal class LeaderboardEntityViewModel
    {
        public LeaderboardEntityViewModel()
        {
            Entities = new List<LeaderboardEntity>();
        }

        public List<LeaderboardEntity> Entities { get;  set; }
    }
}