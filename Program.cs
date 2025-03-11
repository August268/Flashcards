using System.Configuration;
using System.Data;
using Dapper;
using Flashcards;
using Microsoft.Data.SqlClient;

string _localDBInstance = ConfigurationManager.AppSettings.Get("LocalDBInstance");
string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

UserInput input = new();

LocalDBInstance.CreateLocalDBInstance(_localDBInstance);

using (IDbConnection connection = new SqlConnection(_connectionString))
{
    string sql_create_database = "CREATE DATABASE Flashcards";

    connection.Execute(sql_create_database);

    string sql = @"
        USE Flashcards

        IF OBJECT_ID(N'[dbo].[Stacks]', 'U') IS NULL
        BEGIN

        CREATE TABLE Stacks (
            Id int PRIMARY KEY IDENTITY(1, 1),
            Name VARCHAR(255) NOT NULL UNIQUE
        )
        CREATE TABLE Cards (
            Id int PRIMARY KEY IDENTITY(1, 1),
            Front VARCHAR(100) NOT NULL,
            Back VARCHAR(100) NOT NULL,
            StackId int NOT NULL FOREIGN KEY REFERENCES Stacks(Id)
        )
        END
    ";

    connection.Execute(sql);
}



input.ShowMainMenu();