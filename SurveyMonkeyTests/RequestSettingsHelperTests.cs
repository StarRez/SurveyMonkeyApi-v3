using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SurveyMonkey.Containers;
using SurveyMonkey.Helpers;
using SurveyMonkey.RequestSettings;

namespace SurveyMonkeyTests
{
    [TestFixture]
    internal class RequestSettingsHelperTests
    {
        [Test]
        public void ObjectPropertiesAreProcessed()
        {
            var input = new LotsOfProperties()
            {
                Time1 = new DateTime(2016, 5, 1, 12, 30, 18, DateTimeKind.Utc),
                String1 = "A string",
                Int1 = 1234,
                Long1 = 3216549874654984,
                EnumCamel1 = GetSurveyListSettings.SortByOption.NumResponses,
                EnumCaps1 = GetSurveyListSettings.SortOrderOption.DESC,
                ListTime1 = new List<DateTime> { new DateTime(2015, 4, 2, 10, 19, 12, DateTimeKind.Utc) },
                ListString1 = new List<string> { "asdf", "ghjk", "qwer" },
                ListInt1 = new List<int> { 1, 5, 0, 94 },
                ListLong1 = new List<long> { 42, 918274828787344, 9827, 5219258, 51928375123857 },
                ComplexObject = new ComplexObject
                {
                    Time1 = new DateTime(2016, 5, 1, 12, 30, 18, DateTimeKind.Utc),
                    String1 = "A string",
                    Int1 = 1234,
                    Long1 = 3216549874654984,
                    EnumCamel1 = GetSurveyListSettings.SortByOption.NumResponses,
                    EnumCaps1 = GetSurveyListSettings.SortOrderOption.DESC,
                    ListTime1 = new List<DateTime> { new DateTime(2015, 4, 2, 10, 19, 12, DateTimeKind.Utc) },
                    ListString1 = new List<string> { "asdf", "ghjk", "qwer" },
                    ListInt1 = new List<int> { 1, 5, 0, 94 },
                    ListLong1 = new List<long> { 42, 918274828787344, 9827, 5219258, 51928375123857 }
                },
                ListComplexObject = new List<ComplexObject>
                {
                    new ComplexObject
                    {
                        Time1 = new DateTime(2016, 5, 1, 12, 30, 18, DateTimeKind.Utc),
                        String1 = "A string",
                        Int1 = 1234,
                        Long1 = 3216549874654984,
                        EnumCamel1 = GetSurveyListSettings.SortByOption.NumResponses,
                        EnumCaps1 = GetSurveyListSettings.SortOrderOption.DESC,
                        ListTime1 = new List<DateTime> { new DateTime(2015, 4, 2, 10, 19, 12, DateTimeKind.Utc) },
                        ListString1 = new List<string> { "asdf", "ghjk", "qwer" },
                        ListInt1 = new List<int> { 1, 5, 0, 94 },
                        ListLong1 = new List<long> { 42, 918274828787344, 9827, 5219258, 51928375123857 }
                    },
                    new ComplexObject
                    {
                        Time1 = new DateTime(2016, 5, 1, 12, 30, 18, DateTimeKind.Utc),
                        String1 = "A string 1",
                        Int1 = 12345,
                        Long1 = 3216549874654984,
                        EnumCamel1 = GetSurveyListSettings.SortByOption.NumResponses,
                        EnumCaps1 = GetSurveyListSettings.SortOrderOption.DESC,
                        ListTime1 = new List<DateTime> { new DateTime(2015, 4, 2, 10, 19, 12, DateTimeKind.Utc) },
                        ListString1 = new List<string> { "asdf", "ghjk", "qwer" },
                        ListInt1 = new List<int> { 1, 5, 0, 94 },
                        ListLong1 = new List<long> { 42, 918274828787344, 9827, 5219258, 51928375123857 }
                    }
                }
            };
            var result = RequestSettingsHelper.GetPopulatedProperties(input);
            Assert.AreEqual("2016-05-01T12:30:18", result["time_1"]);
            Assert.AreEqual("A string", result["string_1"]);
            Assert.AreEqual(1234, result["int_1"]);
            Assert.AreEqual("3216549874654984", result["long_1"]);
            Assert.AreEqual("num_responses", result["enum_camel_1"]);
            Assert.AreEqual("DESC", result["enum_caps_1"]);
            Assert.AreEqual("2015-04-02T10:19:12", ((List<string>)result["list_time_1"]).First());
            Assert.AreEqual("qwer", ((List<string>)result["list_string_1"]).Last());
            Assert.AreEqual(94, ((List<int>)result["list_int_1"]).Last());
            Assert.AreEqual("918274828787344", ((List<string>)result["list_long_1"]).Skip(1).First());
            Assert.AreEqual(51928375123857, ((ComplexObject)result["complex_object"]).ListLong1.Last());
            Assert.AreEqual(1234, ((((List<RequestData>)result["list_complex_object"]).First())["int_1"]));
            Assert.AreEqual(12, result.Count);
        }

        [Test]
        public void BulkRecipientResponseSettingsAreProcessed()
        {
            var input = new BulkRecipientSettings()
            {
                Contacts = new List<Contact>
                {
                    new Contact()
                    {
                        FirstName = "First",
                        LastName = "Last",
                        Email = "email"
                    },
                    new Contact()
                    {
                        FirstName = "First2",
                        LastName = "Last2",
                        Email = "email2"
                    }
                }
            };
            var result = RequestSettingsHelper.GetPopulatedProperties(input);
            Assert.AreEqual("First", ((List<RequestData>)result["contacts"])[0]["first_name"]);
            Assert.AreEqual("Last", ((List<RequestData>)result["contacts"])[0]["last_name"]);
            Assert.AreEqual("email", ((List<RequestData>)result["contacts"])[0]["email"]);
            Assert.AreEqual("First2", ((List<RequestData>)result["contacts"])[1]["first_name"]);
            Assert.AreEqual("Last2", ((List<RequestData>)result["contacts"])[1]["last_name"]);
            Assert.AreEqual("email2", ((List<RequestData>)result["contacts"])[1]["email"]);
        }
    }

    internal class LotsOfProperties
    {
        public DateTime? Time1 { get; set; }
        public DateTime? Time2 { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public int? Int1 { get; set; }
        public int? Int2 { get; set; }
        public long? Long1 { get; set; }
        public long? Long2 { get; set; }
        public GetSurveyListSettings.SortByOption? EnumCamel1 { get; set; }
        public GetSurveyListSettings.SortByOption? EnumCamel2 { get; set; }
        public GetSurveyListSettings.SortOrderOption? EnumCaps1 { get; set; }
        public GetSurveyListSettings.SortOrderOption? EnumCaps2 { get; set; }
        public List<DateTime> ListTime1 { get; set; }
        public List<DateTime> ListTime2 { get; set; }
        public List<string> ListString1 { get; set; }
        public List<string> ListString2 { get; set; }
        public List<int> ListInt1 { get; set; }
        public List<int> ListInt2 { get; set; }
        public List<long> ListLong1 { get; set; }
        public List<long> ListLong2 { get; set; }
        public ComplexObject ComplexObject { get; set; }
        public List<ComplexObject> ListComplexObject { get; set; }
    }

    internal class ComplexObject
    {
        public DateTime? Time1 { get; set; }
        public string String1 { get; set; }
        public int? Int1 { get; set; }
        public long? Long1 { get; set; }
        public GetSurveyListSettings.SortByOption? EnumCamel1 { get; set; }
        public GetSurveyListSettings.SortOrderOption? EnumCaps1 { get; set; }
        public List<DateTime> ListTime1 { get; set; }
        public List<string> ListString1 { get; set; }
        public List<int> ListInt1 { get; set; }
        public List<long> ListLong1 { get; set; }
    }
}