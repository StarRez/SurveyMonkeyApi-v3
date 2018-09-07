using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using SurveyMonkey.Containers;
using SurveyMonkey.RequestSettings;

namespace SurveyMonkey
{
    public partial class SurveyMonkeyApi
    {
        public ContactList GetContactList(long contactListId)
        {
            string endPoint = String.Format("/contact_lists/{0}", contactListId);
            var verb = Verb.GET;
            JToken result = MakeApiRequest(endPoint, verb, new RequestData());
            var message = result.ToObject<ContactList>();
            return message;
        }

        public List<ContactList> GetContactLists()
        {
            var settings = new PagingSettings();
            return GetContactListsPager(settings);
        }

        public List<ContactList> GetContactLists(PagingSettings settings)
        {
            return GetContactListsPager(settings);
        }

        private List<ContactList> GetContactListsPager(IPagingSettings settings)
        {
            string endPoint = String.Format("/contact_lists");
            const int maxResultsPerPage = 1000;
            var results = Page(settings, endPoint, typeof(List<ContactList>), maxResultsPerPage);
            return results.ToList().ConvertAll(o => (ContactList)o);
        }

        public List<Contact> GetContactsFromList(long contactListId)
        {
            var settings = new GetContactsSettings();
            return GetContactsFromListPager(contactListId, settings);
        }

        public List<Contact> GetContactsFromList(long contactListId, GetContactsSettings settings)
        {
            return GetContactsFromListPager(contactListId, settings);
        }

        private List<Contact> GetContactsFromListPager(long contactListId, GetContactsSettings settings)
        {
            string endPoint = String.Format("/contact_lists/{0}/contacts", contactListId);
            const int maxResultsPerPage = 1000;
            var results = Page(settings, endPoint, typeof(List<Contact>), maxResultsPerPage);
            return results.ToList().ConvertAll(o => (Contact)o);
        }

        public List<Contact> GetContacts()
        {
            var settings = new GetContactsSettings();
            return GetContactsPager(settings);
        }

        public List<Contact> GetContacts(GetContactsSettings settings)
        {
            return GetContactsPager(settings);
        }

        private List<Contact> GetContactsPager(GetContactsSettings settings)
        {
            string endPoint = "/contacts";
            const int maxResultsPerPage = 1000;
            var results = Page(settings, endPoint, typeof(List<Contact>), maxResultsPerPage);
            return results.ToList().ConvertAll(o => (Contact)o);
        }

        public BulkContactListResponse CreateBulkContactsForList(long contactListId, CreateBulkContactListSettings settings)
        {
            string endPoint = String.Format("/contact_lists/{0}/contacts/bulk", contactListId);
            var verb = Verb.POST;
            var requestData = Helpers.RequestSettingsHelper.GetPopulatedProperties(settings);
            JToken result = MakeApiRequest(endPoint, verb, requestData);
            var response = result.ToObject<BulkContactListResponse>();
            return response;
        }

        public ContactList CreateContactList(CreateContactListSettings settings)
        {
            string endPoint = String.Format("/contact_lists", settings);
            var verb = Verb.POST;
            var requestData = Helpers.RequestSettingsHelper.GetPopulatedProperties(settings);
            JToken result = MakeApiRequest(endPoint, verb, requestData);
            var response = result.ToObject<ContactList>();
            return response;
        }

        public ContactList DeleteContactList(long contactListId)
        {
            string endPoint = String.Format("/contact_lists/{0}", contactListId);
            var verb = Verb.DELETE;
            JToken result = MakeApiRequest(endPoint, verb, new RequestData());
            var response = result.ToObject<ContactList>();
            return response;
        }
    }
}