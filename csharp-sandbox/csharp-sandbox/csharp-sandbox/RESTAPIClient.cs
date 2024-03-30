using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace csharp_sandbox
{
    public class RESTAPIClient(HttpClient httpClient)
    {
        public string? endpointBaseUrlString;
        public string? usNationalParkServiceAPIKey;
        public string[]? usNationalParkServiceAPIParkCode;
        public string[]? usNationalParkServiceAPIStateCode;
        public int? usNationalParkServiceAPIResultLimit;
        public int? usNationalParkServiceAPIStart;
        public string? usNationalParkServiceAPIQuery;
        public string[]? usNationalParkServiceAPISortBy;

        public async Task <HttpResponseMessage> USNationalParkServiceAPI(string apiKey, string endpointBaseUrlString, string[]? parkCode, string[]? stateCode, int? resultLimit, int? start, string? query, string[]? sortBy)
        {
            httpClient.BaseAddress = new Uri(endpointBaseUrlString);
            string queryText = ("/parks" + "?parkcode=" + parkCode + "?stateCode=" + stateCode + "?resultLimit=" + resultLimit.ToString() + "?start=" + start.ToString() + "?query=" + query + "?sortby=" + sortBy);
            
            HttpRequestMessage nationalParksQueryRequest = new HttpRequestMessage(HttpMethod.Get, queryText);
            nationalParksQueryRequest.Headers.Add("X-API-Key", apiKey);

            var nationalParksQueryResponse = await httpClient.SendAsync(nationalParksQueryRequest);
            return (nationalParksQueryResponse);
        }

    }
}
