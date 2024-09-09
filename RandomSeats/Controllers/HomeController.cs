using Microsoft.AspNetCore.Mvc;
using RandomSeats.Data;
using RandomSeats.Models;
using System.Diagnostics;

namespace RandomSeats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      private readonly RandomSeatsContext _dbContext;

        public HomeController(ILogger<HomeController> logger, RandomSeatsContext dbcontext)
        {
           _logger = logger;
          _dbContext = dbcontext;
        }

        public IActionResult Index()
        {
            //Gather all classes for "Ms. Crites"
            var teacher = _dbContext.Teachers.Where(x => x.Name.ToUpper() == "MS. CRITES").FirstOrDefault();
            var classes = _dbContext.ClassUnits.Where(x => x.TeacherId == teacher.Id).ToList();
            return View(classes);
        }
    }
}
