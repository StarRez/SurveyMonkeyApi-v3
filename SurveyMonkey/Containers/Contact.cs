using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class Contact : IPageableContainer
    {
        public long? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Href { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
        public Dictionary<string, string> ExtraFields { get; set; }
    }
}