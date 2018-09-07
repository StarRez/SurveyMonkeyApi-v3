using SurveyMonkey.Enums;

namespace SurveyMonkey.RequestSettings
{
    public class CreateNewMessageSettings
    {
        public MessageType Type { get; set; }
        public MessageRecipientStatus? RecipientStatus { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
        public string BodyHtml { get; set; }
        public bool? IsBrandingEnabled { get; set; }
    }
}