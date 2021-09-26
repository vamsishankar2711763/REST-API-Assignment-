using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class ProducerRepository
    {
        private string connectionString;
        public ProducerRepository()
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
        public void AddProducer(Producer producer)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Insert Into Producer (ProducerName,DOB,Company,Gender,Bio) VALUES (@ProducerName,@DOB,@Company,@Gender,@Bio)";
                dbConnection.Open();
                dbConnection.Execute(query, producer);
            }
        }
        public IEnumerable<Producer> GetAllProducerNames()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"Select ProducerName from Producer";
                dbConnection.Open();
                return dbConnection.Query<Producer>(query);
            }
        }

    }
}
