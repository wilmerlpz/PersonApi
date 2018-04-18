using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            var result = new string[] { "person1", "person2" };
            return Json(result);
        }
    }
}