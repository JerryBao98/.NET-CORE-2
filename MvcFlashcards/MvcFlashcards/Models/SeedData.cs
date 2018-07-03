using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFlashcards.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcFlashcardsContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcFlashcardsContext>>()))
            {
                // Look for any flashcards.
                // If there are any, then no new ones are added
                if (context.Flashcard.Any())
                {
                    return;   // DB has been seeded
                }

                context.Flashcard.AddRange(
                     new Flashcard
                     {
                         Question = "Just a seeding test",
                         AddedDate = DateTime.Parse("1989-1-11"),
                         Answer = "No answer to this question",
                         Topic = "Chemistry",
                         Source = "Jerry"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
