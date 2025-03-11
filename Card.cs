using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards
{
    public class Card
    {
        public int Id { get; set; }
        public required string Front { get; set; }
        public required string Back { get; set; }
        public int StackId { get; set; }
    }
}