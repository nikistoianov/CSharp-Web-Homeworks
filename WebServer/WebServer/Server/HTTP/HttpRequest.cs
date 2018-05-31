namespace WebServer.Server.HTTP
{
    using System.Collections.Generic;
    using Contracts;
    using WebServer.Server.Enums;

    class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path => throw new System.NotImplementedException();

        public Dictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod RequestMethod => throw new System.NotImplementedException();

        public string Url => throw new System.NotImplementedException();

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameters(string key, string value)
        {
            throw new System.NotImplementedException();
        }
    }
}
