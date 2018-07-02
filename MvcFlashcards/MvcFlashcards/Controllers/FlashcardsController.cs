using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFlashcards.Models;

namespace MvcFlashcards.Controllers
{
    public class FlashcardsController : Controller
    {
        private readonly MvcFlashcardsContext _context;

        public FlashcardsController(MvcFlashcardsContext context)
        {
            _context = context;
        }

        // This is used to override the index method below
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Flashcards
        // Searching ability, search the db for a flashcard with the word in question
        // This is the get method, since we specified ,method = "get" in index.cshtml, 
        // this method will be called instead
        public async Task<IActionResult> Index(string flashcardTopic, string searchString)
        {
            //This is a LINQ query
            var flashcards = from m in _context.Flashcard
                         select m;

            // Use LINQ to get the list of genres from the db
            IQueryable<string> genreQuery = from m in _context.Flashcard
                                            orderby m.Topic
                                            select m.Topic;

            // Movie is modified to filter on the value of the search string
            // Can work like this: ?searchString=Ghost
            // Since its called an id, as specified in startup.cs, the link becomes: .../index/blah
            if (!String.IsNullOrEmpty(searchString))
            {
                flashcards = flashcards.Where(s => s.Question.Contains(searchString));
            }

            // This is a search for movie genre
            if (!String.IsNullOrEmpty(flashcardTopic))
            {
                flashcards = flashcards.Where(x => x.Topic == flashcardTopic);
            }

            // Convert the list of topics to a select list object
            // Also get all the movies with that topic
            var flashcardTopicsVM = new FlashcardTopicViewModel();

            //This will also get rid of duplicates
            flashcardTopicsVM.topics = new SelectList(await genreQuery.Distinct().ToListAsync());
            flashcardTopicsVM.flashcards = await flashcards.ToListAsync();

            return View(flashcardTopicsVM);

            //return View(await flashcards.ToListAsync());
        }

        // GET: Flashcards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.Flashcard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flashcard == null)
            {
                return NotFound();
            }

            return View(flashcard);
        }

        // GET: Flashcards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flashcards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Question,AddedDate,Answer,Topic")] Flashcard flashcard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flashcard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flashcard);
        }

        // GET: Flashcards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.Flashcard.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }
            return View(flashcard);
        }

        // POST: Flashcards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Question,AddedDate,Answer,Topic")] Flashcard flashcard)
        {
            if (id != flashcard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flashcard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlashcardExists(flashcard.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flashcard);
        }

        // GET: Flashcards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.Flashcard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (flashcard == null)
            {
                return NotFound();
            }

            return View(flashcard);
        }

        // POST: Flashcards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flashcard = await _context.Flashcard.FindAsync(id);
            _context.Flashcard.Remove(flashcard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlashcardExists(int id)
        {
            return _context.Flashcard.Any(e => e.ID == id);
        }
    }
}
