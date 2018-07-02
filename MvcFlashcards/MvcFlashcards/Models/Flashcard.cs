using System;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Answer { get; set; }
        public string Topic { get; set; }
    }
}
