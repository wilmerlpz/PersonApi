using System;
using System.Collections.Generic;
using System.Text;

namespace PersonApiClient.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public bool Disabled { get; set; }
    }
}
