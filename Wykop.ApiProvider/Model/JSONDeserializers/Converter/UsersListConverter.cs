using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model.JSONDeserializers.Converter
{
    class UsersListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read(); // start array

            List<int> userIds = new List<int>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                int? userId =  reader.ReadAsInt32();
                if (userId.HasValue)
                    userIds.Add(userId.Value);
            }


            return new UsersIdList(userIds);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (UsersIdList);
        }
    }
}
