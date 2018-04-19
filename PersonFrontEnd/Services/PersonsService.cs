using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApiClient.Dto;

namespace PersonFrontEnd.Services
{
    public class PersonsService
    {
        public List<PersonDto> GetAllPerson()
        {
            var httpClient = new PersonApiClient.PersonApiClient();
            return httpClient.GetAllPerson();
        }

        public List<PersonDto> SearchPersonByname(string personName)
        {
            var httpClient = new PersonApiClient.PersonApiClient();
            var personList = httpClient.GetAllPerson();
            return string.IsNullOrEmpty(personName) ? personList : personList.Where(p => p.Firstname.ToUpper().Contains(personName.ToUpper()) || p.LastName.ToUpper().Contains(personName.ToUpper())).ToList();
        }
    }
}
