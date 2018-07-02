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
        //This is just a list of Flashcards
        public List<Flashcard> flashcards;
        // This is a select list object, it contains a list of the items for topics
        public SelectList topics;
        // flashcardTopic is a string containing the selected genre
        public string flashcardTopic { get; set; }
    }
}
