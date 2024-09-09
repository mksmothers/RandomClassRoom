using Microsoft.AspNetCore.Mvc;
using RandomSeats.Data;
using RandomSeats.Models;

namespace RandomSeats.Controllers
{
    public class ClassRoom : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RandomSeatsContext _dbContext;
        const int SeatsCount = 4;
       
        public ClassRoom(ILogger<HomeController> logger, RandomSeatsContext dbcontext)
        {
            _logger = logger;
            _dbContext = dbcontext;
        }


        public IActionResult Details(int id)
        {
            var allTheKids = _dbContext.Students.Where(x=> x.ClassId == id).ToList();
            var shuffledKids = allTheKids.OrderBy(i => Guid.NewGuid()).ToList();
            
            List<TableMap> allTables = new List<TableMap>();

            int counter = 0;
            int tableCounter = 1;

            foreach(var kid in shuffledKids)
            {
                if (counter ==0)
                {
                    allTables.Add(new TableMap { Name = "Table " + tableCounter++ });
                }

                allTables.Last().Students.Add(kid.Name);

                counter++;

                if (counter == 4)
                {
                    counter = 0;
                }
            }

            return View(allTables);
        }      
    }
}
