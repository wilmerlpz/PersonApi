using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Request;
using PersonApi.Services;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _personService.GetAllPersons();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonRequest person)
        {
            var result = await _personService.AddNewPerson(person);
            return Json(result);
        }
    }
}