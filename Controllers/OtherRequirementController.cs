using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class OtherRequirementController : Controller
    {
        private readonly TikTiDbContext _context;

        public OtherRequirementController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: OtherRequirement
        public async Task<IActionResult> Index()
        {
            var tikTiDbContext = _context.OtherRequirements.Include(o => o.RoleOpportunity);
            return View(await tikTiDbContext.ToListAsync());
        }

        // GET: OtherRequirement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherRequirements = await _context.OtherRequirements
                .Include(o => o.RoleOpportunity)
                .FirstOrDefaultAsync(m => m.RequirementId == id);
            if (otherRequirements == null)
            {
                return NotFound();
            }

            return View(otherRequirements);
        }

        // GET: OtherRequirement/Create
        public IActionResult Create()
        {
            ViewBag.ROID = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
            return View();
        }

        // POST: OtherRequirement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequirementId,RoleOpportunityId,Sponsorship,OverseasTravel,DrugTesting,Age18,Travel,TravelDistance,DriverLicense,LicenseProvince,WeekendWork,Overnight")] OtherRequirements otherRequirements)
        {
            otherRequirements.RoleOpportunityId = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
            if (ModelState.IsValid)
            {
                _context.Add(otherRequirements);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "RoleOpportunity");
            }
            //ViewData["RoleOpportunityId"] = new SelectList(_context.RoleOpportunity, "RoleOpportunityId", "City", otherRequirements.RoleOpportunityId);
            return View(otherRequirements);
        }

        // GET: OtherRequirement/Edit/5
        public IActionResult Edit()
        {
            string RoleOpportunityId = string.Empty;
            if (HttpContext.Session.GetString("RoleOppId") != null)
                RoleOpportunityId = HttpContext.Session.GetString("RoleOppId");
            else
                RoleOpportunityId = Request.Cookies["RoleOppId"];

            var otherRequirements = _context.OtherRequirements.Where(x => x.RoleOpportunityId == Convert.ToInt32(RoleOpportunityId)).FirstOrDefault();
            return View(otherRequirements);
        }

        // POST: OtherRequirement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RequirementId,RoleOpportunityId,Sponsorship,OverseasTravel,DrugTesting,Age18,Travel,TravelDistance,DriverLicense,LicenseProvince,WeekendWork,Overnight")] OtherRequirements otherRequirements)
        {
            string RoleOpportunityId = string.Empty;
            if (HttpContext.Session.GetString("RoleOppId") != null)
                RoleOpportunityId = HttpContext.Session.GetString("RoleOppId");
            else
                RoleOpportunityId = Request.Cookies["RoleOppId"];
            if (ModelState.IsValid)
            {
                try
                {
                    otherRequirements.RoleOpportunityId = Convert.ToInt32(RoleOpportunityId);
                    _context.Update(otherRequirements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherRequirementsExists(otherRequirements.RequirementId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","AlternativeWorkLocation");
            }
            return View(otherRequirements);
        }

        // GET: OtherRequirement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherRequirements = await _context.OtherRequirements
                .Include(o => o.RoleOpportunity)
                .FirstOrDefaultAsync(m => m.RequirementId == id);
            if (otherRequirements == null)
            {
                return NotFound();
            }

            return View(otherRequirements);
        }

        // POST: OtherRequirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otherRequirements = await _context.OtherRequirements.FindAsync(id);
            _context.OtherRequirements.Remove(otherRequirements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherRequirementsExists(int id)
        {
            return _context.OtherRequirements.Any(e => e.RequirementId == id);
        }
    }
}
