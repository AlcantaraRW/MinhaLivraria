using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Livraria.Web.Helpers
{
    public static class JsonHelper
    {
        private static JsonSerializerSettings _serializerSettings;

        static JsonHelper()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
        }

        public static string ToJson<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, _serializerSettings);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, _serializerSettings);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}