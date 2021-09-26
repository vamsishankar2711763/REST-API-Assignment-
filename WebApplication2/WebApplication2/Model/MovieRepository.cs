using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class MovieRepository
    {
        private string connectionString;
        public MovieRepository()
        {
            connectionString = @"Data Source=MSI;Initial Catalog=ApplicationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public int AddMovie(Movie movie)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Insert Into Movie (MovieName,ReleaseDate,Plot,Poster)
                                    OUTPUT INSERTED.[MovieId] 
                                VALUES (@MovieName,@ReleaseDate,@Plot,@Poster);";
                dbConnection.Open();
                var id = dbConnection.QuerySingle<int>(query, new { MovieName = movie.MovieName, ReleaseDate = movie.ReleaseDate, Plot = movie.Plot, Poster = movie.Poster });
                return id;
            }
        }

        public void AddActorMovie(int movieId, List<int> actorId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                foreach(var ite in actorId)
                {
                    string query = @"Insert Into ActorMovie(MovieId,ActorId) VALUES (@MovieId,@ActorId);";
                    dbConnection.Execute(query, new { MovieId = movieId, ActorId = ite });
                }
            }
        }

        public void AddProducerMovie(int movieId, List<int> producerId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                foreach (var ite in producerId)
                {
                    string query = @"Insert Into ProducerMovie(MovieId,ProducerId) VALUES (@MovieId,@ProducerId);";
                    dbConnection.Execute(query, new { MovieId = movieId, ProducerId = ite });
                }
            }
        }

        public IEnumerable<ReturnMovie> ReturnMovies()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "select MovieName,ProducerName,ActorName,ReleaseDate,Plot INTO #Tem from Movie inner join ActorMovie on Movie.MovieId = ActorMovie.MovieId inner join ProducerMovie on Movie.MovieId = ProducerMovie.MovieId inner join Producer on Producer.ProducerId = ProducerMovie.ProducerId inner join Actor on Actor.ActorId = ActorMovie.ActorId; select distinct MovieName, ActorName into #ActorName from #Tem; select distinct MovieName, ProducerName into #ProducerName from #Tem; SELECT MovieName, Actors = STUFF( (SELECT ',' + ActorName FROM #ActorName FOR XML PATH ('')), 1, 1, '' ) into #ActorsConc FROM #ActorName GROUP BY MovieName; SELECT MovieName, Producers = STUFF( (SELECT ',' + ProducerName FROM #ProducerName FOR XML PATH ('')), 1, 1, '' ) into #ProducersConc FROM #ProducerName GROUP BY MovieName; select distinct A.MovieName, AC.Actors, PC.Producers, A.ReleaseDate, A.Plot from #Tem A inner join #ActorsConc AC on A.MovieName = AC.MovieName inner join #ProducersConc PC on A.MovieName = PC.MovieName;";
                dbConnection.Open();
                var result = dbConnection.Query<ReturnMovie>(query);
                return result;
            }
        }

    }
}
