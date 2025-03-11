// Geting connection string from App.config
using System.Configuration;
using System.Data;
using Flashcards;
using Microsoft.Data.SqlClient;

string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

UserInput input = new UserInput();

IDbConnection connection = new SqlConnection(_connectionString);

sql = @"
    CREATE TABLE Stacks
";
