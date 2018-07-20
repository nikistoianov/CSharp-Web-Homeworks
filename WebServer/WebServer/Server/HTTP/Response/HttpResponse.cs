namespace WebServer.Server.Http.Response
{
    using HTTP;
    using HTTP.Contracts;
    using Enums;
    using System.Text;

    public abstract class HttpResponse : IHttpResponse
    {
        private string statusCodeMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.HeadersCollection = new HttpHeaderCollection();
            this.StatusCode = HttpStatusCode.Found;
            
            //this.Cookies = new HttpCookieCollection();
        }

        public IHttpHeaderCollection HeadersCollection { get; }

        //public IHttpCookieCollection Cookies { get; }

        public HttpStatusCode StatusCode { get; protected set; }

        public override string ToString()
        {
            var response = new StringBuilder();

            var statusCodeNumber = (int)this.StatusCode;
            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusCodeMessage}");

            response.AppendLine(this.HeadersCollection.ToString());

            return response.ToString();
        }
    }
}
