using BlackjackStarsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace BlackjackStarsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : Controller
    {
        private AppDbContext _dbContext;

        public LeaderboardController()
        {
          

        }

        [HttpGet(Name = "GetLeaderBoard")]
        public string GetLeaderboard()
        {
            var connetionString = "Server = tcp:blackjackstars.database.windows.net, 1433;" +
                "Initial Catalog = BlackjackStars; User ID = blackjack; Password =capstone1!;";
            SqlConnection conn = new SqlConnection(connetionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT TOP 5 * FROM leaderboard ORDER BY WINS DESC";
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            var list = new List<LeaderboardEntity>();  
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                var leaderboardEntity = new LeaderboardEntity();
                leaderboardEntity.firstName = item["firstname"].ToString();
                leaderboardEntity.lastName = item["lastname"].ToString();
                leaderboardEntity.wins = Convert.ToInt32(item["wins"].ToString());
                list.Add(leaderboardEntity);    
            }


            return JsonConvert.SerializeObject(list);
        }


        [HttpPost(Name = "UpdateLeaderBoard")]
        public HttpStatusCode UpdateLeaderboard(LeaderboardEntity entity)
        {
            var connetionString = "Server = tcp:blackjackstars.database.windows.net, 1433;" +
                "Initial Catalog = BlackjackStars; User ID = blackjack; Password =capstone1!;";
            SqlConnection conn = new SqlConnection(connetionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            
            cmd.CommandText = $"INSERT INTO [dbo].[leaderboard] values('{entity.firstName}','{entity.lastName}', {entity.wins})";
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);

            return HttpStatusCode.OK;
        }



    }
}
