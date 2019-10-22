using Microsoft.AspNet.Identity;
using newGigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newGigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Followees
        public ActionResult Index()
        {          
            var userId = User.Identity.GetUserId();

            var artists = _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.Followee)
                .ToList();
                           
            return View(artists);    
            
        }
    }
}