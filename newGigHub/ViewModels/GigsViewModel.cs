﻿using newGigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newGigHub.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }           

    }
}