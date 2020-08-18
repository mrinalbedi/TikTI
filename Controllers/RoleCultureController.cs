using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class RoleCultureController : Controller
    {
        private readonly TikTiDbContext _context;

        public RoleCultureController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: RoleCulture
        public async Task<IActionResult> Index()
        {
            var tikTiDbContext = _context.RoleCulture.Include(r => r.CultureNavigation).Include(r => r.RoleOpportunityNavigation);
            return View(await tikTiDbContext.ToListAsync());
        }

        // GET: RoleCulture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCulture = await _context.RoleCulture
                .Include(r => r.CultureNavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleCultureId == id);
            if (roleCulture == null)
            {
                return NotFound();
            }

            return View(roleCulture);
        }

        // GET: RoleCulture/Create
        public IActionResult Create()
        {
            RoleCultureVM rcvm = new RoleCultureVM();
            foreach(var x in _context.Culture)
            {
                rcvm.cultures.Add(x);
            }
            return View(rcvm);
        }
        
        // POST: RoleCulture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleCultureId,RoleOpportunity,Culture")] RoleCulture roleCulture, RoleCultureVM rcvm)
        {
            if (ModelState.IsValid)
            {
                foreach(var x in rcvm.cultures)
                {
                    if(x.IsSelected == true)
                    {
                        RoleCulture rc = new RoleCulture();
                        rc.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
                        rc.Culture = x.CultureId;
                        _context.Add(rc);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Create","RoleBenefit");
            }
            
            return View(roleCulture);
        }

        // GET: RoleCulture/Edit/5
        public async Task<IActionResult> Edit()
        {
            string RoleOpportunityId = string.Empty;
            if (HttpContext.Session.GetString("RoleOppId") != null)
                RoleOpportunityId = HttpContext.Session.GetString("RoleOppId");
            else
                RoleOpportunityId = Request.Cookies["RoleOppId"];
            var roleCulture = _context.RoleCulture.Where(x=>x.RoleOpportunity == Convert.ToInt32(RoleOpportunityId));
            
            RoleCultureVM rcvm = new RoleCultureVM();
            foreach (var x in _context.Culture)
            {
                rcvm.cultures.Add(x);
                foreach(var y in roleCulture)
                {
                    if (y.Culture == x.CultureId)
                    {
                        x.IsSelected = true;
                        _context.RoleCulture.Remove(y);
                        
                    }
                }
            }
            await _context.SaveChangesAsync();
            return View(rcvm);
        }

        // POST: RoleCulture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RoleCultureId,RoleOpportunity,Culture")] RoleCulture roleCulture, RoleCultureVM rcvm)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in rcvm.cultures)
                {
                    if (x.IsSelected == true)
                    {
                        RoleCulture rc = new RoleCulture();
                        rc.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOppId"]);
                        rc.Culture = x.CultureId;
                        _context.Add(rc);
                        await _context.SaveChangesAsync();
                    }
                }
                var query = from culture in _context.Culture
                            select culture;
                foreach (var q in query)
                    q.IsSelected = false;
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "RoleBenefit");
            }

            return View(roleCulture);
        }

        // GET: RoleCulture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCulture = await _context.RoleCulture
                .Include(r => r.CultureNavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleCultureId == id);
            if (roleCulture == null)
            {
                return NotFound();
            }

            return View(roleCulture);
        }

        // POST: RoleCulture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleCulture = await _context.RoleCulture.FindAsync(id);
            _context.RoleCulture.Remove(roleCulture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleCultureExists(int id)
        {
            return _context.RoleCulture.Any(e => e.RoleCultureId == id);
        }
    }
}
