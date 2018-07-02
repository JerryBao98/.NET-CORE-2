using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFlashcards.Models
{
    public class Flashcard
    {
        //ID is a must
        public int ID { get; set; }
        public string Question { get; set; }
        public DateTime AddedDate { get; set; }
        public string Answer { get; set; }
        public string Topic { get; set; }
    }
}
