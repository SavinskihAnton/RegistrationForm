using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Crypt;
using Registration.Models;
using System.Linq;

namespace Registration.Controllers
{
    public class RegistrationUser : Controller
    {
        CryptPass crypt;

        public RegistrationUser()
        {
            crypt=new CryptPass();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserRegistrationModel user)
        {
            using (DbUser db = new DbUser())
            {
                if (ModelState.IsValid)
                {
                    if (user != null && user.IsAgree != false)
                    {
                        user.Password = crypt.Encode(user.Password);
                        user.ConfirmPassword = crypt.Encode(user.ConfirmPassword);
                        db.UserInfo.Add(user);
                        db.SaveChanges();
                        return View("Accept", user);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return View(user);
                }
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel users)
        {
            if (ModelState.IsValid)
            {
                UserRegistrationModel user = null;
                using (DbUser db = new DbUser())
                {
                    user = db.UserInfo.FirstOrDefault(x => x.Email == users.Email && x.Password == users.Password);
                }
                if (user != null)
                {
                    return View("AcceptLogin", user);
                }
            }
            return View();
        }
    }
}
