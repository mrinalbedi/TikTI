using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class RoleCompetencyAController : Controller
    {
        private readonly TikTiDbContext _context;

        public RoleCompetencyAController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: RoleCompetencyA
        public async Task<IActionResult> Index()
        {
            var tikTiDbContext = _context.RoleCompetencyA.Include(r => r.ComptencyANavigation).Include(r => r.RoleOpportunityNavigation);
            return View(await tikTiDbContext.ToListAsync());
        }

        // GET: RoleCompetencyA/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCompetencyA = await _context.RoleCompetencyA
                .Include(r => r.ComptencyANavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleCompetencyAid == id);
            if (roleCompetencyA == null)
            {
                return NotFound();
            }

            return View(roleCompetencyA);
        }

        // GET: RoleCompetencyA/Create
        public IActionResult Create()
        {
            RoleCompetencyA_VM rcavm = new RoleCompetencyA_VM();
            foreach (var x in _context.CompetencyA)
            {
                rcavm.competencyA.Add(x);
            }
            return View(rcavm);
        }

        // POST: RoleCompetencyA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleCompetencyAid,RoleOpportunity,ComptencyA")] RoleCompetencyA roleCompetencyA, RoleCompetencyA_VM rcavm)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in rcavm.competencyA)
                {
                    if (x.IsSelected == true)
                    {
                        RoleCompetencyA rca = new RoleCompetencyA();
                        rca.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
                        rca.ComptencyA = x.CompetencyId;
                        _context.Add(rca);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Create", "RoleCompetencyB");
            }
            return View(roleCompetencyA);
        }

        // GET: RoleCompetencyA/Edit/5
        public async Task<IActionResult> Edit()
        {
            string RoleOpportunityId = string.Empty;
            if (HttpContext.Session.GetString("RoleOppId") != null)
                RoleOpportunityId = HttpContext.Session.GetString("RoleOppId");
            else
                RoleOpportunityId = Request.Cookies["RoleOppId"];

            var roleCompetencyA = _context.RoleCompetencyA.Where(x => x.RoleOpportunity == Convert.ToInt32(RoleOpportunityId));
            RoleCompetencyA_VM rcavm = new RoleCompetencyA_VM();
            foreach (var x in _context.CompetencyA)
            {
                rcavm.competencyA.Add(x);
                foreach (var y in roleCompetencyA)
                {
                    if (y.ComptencyA == x.CompetencyId)
                    {
                        x.IsSelected = true;
                        _context.RoleCompetencyA.Remove(y);
                       
                    }
                }
            }
            await _context.SaveChangesAsync();
            return View(rcavm);
        }

        // POST: RoleCompetencyA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RoleCompetencyAid,RoleOpportunity,ComptencyA")] RoleCompetencyA roleCompetencyA, RoleCompetencyA_VM rcavm)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in rcavm.competencyA)
                {
                    if (x.IsSelected == true)
                    {
                        RoleCompetencyA rca = new RoleCompetencyA();
                        rca.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
                        rca.ComptencyA = x.CompetencyId;
                        _context.Add(rca);
                        await _context.SaveChangesAsync();
                    }
                }
                var query = from competencyA in _context.CompetencyA
                            select competencyA;
                foreach (var q in query)
                    q.IsSelected = false;
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "RoleCompetencyB");
            }
            return View(roleCompetencyA);
        }

        // GET: RoleCompetencyA/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleCompetencyA = await _context.RoleCompetencyA
                .Include(r => r.ComptencyANavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleCompetencyAid == id);
            if (roleCompetencyA == null)
            {
                return NotFound();
            }

            return View(roleCompetencyA);
        }

        // POST: RoleCompetencyA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleCompetencyA = await _context.RoleCompetencyA.FindAsync(id);
            _context.RoleCompetencyA.Remove(roleCompetencyA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleCompetencyAExists(int id)
        {
            return _context.RoleCompetencyA.Any(e => e.RoleCompetencyAid == id);
        }
    }
}
