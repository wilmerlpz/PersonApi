using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PersonApi.Dto;
using PersonApi.Repository;
using PersonApi.Request;

namespace PersonApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private static int _nextId;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<PersonDto> AddNewPerson(PersonRequest personRequest)
        {
            var newPerson = new PersonDto()
            {
                Id = Interlocked.Increment(ref _nextId),
                Disabled = personRequest.Disabled,
                Firstname = personRequest.Firstname,
                LastName = personRequest.LastName
            };
            await Task.FromResult(_personRepository.AddPerson(newPerson));
            return newPerson;
        }

        public async Task<List<PersonDto>> GetAllPersons()
        {
            return await Task.FromResult(_personRepository.GetAllPerson());
        }

        public async Task<PersonDto> GetPersonById(int personId)
        {
            return await Task.FromResult(_personRepository.GetPersonById(personId));
        }


        public async Task<bool> DeletePersonById(int personId)
        {
            return await Task.FromResult(_personRepository.DeletePersonById(personId));
        }

        public async Task<PersonDto> UpdatePerson(int personId, PersonRequest personRequest)
        {
            return await Task.FromResult(_personRepository.UpdatePerson(personId, personRequest));
        }
    }
}
