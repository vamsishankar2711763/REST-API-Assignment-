using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class ActorRepository
    {
        private string connectionString;
        public ActorRepository()
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
        public void AddActor(Actor actor)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Insert Into Actor (ActorName,Bio,DOB,Gender) VALUES (@ActorName,@Bio,@DOB,@Gender)";
                dbConnection.Open();
                dbConnection.Execute(query, actor);
            }
        }
        public IEnumerable<Actor> GetAllActorNames()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Select * from Actor";
                dbConnection.Open();
                return dbConnection.Query<Actor>(query);
                
            }
        }
    }
}
