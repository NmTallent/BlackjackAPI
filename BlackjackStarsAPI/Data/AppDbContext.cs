using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace BlackjackStarsAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(string connectionString): base(connectionString)
        {

        }


        public IDbSet<LeaderboardEntity> entities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaderboardEntity>().ToTable("LeaderboardEntity");
        }
    }

}
