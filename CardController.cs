using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Flashcards
{
    public class CardController
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        public List<Card> GetCards()
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = "SELECT * FROM Cards";

            return [.. connection.Query<Card>(sql)];
        }

        public Card GetCard(string id)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"SELECT * FROM Cards WHERE Id='{id}'";

            return connection.QueryFirstOrDefault<Card>(sql);
        }

        public void CreateCard(string frontText, string backText, string stackId)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"INSERT INTO Cards (Front, Back, StackId) VALUE ('{frontText}', '{backText}', '{stackId}')";

            connection.Execute(sql);
        }

        public void DeleteCard(string id)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"DELETE FROM Cards WHERE Id='{id}'";

            connection.Execute(sql);
        }

        public void UpdateCard(string id, string frontText, string backText, string stackId)
        {
            IDbConnection connection = new SqlConnection(_connectionString);

            string sql = $"UPDATE Cards SET Front='{frontText}', Back='{backText}', StackId='{stackId}' WHERE Id='{id}'";

            connection.Execute(sql);
        }
    }
}