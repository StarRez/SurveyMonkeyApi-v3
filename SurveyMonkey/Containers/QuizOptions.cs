using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    [JsonConverter(typeof(TolerantJsonConverter))]
    public class QuizOptions
    {
        public int? Score { get; set; }
    }
}