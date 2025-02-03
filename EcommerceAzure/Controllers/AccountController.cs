using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EcommerceAzure.Models;

namespace EcommerceAzure.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        // Action de connexion
        [HttpGet]
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action("Index", "Home");
            var properties = new AuthenticationProperties
            {
                RedirectUri = redirectUrl
            };

            return Challenge(properties, OpenIdConnectDefaults.AuthenticationScheme);
        }

        // Action de déconnexion
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // Page de profil
        [Authorize]
        public IActionResult Profile()
        {
            // Récupérer les informations de l'utilisateur connecté
            var userClaims = User.Claims.Select(c => new UserClaimViewModel
            {
                Type = c.Type,
                Value = c.Value
            }).ToList();

            return View(userClaims);
        }

        // Gestion des erreurs d'authentification
        [AllowAnonymous]
        public IActionResult AccessDenied()
        { 
            return View();
        }
    }
}
