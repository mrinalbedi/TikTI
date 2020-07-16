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
    public class OrgRegistrationController : Controller
    {
        private readonly TikTiDbContext _context;

        public OrgRegistrationController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: OrgRegistration
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrgRegistration.ToListAsync());
        }

        // GET: OrgRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRegistration = await _context.OrgRegistration
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (orgRegistration == null)
            {
                return NotFound();
            }

            return View(orgRegistration);
        }


        //// GET: /Account/ConfirmEmail
        //[AllowAnonymous]
        //public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        //{
        //    OrgRegistration o = new OrgRegistration();
        //    var user = new IdentityUser { UserName = o.Email, Email = o.Email };
        //    var result = await _userManager.CreateAsync(user, Input.Password);


        //    OrgRegistration user = this.UserManager.FindById(Token);
        //    if (user != null)
        //    {
        //        if (user.Email == Email)
        //        {
        //            user.ConfirmedEmail = true;
        //            await UserManager.UpdateAsync(user);
        //            await SignInAsync(user, isPersistent: false);
        //            return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
        //        }
        //        else
        //        {
        //            return RedirectToAction("Confirm", "Account", new { Email = user.Email });
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Confirm", "Account", new { Email = "" });
        //    }
        //}


        // GET: OrgRegistration/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: OrgRegistration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("RegistrationId,Email,Pwd,ConfirmPassword,ContactFirstName,ContactLastName,ContactTitle,Department")] OrgRegistration orgRegistration)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(orgRegistration.Email, "Request for Verification"));
            mm.From = new MailAddress("alexbaby463@gmail.com");
            mm.Body = "click here";
            mm.IsBodyHtml = true;
            mm.Subject = "Verification";
            SmtpClient smcl = new SmtpClient();
            smcl.Host = "smtp.gmail.com";
            smcl.Port = 587;
            smcl.DeliveryMethod = SmtpDeliveryMethod.Network;
            smcl.Credentials = new NetworkCredential("alexbaby463@gmail.com", "Alexbaby13@");
            smcl.EnableSsl = true;
            smcl.Send(mm);
            if (ModelState.IsValid)
            {

                byte[] encode = new byte[orgRegistration.Pwd.Length];
                encode = Encoding.UTF8.GetBytes(orgRegistration.Pwd);

                orgRegistration.Pwd = Convert.ToBase64String(encode);
                orgRegistration.ConfirmPassword = Convert.ToBase64String(encode);

                _context.Add(orgRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View(orgRegistration);
        }

        // GET: OrgRegistration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRegistration = await _context.OrgRegistration.FindAsync(id);
            if (orgRegistration == null)
            {
                return NotFound();
            }
            return View(orgRegistration);
        }

        // POST: OrgRegistration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistrationId,Email,Pwd,ConfirmPassword,ContactFirstName,ContactLastName,ContactTitle,Department")] OrgRegistration orgRegistration)
        {
            if (id != orgRegistration.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgRegistrationExists(orgRegistration.RegistrationId))
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
            return View(orgRegistration);
        }

        // GET: OrgRegistration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgRegistration = await _context.OrgRegistration
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (orgRegistration == null)
            {
                return NotFound();
            }

            return View(orgRegistration);
        }

        // POST: OrgRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orgRegistration = await _context.OrgRegistration.FindAsync(id);
            _context.OrgRegistration.Remove(orgRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgRegistrationExists(int id)
        {
            return _context.OrgRegistration.Any(e => e.RegistrationId == id);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(OrgRegistration org)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            var usr = _context.OrgRegistration.FirstOrDefault(u => u.Email == org.Email);
            byte[] todecode_byte = Convert.FromBase64String(usr.Pwd);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);


            //var usr = _context.OrgRegistration.FirstOrDefault(u => u.Email == org.Email
            // && u.Pwd == org.Pwd);
            if (result == org.Pwd)
            {
                HttpContext.Session.SetString("UserId", usr.Email.ToString());
                return RedirectToAction("LoggedIn");
            }
            else
            {
                TempData["message"] = "Username or password is incorrect";
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
