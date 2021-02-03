using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class SocCodeController : Controller
    {
        private readonly TikTiDbContext _context;

        public SocCodeController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: SocCode
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocCode.ToListAsync());
        }

        // GET: SocCode/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socCode = await _context.SocCode
                .FirstOrDefaultAsync(m => m.SocCode1 == id);
            if (socCode == null)
            {
                return NotFound();
            }

            return View(socCode);
        }

        // GET: SocCode/Create
        public IActionResult Create()
        {
            var query = from x in _context.SocCode
                        select x;
            ViewData["SocCode"] = new SelectList(query, "SocCode1", "Description");
            return View();
        }

        // POST: SocCode/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SocCode1,Description")] SocCode socCode)
        {
            string socCodeSelected = socCode.SocCode1;
            Response.Cookies.Append("soc", socCodeSelected);
            HttpContext.Session.SetString("soc", socCodeSelected);
                return RedirectToAction("Create","RoleOpportunity", new { soc = socCodeSelected });
        }

        // GET: SocCode/Edit/5
        public async Task<IActionResult> Edit()
        {
            string soc = string.Empty;
            if (Request.Cookies["soc"] != null)
                soc = Request.Cookies["soc"];
            else if(HttpContext.Session.GetString("soc").ToString()!=null)
                soc=  HttpContext.Session.GetString("soc").ToString();

            //var query = from x in _context.SocCode
            //            where x.SocCode1==Request.Cookies["soc"] || x.SocCode1==HttpContext.Session.GetString("soc").ToString()
            //            select x;
            ViewData["SocCode"] = new SelectList(_context.SocCode, "SocCode1", "Description",soc);
            return View();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var socCode = await _context.SocCode.FindAsync(id);
            //if (socCode == null)
            //{
            //    return NotFound();
            //}
            //return View(socCode);
        }

        // POST: SocCode/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SocCode1,Description")] SocCode socCode)
        {
            
            string socCodeSelected = socCode.SocCode1;
            return RedirectToAction("Edit", "RoleOpportunity", new { soc = socCodeSelected });
            //if (id != socCode.SocCode1)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(socCode);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!SocCodeExists(socCode.SocCode1))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction("Edit","RoleOpportunity",socCode);
            //}
            //return View(socCode);
        }

        // GET: SocCode/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socCode = await _context.SocCode
                .FirstOrDefaultAsync(m => m.SocCode1 == id);
            if (socCode == null)
            {
                return NotFound();
            }

            return View(socCode);
        }

        // POST: SocCode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var socCode = await _context.SocCode.FindAsync(id);
            _context.SocCode.Remove(socCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocCodeExists(string id)
        {
            return _context.SocCode.Any(e => e.SocCode1 == id);
        }
    }
}
