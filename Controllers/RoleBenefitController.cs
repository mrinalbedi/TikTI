﻿using System;
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
    public class RoleBenefitController : Controller
    {
        private readonly TikTiDbContext _context;

        public RoleBenefitController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: RoleBenefit
        public async Task<IActionResult> Index()
        {
            var tikTiDbContext = _context.RoleBenefit.Include(r => r.BenefitNavigation).Include(r => r.RoleOpportunityNavigation);
            return View(await tikTiDbContext.ToListAsync());
        }

        // GET: RoleBenefit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleBenefit = await _context.RoleBenefit
                .Include(r => r.BenefitNavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleBenefitId == id);
            if (roleBenefit == null)
            {
                return NotFound();
            }

            return View(roleBenefit);
        }

        // GET: RoleBenefit/Create
        public IActionResult Create()
        {
            RoleBenefitVM rbvm = new RoleBenefitVM();
            foreach (var x in _context.Benefit)
            {
                rbvm.benefits.Add(x);
            }
            return View(rbvm);
        }

        // POST: RoleBenefit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleBenefitId,RoleOpportunity,Benefit")] RoleBenefit roleBenefit, RoleBenefitVM rbvm)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in rbvm.benefits)
                {
                    if (x.IsSelected == true)
                    {
                        RoleBenefit rb = new RoleBenefit();
                        rb.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOpportunityId"]);
                        rb.Benefit = x.BenefitId;
                        _context.Add(rb);
                        await _context.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Create", "RoleCompetencyA");
            }
            return View(roleBenefit);
        }

        // GET: RoleBenefit/Edit/5
        public async Task<IActionResult> Edit()
        {
            string RoleOpportunityId = string.Empty;
            if (HttpContext.Session.GetString("RoleOppId") != null)
                RoleOpportunityId = HttpContext.Session.GetString("RoleOppId");
            else
                RoleOpportunityId = Request.Cookies["RoleOppId"];
            var roleBenefit = _context.RoleBenefit.Where(x => x.RoleOpportunity == Convert.ToInt32(RoleOpportunityId));

            RoleBenefitVM rbvm = new RoleBenefitVM();
            foreach (var x in _context.Benefit)
            {
                rbvm.benefits.Add(x);
                foreach (var y in roleBenefit)
                {
                    if (y.Benefit == x.BenefitId)
                    {
                        x.IsSelected = true;
                        _context.RoleBenefit.Remove(y);
                        
                    }
                }
            }
            await _context.SaveChangesAsync();
            return View(rbvm);
        }

        // POST: RoleBenefit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RoleBenefitId,RoleOpportunity,Benefit")] RoleBenefit roleBenefit, RoleBenefitVM rbvm)
        {
            if (ModelState.IsValid)
            {
                foreach (var x in rbvm.benefits)
                {
                    if (x.IsSelected == true)
                    {
                        RoleBenefit rb = new RoleBenefit();
                        rb.RoleOpportunity = Convert.ToInt32(Request.Cookies["RoleOppId"]);
                        rb.Benefit = x.BenefitId;
                        _context.Add(rb);
                        await _context.SaveChangesAsync();
                    }
                }
                var query = from benefit in _context.Benefit
                            select benefit;
                foreach (var q in query)
                    q.IsSelected = false;
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "RoleCompetencyA");
            }
            return View(roleBenefit);
        }

        // GET: RoleBenefit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleBenefit = await _context.RoleBenefit
                .Include(r => r.BenefitNavigation)
                .Include(r => r.RoleOpportunityNavigation)
                .FirstOrDefaultAsync(m => m.RoleBenefitId == id);
            if (roleBenefit == null)
            {
                return NotFound();
            }

            return View(roleBenefit);
        }

        // POST: RoleBenefit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleBenefit = await _context.RoleBenefit.FindAsync(id);
            _context.RoleBenefit.Remove(roleBenefit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleBenefitExists(int id)
        {
            return _context.RoleBenefit.Any(e => e.RoleBenefitId == id);
        }
    }
}
