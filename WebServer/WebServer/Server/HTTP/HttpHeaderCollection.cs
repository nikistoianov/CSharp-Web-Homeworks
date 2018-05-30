namespace WebServer.Server.HTTP
{
    using Contracts;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;
        
        public HttpHeaderCollection()
        {
            headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            
        }

        public bool ContainsKey(string key)
        {

            return false;
        }

        public HttpHeader GetHeader(string key)
        {

            return null;
        }

        public override string ToString()
        {
            return string.Join("\n", this.headers);
        }
    }
}
