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
    public class OrgRegisterController : Controller
    {
        private readonly TikTiDbContext _context;

        public OrgRegisterController(TikTiDbContext context)
        {
            _context = context;
        }

        // GET: OrgRegister
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrgRegistration.ToListAsync());
        }

        // GET: OrgRegister/Details/5
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

        // GET: OrgRegister/Create
        public IActionResult Register()
        {
            return View();
        }

        // POST: OrgRegister/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("RegistrationId,OrganizationName,Email,Pwd,ConfirmPassword,ContactFirstName,ContactLastName,ContactTitle,ContactPhoneNumber,Department,DifferentHr,HrFirstName,HrLastName,HrTitle,HrDepartment,HrPhoneNumber,HrEmail")] OrgRegistration orgRegistration)
        {
            var isDuplicate = _context.OrgRegistration.Where(x => x.Email == orgRegistration.Email);
            if (isDuplicate.Any())
            {
                ModelState.AddModelError("", "User E-mail ID already exists");
            }
            if (ModelState.IsValid)
            {
                MailMessage mm = new MailMessage();
                mm.To.Add(new MailAddress(orgRegistration.Email, "Request for Verification"));
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
                byte[] encode = new byte[orgRegistration.Pwd.Length];
                encode = Encoding.UTF8.GetBytes(orgRegistration.Pwd);

                orgRegistration.Pwd = Convert.ToBase64String(encode);
                orgRegistration.ConfirmPassword = Convert.ToBase64String(encode);
                _context.Add(orgRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ConfirmEmail));
            }
            return View(orgRegistration);
        }

        public IActionResult ConfirmEmail()
        {
            return View();
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
        public IActionResult EmailConfirmed()
        {
            return View();
        }
        private bool OrgRegistrationExists(int id)
        {
            return _context.OrgRegistration.Any(e => e.RegistrationId == id);
        }
    }
}
