using System;

namespace PersonApiClient.Config
{
    public static class ConfigHelper
    {
        public static string GetPersonApiBaseurl()
        {
            var personAPiUrl = Environment.GetEnvironmentVariable("PERSON_API_URL");
            return personAPiUrl ?? "http://localhost:33472/api/";
        }
    }
}
