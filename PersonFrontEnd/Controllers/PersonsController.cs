using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonFrontEnd.Models;
using PersonFrontEnd.Services;

namespace PersonFrontEnd.Controllers
{
    public class PersonsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "Person Collection page.";
            var personService = new PersonsService();
            return View(new PersonsViewModel(personService.GetAllPerson()));
        }
        [HttpPost]
        public IActionResult Search([FromForm]string personName)
        {
            ViewData["Message"] = "Person Collection page.";
            var personService = new PersonsService();
            var personList = personService.SearchPersonByname(personName);
            return View("Index",new PersonsViewModel(personList));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
