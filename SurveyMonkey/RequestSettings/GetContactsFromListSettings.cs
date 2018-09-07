using Newtonsoft.Json;

namespace SurveyMonkey.RequestSettings
{
    public class GetContactsSettings : IPagingSettings
    {
        public enum StatusOption
        {
            Active,
            Optout,
            Bounced
        }

        public enum SortOrderOption
        {
            ASC,
            DESC
        }

        public enum ByOption
        {
            Email,
            FirstName,
            LastName,

            [JsonProperty(PropertyName = "1")]
            CustomField1,

            [JsonProperty(PropertyName = "2")]
            CustomField2,

            [JsonProperty(PropertyName = "3")]
            CustomField3,

            [JsonProperty(PropertyName = "4")]
            CustomField4,

            [JsonProperty(PropertyName = "5")]
            CustomField5,

            [JsonProperty(PropertyName = "6")]
            CustomField6
        }

        public int? Page { get; set; }
        public int? PerPage { get; set; }
        public StatusOption? Status { get; set; }
        public ByOption? SortBy { get; set; }
        public ByOption? SearchBy { get; set; }
        public string Search { get; set; }
    }
}