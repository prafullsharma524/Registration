using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration.Admin;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin.Login lg)
        {
            using (var context = new AdModels())
            {

                bool isValiid = context.Logins.Any(x => x.Username == lg.Username && x.Password == lg.Password);
                if (isValiid) 
                
                {
                    FormsAuthentication.SetAuthCookie(lg.Username, false);
                    return RedirectToAction("Index", "Employee");
                }


                ModelState.AddModelError("", "invalid User");


                    return View();
            }

                

           
        }



    }
}