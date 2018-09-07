﻿using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace SurveyMonkey
{
    internal interface IWebClient
    {
        WebHeaderCollection Headers { get; set; }
        WebHeaderCollection ResponseHeaders { get; }
        NameValueCollection QueryString { get; set; }
        Encoding Encoding { get; set; }
        IWebProxy Proxy { get; set; }

        string DownloadString(string url);

        string UploadString(string url, string verb, string body);

        void Dispose();
    }
}