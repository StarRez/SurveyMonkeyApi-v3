using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class BulkRecipientResponse
    {
        public List<SuccessfulBulkRecipient> Succeeded { get; set; }
        public string[] Invalids { get; set; }
        public string[] Existing { get; set; }
        public string[] Bounced { get; set; }
        public string[] OptedOut { get; set; }
        public string[] Duplicate { get; set; }
    }
}