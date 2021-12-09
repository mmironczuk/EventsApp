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
using System.Text;
using Microsoft.AspNetCore.Identity;
using PagedList;

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
        public async Task<IActionResult> Index(string? type)
        {
            var grouped = _context.Event.Include(m => m.Organizer).Include(m => m.Place)
                .Include(m => m.User).Include(m => m.Opinions).Where(m => m.confirmed == true && m.dateStart >= DateTime.Now).OrderByDescending(m => m.Opinions.Count).Take(5);
            ViewBag.BestEvents = grouped.ToList();

            List<MainEvent> favouriteEvents = new List<MainEvent>();
            if (User.Identity.IsAuthenticated)
            {
                User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                var favourites = _context.Favourites.Include(x => x.MainEvent).Where(x => x.UserId == user.Id).ToList();
                foreach (Favourites f in favourites)
                {
                    favouriteEvents.Add(f.MainEvent);
                }
            }
            ViewBag.favouriteEvents = favouriteEvents;

            ViewBag.type = "none";
            if (type != null) ViewBag.type = type;
            if(type=="none"||type==null)
            {
                var applicationDbContext = _context.Event
                    .Include(m => m.Organizer).Include(m => m.Place).Include(m => m.User).Include(m => m.Opinions)
                    .Where(m => m.confirmed == true && m.dateStart >= DateTime.Now);
                return View(await applicationDbContext.ToListAsync());
                //var applicationDbContext = await _context.Event
                //    .Include(m => m.Organizer).Include(m => m.Place).Include(m => m.User).Include(m => m.Opinions)
                //    .Where(m => m.confirmed == true && m.dateStart >= DateTime.Now).ToListAsync();

                //return View(applicationDbContext.ToPagedList(1, 5));
            }
            else 
            {
                var applicationDbContext = await _context.Event
                    .Include(m => m.Organizer).Include(m => m.Place).Include(m => m.User).Include(m => m.Opinions)
                    .Where(m => m.confirmed == true && m.dateStart >= DateTime.Now&&m.type==type).ToListAsync();

                return View(applicationDbContext);
            }

            
        }

        [Authorize]
        public JsonResult FavouriteAction(int id)
        {
            User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            Favourites fav = _context.Favourites.Where(x => x.MainEventId == id && x.UserId == user.Id).FirstOrDefault();
            if (fav != null)
            {
                _context.Remove(fav);
                _context.SaveChanges();
                return Json(new { success = false, msg = "Removed" });
            }
            else
            {
                fav = new Favourites
                {
                    UserId=user.Id,
                    MainEventId=id
                };
                _context.Add(fav);
                _context.SaveChanges();
                return Json(new { success = true, msg = "Added" });
            }
        }

        public PartialViewResult SearchByProvince(string searchText, string category)
        {
            List<MainEvent> favouriteEvents = new List<MainEvent>();
            if (User.Identity.IsAuthenticated)
            {
                User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                var favourites = _context.Favourites.Include(x => x.MainEvent).Where(x => x.UserId == user.Id).ToList();
                foreach (Favourites f in favourites)
                {
                    favouriteEvents.Add(f.MainEvent);
                }
            }
            ViewBag.favouriteEvents = favouriteEvents;

            if (category=="none")
            {
                var applicationDbContext = _context.Event
                    .Include(m => m.Organizer).Include(m => m.Place).Include(m => m.User).Include(m => m.Opinions)
                    .Where(m => m.confirmed == true && m.dateStart >= DateTime.Now && m.Place.province == searchText).ToList();
                return PartialView("_ProvinceSearch", applicationDbContext);
            }
            else
            {
                var applicationDbContext = _context.Event
                    .Include(m => m.Organizer).Include(m => m.Place).Include(m => m.User).Include(m => m.Opinions)
                    .Where(m => m.confirmed == true && m.dateStart >= DateTime.Now && m.Place.province == searchText && m.type == category).ToList();
                return PartialView("_ProvinceSearch", applicationDbContext);
            }
        }

        public PartialViewResult CommentAction(int id, string content)
        {
            User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            Opinion opinion = new Opinion
            {
                MainEventId = id,
                UserId = user.Id,
                content = content,
                date=DateTime.Now
            };
            _context.Add(opinion);
            _context.SaveChanges();

            List<Opinion> applicationDbContext = new List<Opinion>();
            applicationDbContext = _context.Opinion.Include(x=>x.User).Where(x => x.MainEventId == id).ToList();

            return PartialView("_CommentView", applicationDbContext);
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

            List<Opinion> applicationDbContext = new List<Opinion>();
            applicationDbContext = await _context.Opinion.Include(x => x.User).Where(x => x.MainEventId == id).ToListAsync();
            ViewBag.Comments = applicationDbContext;

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
                    maxPrice = mainEventView.maxPrice,
                    type = mainEventView.type,
                    confirmed = false
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

            var mainEvent = _context.Event.Include(x=>x.Place)
                .Include(x=>x.Organizer)
                .Where(x=>x.MainEventId==id).FirstOrDefault();

            if (mainEvent == null)
            {
                return NotFound();
            }

            MainEventViewModel mainEventView = new MainEventViewModel
            {
                MainEventId=mainEvent.MainEventId,
                title=mainEvent.title,
                description=mainEvent.description,
                dateStart=mainEvent.dateStart,
                dateEnd=mainEvent.dateEnd,
                freeTickets=mainEvent.freeTickets,
                minPrice=mainEvent.minPrice,
                maxPrice=mainEvent.maxPrice,
                name=mainEvent.Place.name,
                province=mainEvent.Place.province,
                city=mainEvent.Place.city,
                address=mainEvent.Place.address,
                type=mainEvent.type,
                OrganizerName=mainEvent.Organizer.name
            };

            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "name");
            var organizers = _context.Organizer.Where(x => x.confirmed == true).ToList();
            ViewData["Organizers"] = organizers;
            var miejsca = _context.Place.Where(x => x.confirmed == true).ToList();
            ViewData["Miejsca"] = miejsca;
            return View(mainEventView);
        }

        // POST: MainEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainEventId,title,description,dateStart,dateEnd,freeTickets,minPrice,maxPrice,name,province,city,address,type,OrganizerName")] MainEventViewModel mainEventView)
        {
            if (id != mainEventView.MainEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    MainEvent mEvent = _context.Event.Find(mainEventView.MainEventId);
                    mEvent.title = mainEventView.title;
                    mEvent.description = mainEventView.description;
                    mEvent.dateStart = mainEventView.dateStart;
                    mEvent.dateEnd = mainEventView.dateEnd;
                    mEvent.freeTickets = mainEventView.freeTickets;
                    mEvent.minPrice = mainEventView.minPrice;
                    mEvent.maxPrice = mainEventView.maxPrice;
                    mEvent.type = mainEventView.type;

                    Place place = _context.Place.Where(x => x.name == mainEventView.name).FirstOrDefault();
                    if (place != null) mEvent.PlaceId = place.PlaceId;
                    else
                    {
                        Place p = new Place
                        {
                            name=mainEventView.name,
                            address=mainEventView.address,
                            province=mainEventView.province,
                            city=mainEventView.city,
                            confirmed=false
                        };
                        _context.Add(p);
                        _context.SaveChanges();
                        place = _context.Place.Where(x => x.name == p.name).FirstOrDefault();
                        mEvent.PlaceId = place.PlaceId;
                    }

                    Organizer organizer = _context.Organizer.Where(x => x.name == mainEventView.OrganizerName).FirstOrDefault();
                    if (organizer != null) mEvent.OrganizerId = organizer.OrganizerId;
                    else
                    {
                        Organizer o = new Organizer
                        {
                            name = mainEventView.OrganizerName,
                            confirmed = false
                        };
                        _context.Add(o);
                        _context.SaveChanges();
                        Organizer or = _context.Organizer.Where(x => x.name == mainEventView.OrganizerName).FirstOrDefault();
                        mEvent.OrganizerId = or.OrganizerId;
                    }

                    _context.Update(mEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEventExists(mainEventView.MainEventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyEvents));
            }
            ViewData["PlaceId"] = new SelectList(_context.Place, "PlaceId", "name");
            var organizers = _context.Organizer.Where(x => x.confirmed == true).ToList();
            ViewData["Organizers"] = organizers;
            var miejsca = _context.Place.Where(x => x.confirmed == true).ToList();
            ViewData["Miejsca"] = miejsca;
            return View(mainEventView);
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
            _context.Event.Remove(mainEvent);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Admin")) return RedirectToAction("ConfirmOrganizer");
            //return View(mainEvent);
            else return RedirectToAction("MyEvents");
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

        [Authorize]
        public IActionResult MyEvents()
        {
            User user = _context.User.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            string UserId = user.Id;
            var events = _context.Event.Include(m => m.Organizer).Include(m => m.Place).Include(m=>m.Opinions).Where(x=>x.UserId==UserId).ToList();
            return View(events);
        }

        public IActionResult ConfirmEvents()
        {
            var events = _context.Event.Include(m => m.Organizer).Include(m => m.Place).Where(x => x.confirmed==false).ToList();
            return View(events);
        }

        public IActionResult AcceptEvent(int id)
        {
            MainEvent mevent = _context.Event.Find(id);
            mevent.confirmed = true;
            _context.Update(mevent);
            _context.SaveChanges();
            return RedirectToAction("ConfirmEvents");
        }
    }
}
