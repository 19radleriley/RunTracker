using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RunTracker.Models;

namespace RunTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //private static List<RunModel>? runs;
    private readonly RunsDbContext _runsDbContext;

    public HomeController(ILogger<HomeController> logger, RunsDbContext runsDbContext)
    {
        _logger = logger;
        _runsDbContext = runsDbContext;
    }

    public IActionResult Index(RunModel run)
    {
        //if (runs == null)
        //{
        //    runs = new List<RunModel>()
        //    {
        //        new RunModel()
        //        {
        //            Route = "Silver Birch O/B",
        //            Date = DateTime.Now,
        //            Distance = 3,
        //            PaceMinutes = 9,
        //            PaceSeconds = 10,
        //            Notes = "It was an easy run. The legs felt good, and it was golden hour. Can't ask for much better!"
        //        },
        //        new RunModel()
        //        {
        //            Route = "Silver Birch O/B",
        //            Date = DateTime.Now,
        //            Distance = 3,
        //            PaceMinutes = 9,
        //            PaceSeconds = 10,
        //            Notes = "It was an easy run. The legs felt good, and it was golden hour. Can't ask for much better!"
        //        },
        //        new RunModel()
        //        {
        //            Route = "Silver Birch O/B",
        //            Date = DateTime.Now,
        //            Distance = 3,
        //            PaceMinutes = 9,
        //            PaceSeconds = 10,
        //            Notes = "It was an easy run. The legs felt good, and it was golden hour. Can't ask for much better!"
        //        },
        //        new RunModel()
        //        {
        //            Route = "Silver Birch O/B",
        //            Date = DateTime.Now,
        //            Distance = 3,
        //            PaceMinutes = 9,
        //            PaceSeconds = 10,
        //            Notes = "It was an easy run. The legs felt good, and it was golden hour. Can't ask for much better!"
        //        }
        //    };
        //}

        // Get all runs and order them by date.
        var runs = _runsDbContext.Runs
                                 .OrderBy(r => r.Date)
                                 .Reverse()
                                 .ToList<RunModel>();
        return View(runs);
    }

    public IActionResult CreateRun()
    {
        RunModel run = new RunModel();
        return View(run);
    }

    public IActionResult RunCreated(RunModel run)
    {
        //if (runs != null)
        //{
        //    runs.Add(run);
        //}

        _runsDbContext.Add(run);
        _runsDbContext.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

