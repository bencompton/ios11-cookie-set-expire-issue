using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {        
        [Route("~/")]
        public ActionResult Index()
        {
            var loginCookie = Request.Cookies["Login"];

            if (loginCookie != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        [Route("~/login/")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("~/login/")]
        public ActionResult LoginComplete()
        {
            var authCookie = new HttpCookie("Login", "login token")
            {
                Expires = DateTime.Now.AddMinutes(20)
            };

            Response.Cookies.Add(authCookie);

            return Redirect("~/");
        }

        [Route("~/logout/")]
        public ActionResult Logout()
        {
            var authCookie = new HttpCookie("Login", "login token")
            {
                Expires = DateTime.Now.AddMinutes(-1000)              
            };

            Response.Cookies.Add(authCookie);

            return View();
        }
    }
}
