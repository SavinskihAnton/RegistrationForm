using Microsoft.AspNetCore.Mvc;
using Registration.Context;
using Registration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Registration.Controllers
{
    public class Contacts : Controller
    {
        public IActionResult Contact()
        {
            using (DbUser db = new DbUser())
            {
                List<UserRegistrationModel> list = db.UserInfo.ToList();
                return View(list);
            }
        }
    }
}
