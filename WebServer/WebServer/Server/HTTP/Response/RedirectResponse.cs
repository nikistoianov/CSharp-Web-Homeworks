namespace WebServer.Server.HTTP.Response
{
    using Enums;
    using Http.Response;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;

            this.HeadersCollection.Add(HttpHeader.Location, redirectUrl);
        }
    }
}
