using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards
{
    public class CardController
    {
        private readonly string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
    }
}