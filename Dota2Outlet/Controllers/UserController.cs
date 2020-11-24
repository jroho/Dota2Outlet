using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace Dota2Outlet.Controllers
{
    public class UserController : Controller
    {
        private const string c_STEAM_PROVIDER = "http://steamcommunity.com/openid";

        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/user/login?redirect=index");
            }

            return View("index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/home");
        }

        public ActionResult Login()
        {
            // Stage 1: display login form to user
            return View("login");
        }

        [ValidateInput(false)]
        public async Task<ActionResult> Authenticate(string redirect)
        {
            var response = await openid.GetResponseAsync(this.Request);
            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(c_STEAM_PROVIDER, out id))
                {
                    try
                    {
                        var request = await openid.CreateRequestAsync(c_STEAM_PROVIDER);
                        var redirectingResponse = await request.GetRedirectingResponseAsync();
                        return redirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["message"] = ex.Message;
                        return View("login");
                    }
                }
                else
                {
                    ViewData["message"] = "Invalid identifier";
                    return View("login");
                }
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        //authenticate user
                        Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
                        var cookie = FormsAuthentication.GetAuthCookie(response.ClaimedIdentifier, true);
                        cookie.Expires = DateTime.Now.Add(new TimeSpan(7, 0, 0, 0));
                        Response.SetCookie(cookie);
                        if (!string.IsNullOrEmpty(redirect))
                        {
                            return Redirect(redirect);
                        }
                        else
                        {
                            return RedirectToAction("index", "home");
                        }
                    case AuthenticationStatus.Canceled:
                        ViewData["message"] = "Canceled at provider";
                        return View("login");
                    case AuthenticationStatus.Failed:
                        ViewData["message"] = response.Exception.Message;
                        return View("login");
                }
            }
            return new EmptyResult();
        }
    }
}
