using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using simple_job.Models;

namespace simple_job.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JobContext _context;

        public HomeController(ILogger<HomeController> logger, JobContext context)
        {
            _context = context;
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
        public IActionResult NewJob()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> NewJob(job job)
        {
            job.Id = 0;
            _context.Add(job);
            await _context.SaveChangesAsync();
            return Ok("innformation is saved");
        }

        public async Task<IActionResult> Jobs()
        {
            var jobs =await _context.job.ToListAsync();
            return PartialView(jobs);
        }

        [HttpGet]
        public async Task<IActionResult> Job(int id)
        {
            var job =await _context.job.SingleAsync(d=>d.Id==id);
            return PartialView(job);
        }

        [HttpGet]
        public async Task<IActionResult> DetailJob(int id)
        {
            var job = await _context.job.SingleAsync(d => d.Id == id);
            return PartialView(job);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJob(job job)
        {
            _context.Entry(job).State=EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("data is updated");
        }

        [HttpGet]
        public async Task<IActionResult> DelateJob(int id)
        {
            var job = _context.job.Single(d=>d.Id==id);
            _context.job.Remove(job);
            await _context.SaveChangesAsync();
            return Ok("data is deleted");
        }
    }
}
