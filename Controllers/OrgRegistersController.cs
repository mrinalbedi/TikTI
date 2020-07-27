using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tikti.Models;

namespace Tikti.Controllers
{
    public class OrgRegistersController : Controller
    {
        private readonly TikTiDbContext _context;

        public OrgRegistersController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: OrgRegisters
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrgRegister.ToListAsync());
        }

        // GET: OrgRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRegister = await _context.OrgRegister
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (orgRegister == null)
            {
                return NotFound();
            }

            return View(orgRegister);
        }

        // GET: OrgRegisters/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: OrgRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("RegistrationId,OrganizationName,Email,Password,ConfirmPassword,ContactFirstName,ContactLastName,ContactTitle,ContactPhoneNumber,Department")] OrgRegister orgRegister)
        {
            var isDuplicate = _context.OrgRegister.Where(x => x.Email == orgRegister.Email);
            if (isDuplicate.Any())
            {
                ModelState.AddModelError("", "User E-mail ID already exists");
            }
            if (ModelState.IsValid)
            {
                Response.Cookies.Append("RegistrationId",orgRegister.RegistrationId.ToString());
                MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(orgRegister.Email, "Request for Verification"));
            mm.From = new MailAddress("alexbaby463@gmail.com");
            mm.Body = "<a href='http://localhost:55446/OrgRegister/EmailConfirmed'>Please click here to confirm your registration</a>";
            mm.IsBodyHtml = true;
            mm.Subject = "Tikti Registration Verification link";
            SmtpClient smcl = new SmtpClient();
            smcl.Host = "smtp.gmail.com";
            smcl.Port = 587;
            smcl.DeliveryMethod = SmtpDeliveryMethod.Network;
            smcl.Credentials = new NetworkCredential("alexbaby463@gmail.com", "Alexbaby13@");
            smcl.EnableSsl = true;
            smcl.Send(mm);
            byte[] encode = new byte[orgRegister.Password.Length];
            encode = Encoding.UTF8.GetBytes(orgRegister.Password);

            orgRegister.Password = Convert.ToBase64String(encode);
            orgRegister.ConfirmPassword = Convert.ToBase64String(encode);
            _context.Add(orgRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
          return View(orgRegister);
    }

        // GET: OrgRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRegister = await _context.OrgRegister.FindAsync(id);
            if (orgRegister == null)
            {
                return NotFound();
            }
            return View(orgRegister);
        }

        // POST: OrgRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistrationId,OrganizationName,Email,Password,ConfirmPassword,ContactFirstName,ContactLastName,ContactTitle,ContactPhoneNumber,Department")] OrgRegister orgRegister)
        {
            if (id != orgRegister.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgRegisterExists(orgRegister.RegistrationId))
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
            return View(orgRegister);
        }

        // GET: OrgRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRegister = await _context.OrgRegister
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (orgRegister == null)
            {
                return NotFound();
            }

            return View(orgRegister);
        }

        // POST: OrgRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgRegister = await _context.OrgRegister.FindAsync(id);
            _context.OrgRegister.Remove(orgRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgRegisterExists(int id)
        {
            return _context.OrgRegister.Any(e => e.RegistrationId == id);
        }
    }
}
