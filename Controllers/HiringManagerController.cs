using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class HiringManagerController : Controller
    {
        private readonly TikTiDbContext _context;

        public HiringManagerController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: HiringManager
        public async Task<IActionResult> Index()
        {
            return View(await _context.HiringManager.ToListAsync());
        }

        // GET: HiringManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiringManager = await _context.HiringManager
                .FirstOrDefaultAsync(m => m.HiringManagerId == id);
            if (hiringManager == null)
            {
                return NotFound();
            }

            return View(hiringManager);
        }

        // GET: HiringManager/Create
        public IActionResult Create()
        {
            string RegistrationId = Request.Cookies["RegistrationId"];
            if (string.IsNullOrEmpty(RegistrationId))
            {
                //add code to return to registration page
            }
            return View();
        }

        // POST: HiringManager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HiringManagerId,FirstName,LastName,Title,Department,PhoneNumber,Email")] HiringManager hiringManager,string value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hiringManager);
                await _context.SaveChangesAsync();
               
                OrgRegisterHr orhr = new OrgRegisterHr();
                orhr.HiringManagerId = hiringManager.HiringManagerId;
                orhr.RegistrationId = Convert.ToInt32(Request.Cookies["RegistrationId"]);
                
                _context.Add(orhr);
                await _context.SaveChangesAsync();
                if (value == "add")
                    return RedirectToAction("Create","HiringManager");
                if (value == "next")
                    return RedirectToAction("ConfirmEmail", "OrgRegisters");
            }
            return View(hiringManager);
        }

        // GET: HiringManager/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiringManager = await _context.HiringManager.FindAsync(id);
            if (hiringManager == null)
            {
                return NotFound();
            }
            return View(hiringManager);
        }

        // POST: HiringManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HiringManagerId,FirstName,LastName,Title,Department,PhoneNumber,Email")] HiringManager hiringManager)
        {
            if (id != hiringManager.HiringManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hiringManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HiringManagerExists(hiringManager.HiringManagerId))
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
            return View(hiringManager);
        }

        // GET: HiringManager/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiringManager = await _context.HiringManager
                .FirstOrDefaultAsync(m => m.HiringManagerId == id);
            if (hiringManager == null)
            {
                return NotFound();
            }

            return View(hiringManager);
        }

        // POST: HiringManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hiringManager = await _context.HiringManager.FindAsync(id);
            _context.HiringManager.Remove(hiringManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HiringManagerExists(int id)
        {
            return _context.HiringManager.Any(e => e.HiringManagerId == id);
        }
    }
}
