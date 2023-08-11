using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RunTracker.Models;

namespace RunTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RunsDbContext _runsDbContext;

    public HomeController(ILogger<HomeController> logger, RunsDbContext runsDbContext)
    {
        _logger = logger;
        _runsDbContext = runsDbContext;
    }

    public IActionResult Index(RunModel run)
    {
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
        _runsDbContext.Add(run);
        _runsDbContext.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult UpdateRun(int id)
    {
        var toUpdate = _runsDbContext.Find<RunModel>(id);

        if (toUpdate == null)
        {
            return NotFound();
        }

        return View(toUpdate);
    }

    public IActionResult RunUpdated(RunModel updatedRun)
    {
        if (ModelState.IsValid)
        {
            var toUpdate = _runsDbContext.Find<RunModel>(updatedRun.Run_Id);

            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Route = updatedRun.Route;
            toUpdate.Date = updatedRun.Date;
            toUpdate.Distance = updatedRun.Distance;
            toUpdate.PaceMinutes = updatedRun.PaceMinutes;
            toUpdate.PaceSeconds = updatedRun.PaceSeconds;
            toUpdate.Notes = updatedRun.Notes;

            _runsDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        return View("UpdateRun", updatedRun);
    }

    public IActionResult DeleteRun(int id)
    {
        var toDelete = _runsDbContext.Find<RunModel>(id);

        if (toDelete != null)
        {
            _runsDbContext.Remove(toDelete);
            _runsDbContext.SaveChanges();
            //_runsDbContext.SaveChangesAsync();
        }
        else
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

