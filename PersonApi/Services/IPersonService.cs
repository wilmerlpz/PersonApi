using System.Collections.Generic;
using System.Threading.Tasks;
using PersonApi.Dto;
using PersonApi.Request;

namespace PersonApi.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPersons();
        PersonDto GetPersonById(int personId);
        Task<PersonDto> AddNewPerson(PersonRequest person);
    }
}
