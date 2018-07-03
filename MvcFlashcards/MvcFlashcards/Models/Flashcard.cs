using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFlashcards.Models
{
    public class Flashcard
    {
        //ID is a must
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Question { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Answer { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Topic { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Source { get; set; }
    }
}
