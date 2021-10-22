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
using EventsApp.ViewModels;
using System.IO;

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
        [Authorize]
        public IActionResult Create()
        {
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "name");
            var organizers = _context.Organizer.Where(x => x.confirmed == true).ToList();
            ViewData["Organizers"] = organizers;
            var miejsca = _context.Place.Where(x=>x.confirmed==true).ToList();
            ViewData["Miejsca"] = miejsca;
            return View();
        }

        // POST: MainEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainEventId,title,description,dateStart,dateEnd,freeTickets,minPrice,maxPrice,name,province,city,address,type,picture,OrganizerName")] MainEventViewModel mainEventView)
        {
            if (ModelState.IsValid)
            {
                MainEvent mainEvent = new MainEvent
                {
                    title = mainEventView.title,
                    description = mainEventView.description,
                    dateStart = mainEventView.dateStart,
                    dateEnd = mainEventView.dateEnd,
                    freeTickets = mainEventView.freeTickets,
                    minPrice = mainEventView.minPrice,
                    maxPrice=mainEventView.maxPrice,
                    type = mainEventView.type,
                };
                //UserId
                User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                mainEvent.UserId = user.Id;

                //Picture
                using (var ms = new MemoryStream())
                {
                    mainEventView.picture.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    mainEvent.picture = fileBytes;
                }

                //PlaceId
                Place place = _context.Place.Where(x => x.name == mainEventView.name).FirstOrDefault();
                if (place != null) mainEvent.PlaceId = place.PlaceId;
                else
                {
                    Place p = new Place
                    {
                        name = mainEventView.name,
                        province = mainEventView.province,
                        city = mainEventView.city,
                        address = mainEventView.address,
                        confirmed = false
                    };
                    _context.Add(p);
                    _context.SaveChanges();
                    Place pl = _context.Place.Where(x => x.name == mainEventView.name).FirstOrDefault();
                    mainEvent.PlaceId = pl.PlaceId;
                }

                //Organizer
                Organizer organizer = _context.Organizer.Where(x => x.name == mainEventView.OrganizerName).FirstOrDefault();
                if (organizer != null) mainEvent.OrganizerId = organizer.OrganizerId;
                else
                {
                    Organizer o = new Organizer
                    {
                        name=mainEventView.OrganizerName,
                        confirmed=false
                    };
                    _context.Add(o);
                    _context.SaveChanges();
                    Organizer or = _context.Organizer.Where(x => x.name == mainEventView.OrganizerName).FirstOrDefault();
                    mainEvent.OrganizerId = or.OrganizerId;
                }
                _context.Add(mainEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "name", mainEventView.name);
            var organizers = _context.Organizer.Where(x => x.confirmed == true).ToList();
            ViewData["Organizers"] = organizers;
            var miejsca = _context.Place.Where(x => x.confirmed == true).ToList();
            ViewData["Miejsca"] = miejsca;
            return View(mainEventView);
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
            ViewData["OrganizerId"] = new SelectList(_context.Set<Organizer>(), "OrganizerId", "name", mainEvent.OrganizerId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "name", mainEvent.PlaceId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", mainEvent.UserId);
            var miejsca = _context.Place.ToList();
            ViewData["Miejsca"] = miejsca;
            return View(mainEvent);
        }

        // POST: MainEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainEventId,title,description,dateStart,dateEnd,freeTickets,minPrice,maxPrice,PlaceId,name,province,city,address,type,picture,UserId,OrganizerId")] MainEvent mainEvent)
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
            ViewData["OrganizerId"] = new SelectList(_context.Set<Organizer>(), "OrganizerId", "name", mainEvent.OrganizerId);
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "name", mainEvent.PlaceId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", mainEvent.UserId);
            var miejsca = _context.Place.ToList();
            ViewData["Miejsca"] = miejsca;
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
