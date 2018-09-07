using System.Collections.Generic;
using SurveyMonkey.Containers;

namespace SurveyMonkey.RequestSettings
{
    public class BulkRecipientSettings
    {
        public List<Contact> Contacts { get; set; }
        public string[] ContactListIds { get; set; }
    }
}