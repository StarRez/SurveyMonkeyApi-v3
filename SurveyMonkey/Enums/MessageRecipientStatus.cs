using Newtonsoft.Json;

namespace SurveyMonkey.Enums
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public enum MessageRecipientStatus
    {
        HasNotResponded,
        PartiallyResponded,
        Completed,
        Responded
    }
}