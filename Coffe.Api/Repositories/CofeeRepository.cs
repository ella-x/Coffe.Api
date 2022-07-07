using System;
using Coffe.Api.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Coffe.Api.Repositories
{
    public interface ICoffeeRepository
    {
        List<CoffeeRecord> Get();
        CoffeeRecord GetById(int id);
    }

    public class CofeeRepository : ICoffeeRepository
    {
        private readonly IConfiguration _configuration;
        public CofeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CoffeeRecord> Get()
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query = @"SELECT * FROM Records";

                var allTransactions = connection.Query<CoffeeRecord>(query);
                return allTransactions.ToList();
            }

        }
        public CoffeeRecord GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                var query = @"SELECT * FROM Records Where id = @id";

                var record = connection.QuerySingle<CoffeeRecord>(query,new { id = id });
                return record;
            }

        }

    }
}

