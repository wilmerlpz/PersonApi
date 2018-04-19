using System.Collections.Generic;
using PersonApiClient.Dto;

namespace PersonApiClient.HttpClient
{
    public interface IPersonApiClient
    {
        List<PersonDto> GetAllPerson();
    }
}
