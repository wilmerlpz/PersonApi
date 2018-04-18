using System.Collections.Generic;
using PersonApi.Dto;

namespace PersonApi.Repository
{
    public interface IPersonRepository
    {
        bool AddPerson(PersonDto person);

        PersonDto GetPersonById(int personId);

        List<PersonDto> GetAllPerson();
    }
}
