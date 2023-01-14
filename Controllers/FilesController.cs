using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc101.Models;
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Hosting.Internal;

namespace Mvc101.Controllers;

    public class FilesController : Controller
{
    string[] filepaths = Directory.GetFiles("./TextFiles/");
    private readonly ILogger<FilesController> _logger;

    public FilesController(ILogger<FilesController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View(filepaths);
    }

    public ActionResult Content(string id)
        {
            //get contents of file
            
            string readText = System.IO.File.ReadAllText($"./TextFiles/{id}");
            ViewData["path1"] = $"{readText}" ;
            return View();
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
