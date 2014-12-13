using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model.JSONDeserializers.Converter
{
    internal class TagsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var tagsValue = (IList<Tag>) value;

            var tagsStringToWrite = tagsValue.Select(x => x.ToString())
                .Aggregate((previous, current) => previous + " " + current);

            writer.WritePropertyName("tags");
            writer.WriteValue(tagsStringToWrite);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var text = (string) reader.Value;

            var tagsList = text.Split(' ')
                .Select(x => new Tag(x.TrimStart('#')))
                .ToList();

            return tagsList;
        }

        public override bool CanConvert(Type objectType)
        {
            var tagEnumerableTypeInfo = typeof (IEnumerable<Tag>).GetTypeInfo();

            return objectType.GetTypeInfo().IsAssignableFrom(tagEnumerableTypeInfo);
        }
    }
}