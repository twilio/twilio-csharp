using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Twilio.Converters
{
    
    public class DateTimeConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                // Serializing List<DateTime> objects
                if (value is List<DateTime> dateTimes)
                {
                    writer.WriteStartArray();
                    foreach (var dateTime in dateTimes)
                    {
                        writer.WriteValue(Serializers.DateTimeIso8601(dateTime));
                    }

                    writer.WriteEndArray();
                }
                else
                { // Serializing DateTime object
                    writer.WriteValue(Serializers.DateTimeIso8601((DateTime)value));
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    var dateTimes = new List<DateTime>();

                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.String)
                        {
                            if (DateTime.TryParse((string)reader.Value, out DateTime dateTime))
                            {
                                dateTimes.Add(dateTime);
                            }
                        }
                        else if (reader.TokenType == JsonToken.EndArray)
                        {
                            return dateTimes;
                        }
                    }
                }
                else if (reader.TokenType == JsonToken.String)
                {
                    if (DateTime.TryParse((string)reader.Value, out DateTime dateTime))
                    {
                        return dateTime;
                    }
                }
                throw new JsonSerializationException("Failed to deserialize DateTime.");
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime?) || objectType ==typeof(List<DateTime>);
            }
        }

    public class UriConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serializing List<Uri> objects
            if (value is List<Uri> uris)
            {
                writer.WriteStartArray();
                foreach (var uri in uris)
                {
                    writer.WriteValue(Serializers.Url(uri));
                }

                writer.WriteEndArray();
            }
            else
            { // Serializing Uri object
                writer.WriteValue(Serializers.Url((Uri)value));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var uris = new List<Uri>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.String)
                    {
                        if (Uri.TryCreate((string)reader.Value, UriKind.RelativeOrAbsolute, out Uri uri))
                        {
                            uris.Add(uri);
                        }
                    }
                    else if (reader.TokenType == JsonToken.EndArray)
                    {
                        return uris;
                    }
                }
            }
            else if (reader.TokenType == JsonToken.String)
            {
                if (Uri.TryCreate((string)reader.Value, UriKind.RelativeOrAbsolute, out Uri uri))
                {
                    return uri;
                }
            }
            throw new JsonSerializationException("Failed to deserialize URI.");
        }
        
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }
    }

    public class JsonObjectConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Serializing List<Uri> objects
            if (value is List<object> objects)
            {
                writer.WriteStartArray();
                foreach (var val in objects)
                {
                    writer.WriteValue(Serializers.JsonObject(val));
                }

                writer.WriteEndArray();
            }
            else
            { // Serializing Uri object
                writer.WriteValue(Serializers.JsonObject(value));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var objects = new List<object>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.String)
                    {
                        if (Uri.TryCreate((string)reader.Value, UriKind.RelativeOrAbsolute, out Uri uri))
                        {
                            objects.Add(uri);
                        }
                    }
                    else if (reader.TokenType == JsonToken.EndArray)
                    {
                        return objects;
                    }
                }
            }
            else if (reader.TokenType == JsonToken.String)
            {
                if (Uri.TryCreate((string)reader.Value, UriKind.RelativeOrAbsolute, out Uri uri))
                {
                    return uri;
                }
            }
            throw new JsonSerializationException("Failed to deserialize object.");
        }
        
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }
    }
}