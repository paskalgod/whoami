using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoamiApplication.Data;
using WhoamiApplication.Models;

namespace WhoamiApplication.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly WhoamiApplicationContext _context;

        public RegistrationController(WhoamiApplicationContext context)
        {
            _context = context;
        }

        // GET: RegistrationController
        public ActionResult Index()
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationNewUser([Bind("id,email,password,nickname")] User user)
        {
            if (ModelState.IsValid)
            {
                var password = user.password;
                var mySalt = "$2a$10$r";
                var myHash = BCrypt.Generate(Encoding.Unicode.GetBytes(password), Encoding.Unicode.GetBytes(mySalt), 10);
                user.password = Encoding.Default.GetString(myHash.Where(x => x != 0).ToArray());
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
