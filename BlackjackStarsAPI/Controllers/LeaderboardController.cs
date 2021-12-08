using BlackjackStarsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace BlackjackStarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : Controller
    {
        private AppDbContext _dbContext;

        public LeaderboardController()
        {
            _dbContext = new AppDbContext("Server = tcp:blackjackstars.database.windows.net, 1433; Initial Catalog = BlackjackStars; Persist Security Info = False; User ID = blackjack; Password =capstone1!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }

        [HttpGet(Name = "GetLeaderBoard")]
        public ActionResult Index()
        {
            var viewModel = new LeaderboardEntityViewModel();
            viewModel.Entities = _dbContext.entities.ToList();


            return View(new LeaderboardEntityViewModel());
        }
    }
}
