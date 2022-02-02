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
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Ticket.Include(t => t.MainEvent).Include(t => t.User);
            //return View(await applicationDbContext.ToListAsync());
            User user = await _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefaultAsync();
            List<Ticket> tickets = await _context.Ticket.Include(x => x.MainEvent).Where(x => x.UserId == user.Id).ToListAsync();
            List<MainEvent> events = new List<MainEvent>();
            foreach(var t in tickets)
            {
                if (!events.Contains(t.MainEvent)) events.Add(t.MainEvent);
            }
            ViewBag.tickets = tickets;

            return View(events);
        }

        public async Task<IActionResult> DeleteTickets(int id)
        {
            List<Ticket> tickets = await _context.Ticket.Where(x => x.MainEventId == id).ToListAsync();
            MainEvent mainEvent = await _context.Event.FindAsync(id);
            mainEvent.freeTickets += tickets.Count;
            foreach (var t in tickets)
            {
                _context.Remove(t);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.MainEvent)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        public JsonResult TicketAction(int count, int id)
        {
            MainEvent mainEvent = _context.Event.Find(id);
            if (mainEvent == null) return Json(new { success = false, msg = "Error" }); ;

            if (mainEvent.freeTickets >= count)
            {
                User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                for (int i = 0; i < count; i++)
                {
                    Ticket ticket = new Ticket
                    {
                        MainEventId = id,
                        UserId = user.Id
                    };
                    _context.Add(ticket);
                }
                mainEvent.freeTickets -= count;
                _context.SaveChanges();
                return Json(new { success = true, msg = "Dodane" });
            }
            else
            {
                return Json(new { success = false, msg = "Too many tickets" });
            }
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,MainEventId,UserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title", ticket.MainEventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", ticket.UserId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title", ticket.MainEventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", ticket.UserId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,MainEventId,UserId")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            ViewData["MainEventId"] = new SelectList(_context.Event, "MainEventId", "title", ticket.MainEventId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", ticket.UserId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.MainEvent)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.TicketId == id);
        }
    }
}
