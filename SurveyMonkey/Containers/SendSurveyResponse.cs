using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SurveyMonkey.Enums;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class SendSurveyResponse
    {
        public string Body { get; set; }
        public bool? IsScheduled { get; set; }
        public RecipientStatus? RecipientStatus { get; set; }
        public List<long> Recipients { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string Subject { get; set; }
        public MessageType? Type { get; set; }
    }
}