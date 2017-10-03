using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("~/login/")]
        public ActionResult Login()
        {
            var authTicket = new FormsAuthenticationTicket(
                1,
                "Login",
                DateTime.Now.ToUniversalTime(),
                DateTime.Now.ToUniversalTime().AddMinutes(20),
                true,
                ""
            );

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = DateTime.Now.AddMinutes(20)
            };

            Response.Cookies.Add(authCookie);

            return View();
        }

        [HttpPost]
        [Route("~/login/")]
        public ActionResult LoginComplete()
        {
            return Redirect("~/");
        }

        [Route("~/logout/")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return View();
        }
    }
}