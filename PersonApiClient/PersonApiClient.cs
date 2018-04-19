using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using NLog;
using PersonApiClient.Config;
using PersonApiClient.Dto;
using PersonApiClient.HttpClient;

namespace PersonApiClient
{
    public class PersonApiClient : IPersonApiClient
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public List<PersonDto> GetAllPerson()
        {
            var task = Task.Run(async () => await GetAllPersonAsync());
            return task.Result;
        }

        async Task<List<PersonDto>> GetAllPersonAsync()
        {
            var result = new List<PersonDto>();
            try
            {
                var request = ConfigHelper.GetPersonApiBaseurl().AppendPathSegments("/persons/");
                result = await request.GetJsonAsync<List<PersonDto>>().ConfigureAwait(false);
            }
            catch (FlurlHttpException e)
            {
                _logger.Error(e, "Error while getting response from person API" + e.Message);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error while getting response from person API." + e.Message);
            }
            return result;
        }
    }
}
