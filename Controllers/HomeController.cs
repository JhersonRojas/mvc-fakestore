using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using mvc_fakestore.Database;
using mvc_fakestore.Models;

namespace mvc_fakestore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly AplicacionDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    } 

     [HttpGet]
    public IActionResult Crear()
    {
        return View();
    } 


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
