using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{

    public class RoleOpportunityController : Controller
    {
        private readonly TikTiDbContext _context;

        public RoleOpportunityController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: RoleOpportunity
        public async Task<IActionResult> Index()
        {
            var tikTiDbContext = _context.RoleOpportunity.Include(r => r.CertificationNavigation).Include(r => r.CurrencyNavigation).Include(r => r.EducationNavigation).Include(r => r.ExperienceNavigation).Include(r => r.WorkCommitmentNavigation);
            
       
            return View(await tikTiDbContext.ToListAsync());
        }

        // GET: RoleOpportunity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleOpportunity = await _context.RoleOpportunity
                .Include(r => r.CertificationNavigation)
                .Include(r => r.CurrencyNavigation)
                .Include(r => r.EducationNavigation)
                .Include(r => r.ExperienceNavigation)
                .Include(r => r.WorkCommitmentNavigation)
                .FirstOrDefaultAsync(m => m.RoleOpportunityId == id);
            if (roleOpportunity == null)
            {
                return NotFound();
            }

            return View(roleOpportunity);
        }

        // GET: RoleOpportunity/Create
        public IActionResult Create(string dsf)
        {
            //var org = _context.OrgRegister.Where(x => x.Email == Request.Cookies["Email"].ToString()).FirstOrDefault();
            //var orgHR = _context.OrgRegisterHr.Where(x => x.RegistrationId == org.RegistrationId);
            var altTitle = _context.AlternateTitles.Where(x => x.SocCode == dsf);
            var query = from org in _context.OrgRegister
                        join orhr in _context.OrgRegisterHr
                        on org.RegistrationId equals orhr.RegistrationId
                        join hr in _context.HiringManager
                        on orhr.HiringManagerId equals hr.HiringManagerId
                        where org.Email == Request.Cookies["Email"].ToString()
                        select new { HrmId = hr.HiringManagerId, HrmName = hr.FirstName + ' ' + hr.LastName };

            ViewData["AlternateTitle"] = new SelectList(altTitle, "AlternateTitleId", "Name");
            ViewData["HiringManager"] = new SelectList(query, "HrmId", "HrmName");
            ViewData["Certification"] = new SelectList(_context.Certification, "CertificationId", "CertificationName");
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "Currency1");
            ViewData["Education"] = new SelectList(_context.Education, "EducationId", "Education1");
            ViewData["Experience"] = new SelectList(_context.Experience, "ExperienceId", "Experience1");
            ViewData["WorkCommitment"] = new SelectList(_context.WorkCommitment.OrderByDescending(x => x.WorkCommitmentId), "WorkCommitmentId", "Commitment");
            return View();
        }

        // POST: RoleOpportunity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleOpportunityId,AlternateTitleId,JobDescription,DesiredStartDate,WorkCommitment,ContractDuration,Currency,Salary,City,Province,Postal,TelecommutingRoles,Weblink,Certification,ExtraCertificationRequired,ExtraCertification,Experience,Education,HiringManagerId")] RoleOpportunity roleOpportunity, IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    if (fileExtension != ".pdf")
                    {
                        ModelState.AddModelError("", "Please upload pdf format file only");
                    }
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        roleOpportunity.JobDescription = target.ToArray();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "The job description field cannot be empty");
            }
            if (ModelState.IsValid)
            {
                
                _context.Add(roleOpportunity);
                await _context.SaveChangesAsync();
                var temp = _context.RoleOpportunity.OrderByDescending(x => x.RoleOpportunityId).FirstOrDefault();
                Response.Cookies.Append("RoleOpportunityId", temp.RoleOpportunityId.ToString());
                ViewBag.ROID = temp.RoleOpportunityId;
                return RedirectToAction("Create", "AlternativeWorkLocation");
            }
            ViewData["Certification"] = new SelectList(_context.Certification, "CertificationId", "CertificationId", roleOpportunity.Certification);
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyId", roleOpportunity.Currency);
            ViewData["Education"] = new SelectList(_context.Education, "EducationId", "EducationId", roleOpportunity.Education);
            ViewData["Experience"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", roleOpportunity.Experience);
            ViewData["WorkCommitment"] = new SelectList(_context.WorkCommitment, "WorkCommitmentId", "WorkCommitmentId", roleOpportunity.WorkCommitment);
            return View(roleOpportunity);
        }

        public FileContentResult DownloadFile(int RouteID)
        {
            if (RouteID == 0) { return null; }
            RoleOpportunity roleOpportunity = new RoleOpportunity();
            // ResumeContext rc = new ResumeContext();
            roleOpportunity = _context.RoleOpportunity.Where(a => a.RoleOpportunityId == RouteID).SingleOrDefault();
            //Response.AppendHeader("content-disposition", "inline; filename=file.pdf"); //this will open in a new tab.. remove if you want to open in the same tab.
            return File(roleOpportunity.JobDescription, "application/pdf");
        }

        // GET: RoleOpportunity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleOpportunity = await _context.RoleOpportunity.FindAsync(id);
            if (roleOpportunity == null)
            {
                return NotFound();
            }
            ViewData["Certification"] = new SelectList(_context.Certification, "CertificationId", "CertificationId", roleOpportunity.Certification);
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyId", roleOpportunity.Currency);
            ViewData["Education"] = new SelectList(_context.Education, "EducationId", "EducationId", roleOpportunity.Education);
            ViewData["Experience"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", roleOpportunity.Experience);
            ViewData["WorkCommitment"] = new SelectList(_context.WorkCommitment, "WorkCommitmentId", "WorkCommitmentId", roleOpportunity.WorkCommitment);
            return View(roleOpportunity);
        }

        // POST: RoleOpportunity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleOpportunityId,JobDescription,DesiredStartDate,WorkCommitment,ContractDuration,Currency,Salary,City,Province,Postal,TelecommutingRoles,Weblink,Certification,ExtraCertificationRequired,ExtraCertification,Experience,Education")] RoleOpportunity roleOpportunity)
        {
            if (id != roleOpportunity.RoleOpportunityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleOpportunity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleOpportunityExists(roleOpportunity.RoleOpportunityId))
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
            ViewData["Certification"] = new SelectList(_context.Certification, "CertificationId", "CertificationId", roleOpportunity.Certification);
            ViewData["Currency"] = new SelectList(_context.Currency, "CurrencyId", "CurrencyId", roleOpportunity.Currency);
            ViewData["Education"] = new SelectList(_context.Education, "EducationId", "EducationId", roleOpportunity.Education);
            ViewData["Experience"] = new SelectList(_context.Experience, "ExperienceId", "ExperienceId", roleOpportunity.Experience);
            ViewData["WorkCommitment"] = new SelectList(_context.WorkCommitment, "WorkCommitmentId", "WorkCommitmentId", roleOpportunity.WorkCommitment);
            return View(roleOpportunity);
        }

        // GET: RoleOpportunity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleOpportunity = await _context.RoleOpportunity
                .Include(r => r.CertificationNavigation)
                .Include(r => r.CurrencyNavigation)
                .Include(r => r.EducationNavigation)
                .Include(r => r.ExperienceNavigation)
                .Include(r => r.WorkCommitmentNavigation)
                .FirstOrDefaultAsync(m => m.RoleOpportunityId == id);
            if (roleOpportunity == null)
            {
                return NotFound();
            }

            return View(roleOpportunity);
        }

        // POST: RoleOpportunity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleOpportunity = await _context.RoleOpportunity.FindAsync(id);
            _context.RoleOpportunity.Remove(roleOpportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleOpportunityExists(int id)
        {
            return _context.RoleOpportunity.Any(e => e.RoleOpportunityId == id);
        }
    }
}
