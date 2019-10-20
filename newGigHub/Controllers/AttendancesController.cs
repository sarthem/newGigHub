using Microsoft.AspNet.Identity;
using newGigHub.Dtos;
using newGigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace newGigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        
        [HttpPost]
        public IHttpActionResult Attend (AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context
                            .Attendances
                            .Any(a => a.AttendeeId == userId 
                            && a.GigId == dto.GigId);

            if (exists) return BadRequest("The Attendance already exists.");

            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }


    }

}

