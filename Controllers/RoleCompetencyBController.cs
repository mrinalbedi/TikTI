using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class RoleCompetencyBController : Controller
    {
        private readonly TikTiDbContext _context;

        public RoleCompetencyBController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: RoleCompetencyB
        public async Task<IActionResult> Index()
        {
            var tikTiDbContext = _context.RoleCompetencyB.Include(r => r.ComptencyBNavigation).Include(r => r.RoleOpportunityNavigation);
            return View(await tikTiDbContext.ToListAsync());
        }

        // GET: RoleCompetencyB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCompetencyB = await _context.RoleCompetencyB
                .Include(r => r.ComptencyBNavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleCompetencyBid == id);
            if (roleCompetencyB == null)
            {
                return NotFound();
            }

            return View(roleCompetencyB);
        }

        // GET: RoleCompetencyB/Create
        public IActionResult Create()
        {
            RoleCompetencyB_VM rcbvm = new RoleCompetencyB_VM();
            foreach (var x in _context.CompetencyB)
            {
                rcbvm.competencyB.Add(x);
            }
            return View(rcbvm);
        }

        // POST: RoleCompetencyB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleCompetencyBid,RoleOpportunity,ComptencyB")] RoleCompetencyB roleCompetencyB, RoleCompetencyB_VM rcbvm)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in rcbvm.competencyB)
                {
                    if (x.IsSelected == true)
                    {
                        RoleCompetencyB rcb = new RoleCompetencyB();
                        rcb.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
                        rcb.ComptencyB = x.CompetencyId;
                        _context.Add(rcb);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Create", "OtherRequirement");
            }
            return View(roleCompetencyB);
        }

        // GET: RoleCompetencyB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCompetencyB = await _context.RoleCompetencyB.FindAsync(id);
            if (roleCompetencyB == null)
            {
                return NotFound();
            }
            ViewData["ComptencyB"] = new SelectList(_context.CompetencyA, "CompetencyId", "CompetencyId", roleCompetencyB.ComptencyB);
            ViewData["RoleOpportunity"] = new SelectList(_context.RoleOpportunity, "RoleOpportunityId", "City", roleCompetencyB.RoleOpportunity);
            return View(roleCompetencyB);
        }

        // POST: RoleCompetencyB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleCompetencyBid,RoleOpportunity,ComptencyB")] RoleCompetencyB roleCompetencyB)
        {
            if (id != roleCompetencyB.RoleCompetencyBid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleCompetencyB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleCompetencyBExists(roleCompetencyB.RoleCompetencyBid))
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
            ViewData["ComptencyB"] = new SelectList(_context.CompetencyA, "CompetencyId", "CompetencyId", roleCompetencyB.ComptencyB);
            ViewData["RoleOpportunity"] = new SelectList(_context.RoleOpportunity, "RoleOpportunityId", "City", roleCompetencyB.RoleOpportunity);
            return View(roleCompetencyB);
        }

        // GET: RoleCompetencyB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCompetencyB = await _context.RoleCompetencyB
                .Include(r => r.ComptencyBNavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleCompetencyBid == id);
            if (roleCompetencyB == null)
            {
                return NotFound();
            }

            return View(roleCompetencyB);
        }

        // POST: RoleCompetencyB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleCompetencyB = await _context.RoleCompetencyB.FindAsync(id);
            _context.RoleCompetencyB.Remove(roleCompetencyB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleCompetencyBExists(int id)
        {
            return _context.RoleCompetencyB.Any(e => e.RoleCompetencyBid == id);
        }
    }
}
