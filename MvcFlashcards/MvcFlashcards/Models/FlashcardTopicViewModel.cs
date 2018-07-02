using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFlashcards.Models
{
    // Create the view model and add in the needed parameters
    public class FlashcardTopicViewModel
    {
        public List<Flashcard> flashcards;
        public SelectList topics;
        public string flashcardTopic { get; set; }
    }
}
