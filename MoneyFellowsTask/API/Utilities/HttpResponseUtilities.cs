using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace API.Utilities
{
    public static class HttpResponseUtilities
    {
        public static async Task SetContextResponseAsync(HttpContext context, object responseBody, HttpStatusCode statusCode)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            jsonSerializerSettings.Converters.Add(new StringEnumConverter());
            string responseBodySerialized = JsonConvert.SerializeObject(responseBody, jsonSerializerSettings);

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(responseBodySerialized);
        }

    }
}
