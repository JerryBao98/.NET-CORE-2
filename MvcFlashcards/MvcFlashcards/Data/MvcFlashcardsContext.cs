using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcFlashcards.Models
{
    public class MvcFlashcardsContext : DbContext
    {
        public MvcFlashcardsContext (DbContextOptions<MvcFlashcardsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFlashcards.Models.Flashcard> Flashcard { get; set; }
    }
}
