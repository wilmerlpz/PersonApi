using System;
using System.Collections.Generic;
using System.Linq;
using PersonApi.Dto;
using PersonApi.Request;

namespace PersonApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<PersonDto> _personCollection = new List<PersonDto>();

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

        public bool DeletePersonById(int personId)
        {
            try
            {
                var personToBeDeleted = _personCollection.FirstOrDefault(p => p.Id == personId);
                _personCollection.Remove(personToBeDeleted);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public PersonDto UpdatePerson(int personId, PersonRequest personRequest)
        {
            try
            {
                var personToBeUpdated = _personCollection.FirstOrDefault(p => p.Id == personId);
                if (personToBeUpdated != null)
                {
                    personToBeUpdated.Firstname = personRequest.Firstname;
                    personToBeUpdated.LastName = personRequest.LastName;
                    personToBeUpdated.Disabled = personRequest.Disabled;
                }
                return personToBeUpdated;
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
