﻿namespace WebServer.Server.HTTP.Contracts
{
    using Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection HeadersCollection { get; }

        //IHttpCookieCollection Cookies { get; }
    }
}
