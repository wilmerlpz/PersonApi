using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PersonApi.Dto;
using PersonApi.Repository;

namespace PersonApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private static int nextId;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public PersonDto AddNewPerson(PersonDto person)
        {
            person.Id = Interlocked.Increment(ref nextId);
            _personRepository.AddPerson(person);
            return person;
        }

        public async Task<List<PersonDto>> GetAllPersons()
        {
            return await Task.FromResult(_personRepository.GetAllPerson());
        }

        public PersonDto GetPersonById(int personId)
        {
            return  _personRepository.GetPersonById(personId);
        }
    }
}
