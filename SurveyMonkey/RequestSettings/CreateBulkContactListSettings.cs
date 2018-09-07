using System.Collections.Generic;
using SurveyMonkey.Containers;

namespace SurveyMonkey.RequestSettings
{
    public class CreateBulkContactListSettings
    {
        public List<NewContact> Contacts { get; set; }
        public bool? UpdateExisting { get; set; }
    }
}