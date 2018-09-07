using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class SuccessfulBulkRecipient
    {
        public long? Id { get; set; }
        public string Email { get; set; }
        public string Href { get; set; }
    }
}