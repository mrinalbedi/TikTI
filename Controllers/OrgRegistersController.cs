using Microsoft.AspNetCore.Http;
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
                MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(orgRegister.Email, "Request for Verification"));
            mm.From = new MailAddress("alexbaby463@gmail.com");
            mm.Body = "<a href='http://localhost:55446/OrgRegisters/EmailConfirmed'>Please click here to confirm your registration</a>";
            mm.IsBodyHtml = true;
            mm.Subject = "Tikti Registration Verification link";
                SmtpClient smcl = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("alexbaby463@gmail.com", "Alexbaby13@"),
                    EnableSsl = true
                };
                smcl.Send(mm);
            byte[] encode = new byte[orgRegister.Password.Length];
            encode = Encoding.UTF8.GetBytes(orgRegister.Password);

            orgRegister.Password = Convert.ToBase64String(encode);
            orgRegister.ConfirmPassword = Convert.ToBase64String(encode);
            _context.Add(orgRegister);
            await _context.SaveChangesAsync();
                Response.Cookies.Append("RegistrationId", orgRegister.RegistrationId.ToString());
                return RedirectToAction("Create","HiringManager");
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

        public IActionResult ConfirmEmail()
        {
            return View();
        }

        public IActionResult EmailConfirmed()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(OrgRegister org)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            var usr = _context.OrgRegister.FirstOrDefault(u => u.Email == org.Email);
            if(usr!=null)
            {
                byte[] todecode_byte = Convert.FromBase64String(usr.Password);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                if (result == org.Password)
                {
                    HttpContext.Session.SetString("UserId", usr.Email.ToString());
                    Response.Cookies.Append("Email", org.Email);
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    TempData["message"] = "Username or password is incorrect";
                }
            }
            else
            {
                TempData["message"] = "Oops!! looks like the E-mail ID is not registered with TikTi. Kindly register!!!";
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
