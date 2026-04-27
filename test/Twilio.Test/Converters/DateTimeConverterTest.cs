using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using Twilio.Converters;

namespace Twilio.Tests.Converters
{
    [TestFixture]
    public class DateTimeConverterTest
    {
        private class SingleDateModel
        {
            [JsonConverter(typeof(DateTimeConverter))]
            public DateTime? Date { get; set; }
        }

        private class DateListModel
        {
            [JsonConverter(typeof(DateTimeConverter))]
            public List<DateTime> Dates { get; set; }
        }

        [Test]
        public void TestDeserializeNullToken()
        {
            var json = "{\"Date\": null}";
            var result = JsonConvert.DeserializeObject<SingleDateModel>(json);
            Assert.IsNull(result.Date);
        }

        [Test]
        public void TestDeserializeDateToken()
        {
            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.DateTime };
            var json = "{\"Date\": \"2024-06-15T10:30:00Z\"}";
            var result = JsonConvert.DeserializeObject<SingleDateModel>(json, settings);
            Assert.IsNotNull(result.Date);
            Assert.AreEqual(2024, result.Date.Value.Year);
            Assert.AreEqual(6, result.Date.Value.Month);
            Assert.AreEqual(15, result.Date.Value.Day);
        }

        [Test]
        public void TestDeserializeDateTimeOffsetToken()
        {
            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.DateTimeOffset };
            var json = "{\"Date\": \"2024-06-15T10:30:00Z\"}";
            var result = JsonConvert.DeserializeObject<SingleDateModel>(json, settings);
            Assert.IsNotNull(result.Date);
            Assert.AreEqual(2024, result.Date.Value.Year);
            Assert.AreEqual(6, result.Date.Value.Month);
            Assert.AreEqual(15, result.Date.Value.Day);
        }

        [Test]
        public void TestDeserializeStringToken()
        {
            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.None };
            var json = "{\"Date\": \"2024-06-15T10:30:00Z\"}";
            var result = JsonConvert.DeserializeObject<SingleDateModel>(json, settings);
            Assert.IsNotNull(result.Date);
            Assert.AreEqual(2024, result.Date.Value.Year);
        }

        [Test]
        public void TestDeserializeArrayOfDateStrings()
        {
            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.None };
            var json = "{\"Dates\": [\"2024-01-01T00:00:00Z\", \"2024-12-31T00:00:00Z\"]}";
            var result = JsonConvert.DeserializeObject<DateListModel>(json, settings);
            Assert.AreEqual(2, result.Dates.Count);
            Assert.AreEqual(1, result.Dates[0].Month);
            Assert.AreEqual(12, result.Dates[1].Month);
        }

        [Test]
        public void TestDeserializeArrayOfDateTokens()
        {
            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.DateTime };
            var json = "{\"Dates\": [\"2024-01-01T00:00:00Z\", \"2024-12-31T00:00:00Z\"]}";
            var result = JsonConvert.DeserializeObject<DateListModel>(json, settings);
            Assert.AreEqual(2, result.Dates.Count);
            Assert.AreEqual(1, result.Dates[0].Month);
            Assert.AreEqual(12, result.Dates[1].Month);
        }

        [Test]
        public void TestDeserializeArrayOfDateTimeOffsetTokens()
        {
            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.DateTimeOffset };
            var json = "{\"Dates\": [\"2024-01-01T00:00:00Z\", \"2024-12-31T00:00:00Z\"]}";
            var result = JsonConvert.DeserializeObject<DateListModel>(json, settings);
            Assert.AreEqual(2, result.Dates.Count);
            Assert.AreEqual(1, result.Dates[0].Month);
            Assert.AreEqual(12, result.Dates[1].Month);
        }

        [Test]
        public void TestDeserializeInvalidTokenThrows()
        {
            var json = "{\"Date\": 12345}";
            Assert.Throws<JsonSerializationException>(() =>
                JsonConvert.DeserializeObject<SingleDateModel>(json));
        }
    }
}
