using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceAzure.Controllers
{
    public class AzSampleController : Controller
    {
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Index()
        {
            // Logique d'impersonation
            var userObjectId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRoles = User.FindAll(ClaimTypes.Role);
             
            return View();
        }

        [Authorize(Policy = "FormateursPolicy")]
        public IActionResult Formateur()
        {
            return RedirectToAction("Profile", "Account");
             
        }
    }
}
