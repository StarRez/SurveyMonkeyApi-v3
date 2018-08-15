﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using SurveyMonkey;

namespace SurveyMonkeyTests
{
    internal class MockWebClient : IWebClient
    {
        public List<MockWebClientRequest> Requests { get; set; }
        public List<string> Responses { get; set; }
        public List<Exception> Exceptions { get; set; }
        private int _nextResponseSequence;
        private Stopwatch _stopwatch = Stopwatch.StartNew();

        public MockWebClient()
        {
            Headers = new WebHeaderCollection();
            ResponseHeaders = new WebHeaderCollection();
            QueryString = new NameValueCollection();
            Requests = new List<MockWebClientRequest>();
            Responses = new List<string>();
            Exceptions = new List<Exception>();
        }

        private void RecordRequest(string url, string verb, string body)
        {
            Requests.Add(new MockWebClientRequest
            {
                TimeSinceInitialisation = _stopwatch.ElapsedMilliseconds,
                Encoding = Encoding,
                Headers = Headers,
                ResponseHeaders = ResponseHeaders,
                QueryString = QueryString,
                Url = url,
                Verb = verb,
                Body = body
            });
        }

        private string GetNextData()
        {
            var response = Responses.Skip(_nextResponseSequence).FirstOrDefault();
            var exception = Exceptions.Skip(_nextResponseSequence).FirstOrDefault();
            _nextResponseSequence++;
            if (exception != null)
            {
                throw exception;
            }
            return response;
        }

        #region Interface

        public WebHeaderCollection Headers { get; set; }
        public WebHeaderCollection ResponseHeaders { get; set; }
        public NameValueCollection QueryString { get; set; }
        public Encoding Encoding { get; set; }
        public IWebProxy Proxy { get; set; }

        public string DownloadString(string url)
        {
            RecordRequest(url, "NOT SUPPLIED", "NOT SUPPLIED");
            return GetNextData();
        }

        public string UploadString(string url, string verb, string body)
        {
            RecordRequest(url, verb, body);
            return GetNextData();
        }

        public void Dispose()
        {
        }

        #endregion Interface
    }
}