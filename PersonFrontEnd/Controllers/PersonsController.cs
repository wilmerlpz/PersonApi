using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonFrontEnd.Models;
using PersonFrontEnd.Services;

namespace PersonFrontEnd.Controllers
{
    public class PersonsController : Controller
    {
        private IPersonsService PersonsService { get; set; }

        public PersonsController(IPersonsService personsService)
        {
            PersonsService = personsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "Person Collection page.";
            return View(new PersonsViewModel(PersonsService.GetAllPerson()));
        }
        [HttpPost]
        public IActionResult Search([FromForm]string personName)
        {
            ViewData["Message"] = "Person Collection page.";
            var personList = PersonsService.SearchPersonByname(personName);
            return View("Index",new PersonsViewModel(personList));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
