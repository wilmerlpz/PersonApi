using System.Collections.Generic;
using System.Threading.Tasks;
using PersonApi.Dto;
using PersonApi.Request;

namespace PersonApi.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPersons();

        Task<PersonDto> GetPersonById(int personId);

        Task<PersonDto> AddNewPerson(PersonRequest person);

        Task<PersonDto> UpdatePerson(int personId,PersonRequest person);

        Task<bool> DeletePersonById(int personId);
    }
}
