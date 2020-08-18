using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class AlternativeWorkLocationController : Controller
    {
        private readonly TikTiDbContext _context;

        public AlternativeWorkLocationController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: AlternativeWorkLocation
        public IActionResult Index()
        {
            string RoleOpportunityId = string.Empty;
            if (HttpContext.Session.GetString("RoleOppId") != null)
                RoleOpportunityId = HttpContext.Session.GetString("RoleOppId");
            else
                RoleOpportunityId = Request.Cookies["RoleOppId"];

            var query = from awro in _context.AlterWorkRoleOpportunity
                        join awl in _context.AlternativeWorkLocation
                        on awro.WorkLocationId equals awl.WorkLocationId
                        join ro in _context.RoleOpportunity
                        on awro.RoleOpportunityId equals ro.RoleOpportunityId
                        where ro.RoleOpportunityId == Convert.ToInt32(RoleOpportunityId)
                        select new AlternativeWorkLocation {WorkLocationId = awl.WorkLocationId ,City = awl.City ,
                            Province = awl.Province , Postal = awl.Postal };
            if(!query.Any())
            {
                TempData["message"] = "You have not added any alternative work locations for this role opportunity";
                //return View("Index");
            }

            return View(query);
        }

        // GET: AlternativeWorkLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alternativeWorkLocation = await _context.AlternativeWorkLocation
                .FirstOrDefaultAsync(m => m.WorkLocationId == id);
            if (alternativeWorkLocation == null)
            {
                return NotFound();
            }

            return View(alternativeWorkLocation);
        }

        // GET: AlternativeWorkLocation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlternativeWorkLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkLocationId,City,Province,Postal")] AlternativeWorkLocation alternativeWorkLocation,string value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alternativeWorkLocation);
                await _context.SaveChangesAsync();
                AlterWorkRoleOpportunity awro = new AlterWorkRoleOpportunity();
                awro.WorkLocationId = alternativeWorkLocation.WorkLocationId;
                awro.RoleOpportunityId = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
                _context.Add(awro);
                await _context.SaveChangesAsync();
                if(value == "add")
                    return RedirectToAction("Create", "AlternativeWorkLocation");
                if(value == "next")
                    return RedirectToAction("Create", "RoleCulture");
            }
            return View(alternativeWorkLocation);
        }

        // GET: AlternativeWorkLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alternativeWorkLocation = await _context.AlternativeWorkLocation.FindAsync(id);
            if (alternativeWorkLocation == null)
            {
                return NotFound();
            }
            return View(alternativeWorkLocation);
        }

        // POST: AlternativeWorkLocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkLocationId,City,Province,Postal")] AlternativeWorkLocation alternativeWorkLocation)
        {
            if (id != alternativeWorkLocation.WorkLocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alternativeWorkLocation);
                    await _context.SaveChangesAsync();
                    TempData["message"] = "Details have been updated successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlternativeWorkLocationExists(alternativeWorkLocation.WorkLocationId))
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
            return View(alternativeWorkLocation);
        }

        // GET: AlternativeWorkLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alternativeWorkLocation = await _context.AlternativeWorkLocation
                .FirstOrDefaultAsync(m => m.WorkLocationId == id);
            if (alternativeWorkLocation == null)
            {
                return NotFound();
            }

            return View(alternativeWorkLocation);
        }

        // POST: AlternativeWorkLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alternativeWorkLocation = await _context.AlternativeWorkLocation.FindAsync(id);
            _context.AlternativeWorkLocation.Remove(alternativeWorkLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlternativeWorkLocationExists(int id)
        {
            return _context.AlternativeWorkLocation.Any(e => e.WorkLocationId == id);
        }

        public IActionResult Add()
        {
            return View();
        }

        // POST: AlternativeWorkLocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("WorkLocationId,City,Province,Postal")] AlternativeWorkLocation alternativeWorkLocation, string value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alternativeWorkLocation);
                await _context.SaveChangesAsync();
                AlterWorkRoleOpportunity awro = new AlterWorkRoleOpportunity();
                awro.WorkLocationId = alternativeWorkLocation.WorkLocationId;
                awro.RoleOpportunityId = Convert.ToInt32(Request.Cookies["RoleOppId"]);
                _context.Add(awro);
                await _context.SaveChangesAsync();
                TempData["message"] = "New Work location added successfully";
                return RedirectToAction("Index", "AlternativeWorkLocation");
               
            }
            return View(alternativeWorkLocation);
        }
        public IActionResult RoleOpportunityUploaded()
        {
            return View();
        }

    }
}
