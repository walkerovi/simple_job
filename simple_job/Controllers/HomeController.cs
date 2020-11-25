using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using simple_job.Models;

namespace simple_job.Controllers
{
    public class HomeController : Controller
    {

        private readonly JobContext _context;

        public HomeController(JobContext context)
        {
            _context = context;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        /*agregados para trabajar*/
        [HttpGet]
        public async Task<IActionResult> NuevoJob()
        { 
            
        }

        [HttpPost]
        public async Task<IActionResult> NuevoJob(job job)
        {
            if (!ModelState.IsValid)
                return BadRequest("some information is not correct");
            _context.Add(job);
            await _context.SaveChangesAsync();
            return Ok("innformation is saved");
        }

        public async Task<IActionResult> Jobs()
        {
            var jobs = _context.job.ToList();
            return Ok(Task.Run(()=>jobs));
        }
    }
}
