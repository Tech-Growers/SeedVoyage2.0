using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeedVoyageApp.Data;
using SeedVoyageApp.Models;

namespace SeedVoyageApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string id)
        {
            if (id == null)
            {
                if (Request.Cookies["seedVoyageUserId"] == null)
                {
                    // Consider changing this to making the user sign in again
                    return NotFound();
                }
                else
                {
                    id = Request.Cookies["seedVoyageUserId"];
                }
            }
            else
            {
                Response.Cookies.Append("seedVoyageUserId", id);
            }

            // Get the user information based on the Id in the query string or Cookie
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            // Display different information depending on the user type
            if (user.UserType == "Grower")
            {
                // Display items for the body:
                ViewData["UserType"] = "Grower";
                ViewData["StartPointMessage"] = "We are excited that you have chosen to grow food for " +
                    "our thriving community.  Seed Voyage is a rapidly expanding network that plans to " +
                    "eventually connect produce growers with produce eaters. Please feel free to get started " +
                    "with this website by clicking on the links provided.";
                ViewData["StartImage"] = "grower-start.jpg";
                ViewData["StartImageClass"] = "grower-start-img";
                ViewData["StartImageAlt"] = "A picture of produce";
                // Navbar link logic is in _Layout.cshtml
            }
            else if (user.UserType == "Eater")
            {
                // Display items for the body:
                ViewData["UserType"] = "Eater";
                ViewData["StartPointMessage"] = "Enjoy the benefits of being an eater in this community! " +
                    "Eaters look for food that is advertised on this website.  Once you find something you like " +
                    "make a note of it so you can buy it in the future. Please browse this website to start " +
                    "your food buying process.";
                ViewData["StartImage"] = "eater-start.jpg";
                ViewData["StartImageClass"] = "eater-start-img";
                ViewData["StartImageAlt"] = "A picture of a woman about to eat produce";
                // Navbar link logic is in _Layout.cshtml                
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
