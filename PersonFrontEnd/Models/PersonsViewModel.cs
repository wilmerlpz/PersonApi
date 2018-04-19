using System.Collections.Generic;
using PersonApiClient.Dto;

namespace PersonFrontEnd.Models
{
    public class PersonsViewModel
    {
        public List<PersonDto> PersonList { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public PersonsViewModel(List<PersonDto> personList)
        {
            this.PersonList = personList;
        }
    }
}