using System.Configuration;
using System.Data;
using Dapper;
using Flashcards;
using Microsoft.Data.SqlClient;

string _localDBInstance = ConfigurationManager.AppSettings.Get("LocalDBInstance");
string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

UserInput input = new();

// Start the specified local db instance
// Create a local db instance if the specified local db doesn't exist
LocalDBInstance.CreateLocalDBInstance(_localDBInstance);

using (IDbConnection connection = new SqlConnection(_connectionString))
{
    // Create a database in the local db instance
    string sql_create_database = "CREATE DATABASE Flashcards";

    connection.Execute(sql_create_database);

    // Create tables in the database
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

// Show the main menu
input.ShowMainMenu();

// Stop the local db from running
LocalDBInstance.StopLocalDBInstance("FlashcardsDB");