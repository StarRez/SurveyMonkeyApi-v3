using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class NewContact
    {
        [JsonConverter(typeof(TolerantJsonConverter))]
        public enum StatusOption
        {
            Active,
            Optout,
            Bounced
        }

        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Href { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
        public StatusOption? Status { get; set; }
    }
}