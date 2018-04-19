using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PersonApi.Controllers;
using PersonApi.Dto;
using PersonApi.Repository;
using PersonApi.Request;
using PersonApi.Services;

namespace PersonApiTests
{
    [TestClass]
    public class PersonApiTests
    {
        [TestMethod]
        public void AddPersonMethod()
        {
            var controllToTest = GetPersonsController();
            var personRequest = new PersonRequest() { Disabled = true, Firstname = "Wilmer", LastName = "López" };
            IActionResult personList = Task.Run(async () => await controllToTest.Post(personRequest)).Result;

            var contentResult = personList as JsonResult;
            PersonDto personAdded = (PersonDto)contentResult?.Value;
            if (personAdded != null)
                Assert.IsTrue(personAdded.Firstname.Equals(personRequest.Firstname));
        }


        [TestMethod]
        public void GetAllPersonMethod()
        {
            var controllToTest = GetPersonsController();
            var personRequest = new PersonRequest() { Disabled = true, Firstname = "Wilmer", LastName = "López" };
            IActionResult personList = Task.Run(async () => await controllToTest.Post(personRequest)).Result;

            personRequest = new PersonRequest() { Disabled = true, Firstname = "User", LastName = "Test" };
            personList = Task.Run(async () => await controllToTest.Post(personRequest)).Result;

            personRequest = new PersonRequest() { Disabled = true, Firstname = "Wilmer Updated", LastName = "López" };
            personList = Task.Run(async () => await controllToTest.Get()).Result;

            var contentResult = personList as JsonResult;
            List<PersonDto> personColletion = (List<PersonDto>)contentResult?.Value;
            if (personColletion != null)
                Assert.IsTrue(personColletion.Count > 1);


        }


        [TestMethod]
        public void UpdatePersonMethod()
        {
            var controllToTest = GetPersonsController();
            var personRequest = new PersonRequest() { Disabled = true, Firstname = "Wilmer", LastName = "López" };
            IActionResult personList = Task.Run(async () => await controllToTest.Post(personRequest)).Result;

            personRequest = new PersonRequest() { Disabled = true, Firstname = "Wilmer Updated", LastName = "López" };
            personList = Task.Run(async () => await controllToTest.Put(1, personRequest)).Result;

            var contentResult = personList as JsonResult;
            PersonDto personUpdated = (PersonDto)contentResult?.Value;

            if (personUpdated != null)
                Assert.IsTrue(personUpdated.Firstname.Equals(personRequest.Firstname));
        }

        [TestMethod]
        public void DeletePersonMethod()
        {
            var controllToTest = GetPersonsController();
            var personRequest = new PersonRequest() { Disabled = true, Firstname = "Wilmer", LastName = "López" };
            IActionResult personList = Task.Run(async () => await controllToTest.Post(personRequest)).Result;

            personRequest = new PersonRequest() { Disabled = true, Firstname = "User", LastName = "Test" };
            personList = Task.Run(async () => await controllToTest.Post(personRequest)).Result;

            personList = Task.Run(async () => await controllToTest.Delete(2)).Result;

            var contentResult = personList as StatusCodeResult;
            if (contentResult != null)
                Assert.IsTrue(contentResult.StatusCode == 204);

        }

        public PersonsController GetPersonsController()
        {
            var personRepository = new PersonRepository();
            var personService = new PersonService(personRepository);
            return new PersonsController(personService);
        }
    }
}
