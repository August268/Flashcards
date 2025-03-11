using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Flashcards
{
    public class StackController
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        public List<Stack> GetStacks()
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = "SELECT * FROM Stacks";

            return [.. connection.Query<Stack>(sql)];
        }

        public void CreateStack(string name)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"INSERT INTO Stacks (Name) VALUES ('{name}')";

            connection.Execute(sql);
        }

        public void DeleteStack(string id)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"DELETE FROM Stacks WHERE Id='{id}'";

            connection.Execute(sql);
        }

        public void UpdateStack(string id, string name)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"UPDATE Stacks SET Name='{name}' WHERE Id='{id}'";

            connection.Execute(sql);
        }
    }
}