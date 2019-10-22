﻿using Microsoft.AspNet.Identity;
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
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Follow (FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Followings.Any(f => f.FolloweeId == userId && f.FollowerId == userId);

            if (exists) return BadRequest("Following already exists.");

            var following = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();

        }
    }
}
