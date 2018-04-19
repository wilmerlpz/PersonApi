using System.Collections.Generic;
using PersonApiClient.Dto;

namespace PersonFrontEnd.Services
{
    public interface IPersonsService
    {
        List<PersonDto> GetAllPerson();

        List<PersonDto> SearchPersonByname(string personName);
    }
}
