using System.Collections.Generic;
using PersonApi.Dto;
using PersonApi.Request;

namespace PersonApi.Repository
{
    public interface IPersonRepository
    {
        bool AddPerson(PersonDto person);

        PersonDto GetPersonById(int personId);

        List<PersonDto> GetAllPerson();

        PersonDto UpdatePerson(int personId, PersonRequest personRequest);

        bool DeletePersonById(int personId);
    }
}
