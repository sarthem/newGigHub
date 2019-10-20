using newGigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newGigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _conetxt;

        public HomeController()
        {
            _conetxt = new ApplicationDbContext();
        } 
        
        public ActionResult Index()
        {
            var upcomingGigs = _conetxt.Gigs
                .Include(g => g.Artist)
                .Where(g => g.DateTime > DateTime.Now);

            return View(upcomingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}