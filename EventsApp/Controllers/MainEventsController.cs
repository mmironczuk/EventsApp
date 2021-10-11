using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsApp.Data;
using EventsApp.Models;

namespace EventsApp.Controllers
{
    public class MainEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MainEvents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Event.Include(m => m.Organizer).Include(m => m.Place).Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MainEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainEvent = await _context.Event
                .Include(m => m.Organizer)
                .Include(m => m.Place)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MainEventId == id);
            if (mainEvent == null)
            {
                return NotFound();
            }

            return View(mainEvent);
        }

        // GET: MainEvents/Create
        public IActionResult Create()
        {
            ViewData["OrganizerId"] = new SelectList(_context.Set<Organizer>(), "OrganizerId", "OrganizerId");
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "address");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "name");
            var miejsca = _context.Place.ToList();
            ViewData["Miejsca"] = miejsca;
            return View();
        }

        // POST: MainEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainEventId,title,description,dateStart,dateEnd,freeTickets,PlaceId,name,province,city,address,type,UserId,OrganizerId")] MainEvent mainEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerId"] = new SelectList(_context.Set<Organizer>(), "OrganizerId", "OrganizerId", mainEvent.OrganizerId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "address", mainEvent.PlaceId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", mainEvent.UserId);
            ViewBag.Miejsca = _context.Place.ToListAsync();
            return View(mainEvent);
        }

        // GET: MainEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainEvent = await _context.Event.FindAsync(id);
            if (mainEvent == null)
            {
                return NotFound();
            }
            ViewData["OrganizerId"] = new SelectList(_context.Set<Organizer>(), "OrganizerId", "OrganizerId", mainEvent.OrganizerId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "address", mainEvent.PlaceId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", mainEvent.UserId);
            return View(mainEvent);
        }

        // POST: MainEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainEventId,title,description,dateStart,dateEnd,freeTickets,PlaceId,name,province,city,address,type,UserId,OrganizerId")] MainEvent mainEvent)
        {
            if (id != mainEvent.MainEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEventExists(mainEvent.MainEventId))
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
            ViewData["OrganizerId"] = new SelectList(_context.Set<Organizer>(), "OrganizerId", "OrganizerId", mainEvent.OrganizerId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "address", mainEvent.PlaceId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", mainEvent.UserId);
            return View(mainEvent);
        }

        // GET: MainEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainEvent = await _context.Event
                .Include(m => m.Organizer)
                .Include(m => m.Place)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MainEventId == id);
            if (mainEvent == null)
            {
                return NotFound();
            }

            return View(mainEvent);
        }

        // POST: MainEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainEvent = await _context.Event.FindAsync(id);
            _context.Event.Remove(mainEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainEventExists(int id)
        {
            return _context.Event.Any(e => e.MainEventId == id);
        }
    }
}
