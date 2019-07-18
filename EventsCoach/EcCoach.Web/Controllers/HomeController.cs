﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcCoach.Web.Models;
using EcCoach.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace EcCoach.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }



        public IActionResult Index( )
        {
            var upcomingEvents = _context.Events
                .Include(c =>  c.Coach)
                .Include(c => c.Type)
                .Where (p => p.DateTime>= DateTime.Now);

            return View(upcomingEvents);
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
