using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class BulkContactListResponse
    {
        public List<NewContact> Succeeded { get; set; }
        public List<NewContact> Invalid { get; set; }
        public List<NewContact> Existing { get; set; }
    }
}