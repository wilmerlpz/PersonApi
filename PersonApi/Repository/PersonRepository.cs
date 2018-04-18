using System;
using System.Collections.Generic;
using System.Linq;
using PersonApi.Dto;

namespace PersonApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<PersonDto> _personCollection = new List<PersonDto>(){new PersonDto(){Id = 1, Firstname = "Wilmer", LastName = "López", Disabled = false}};

        public bool AddPerson(PersonDto person)
        {
            try
            {
                _personCollection.Add(person);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public PersonDto GetPersonById(int personId)
        {
            try
            {
                return _personCollection.FirstOrDefault(p => p.Id == personId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public List<PersonDto> GetAllPerson()
        {
            return _personCollection;
        }

    }
}
