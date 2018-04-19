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
        public async Task<IActionResult> Post([FromBody]PersonRequest personRequest)
        {
            var result = await _personService.AddNewPerson(personRequest);
            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _personService.GetPersonById(id);
            return Json(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PersonRequest personRequest)
        {
            var result = await _personService.UpdatePerson(id, personRequest);
            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personService.DeletePersonById(id);
            return result ? StatusCode(204): StatusCode(400);
        }
    }
}