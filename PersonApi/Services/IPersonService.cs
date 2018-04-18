using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Dto;

namespace PersonApi.Services
{
    public interface IPersonService
    {
        List<PersonDto> GetAllPersons();
        PersonDto GetPersonById(int personId);
        PersonDto AddNewPerson(PersonDto person);
    }
}
