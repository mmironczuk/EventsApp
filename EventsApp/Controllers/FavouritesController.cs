using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventsApp.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Favourites
        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            //var applicationDbContext = _context.Favourites.Include(f => f.MainEvent).Include(f => f.User).Where(f=>f.UserId==user.Id);
            List<MainEvent> applicationDbContext = new List<MainEvent>();
            var favourites = _context.Favourites.Include(x => x.MainEvent).Include(x=>x.MainEvent.Organizer).Include(x=>x.MainEvent.Place).Include(x=>x.MainEvent.Opinions)
                .Where(x => x.UserId == user.Id).ToList();
            foreach (Favourites f in favourites)
            {
                applicationDbContext.Add(f.MainEvent);
            }
            return View(applicationDbContext);
        }

        // GET: Favourites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites
                .Include(f => f.MainEvent)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FavouritesId == id);
            if (favourites == null)
            {
                return NotFound();
            }

            return View(favourites);
        }

        // GET: Favourites/Create
        public IActionResult Create()
        {
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Favourites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavouritesId,MainEventId,UserId")] Favourites favourites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favourites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title", favourites.MainEventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", favourites.UserId);
            return View(favourites);
        }

        // GET: Favourites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favourites = await _context.Favourites.FindAsync(id);
            if (favourites == null)
            {
                return NotFound();
            }
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title", favourites.MainEventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", favourites.UserId);
            return View(favourites);
        }

        // POST: Favourites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavouritesId,MainEventId,UserId")] Favourites favourites)
        {
            if (id != favourites.FavouritesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favourites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouritesExists(favourites.FavouritesId))
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
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title", favourites.MainEventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", favourites.UserId);
            return View(favourites);
        }

        // GET: Favourites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var favourites = await _context.Favourites
            //    .Include(f => f.MainEvent)
            //    .Include(f => f.User)
            //    .FirstOrDefaultAsync(m => m.FavouritesId == id);
            //if (favourites == null)
            //{
            //    return NotFound();
            //}
            User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var favourite = _context.Favourites.Where(x => x.MainEventId == id && x.UserId == user.Id).FirstOrDefault();
            _context.Favourites.Remove(favourite);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            //return View(favourites);
        }

        // POST: Favourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var favourites = await _context.Favourites.FindAsync(id);
            //_context.Favourites.Remove(favourites);
            //await _context.SaveChangesAsync();
            User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var favourite = _context.Favourites.Where(x => x.MainEventId == id && x.UserId == user.Id).FirstOrDefault();
            _context.Favourites.Remove(favourite);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouritesExists(int id)
        {
            return _context.Favourites.Any(e => e.FavouritesId == id);
        }
    }
}
