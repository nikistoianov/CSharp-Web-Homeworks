﻿namespace WebServer.Server.HTTP
{
    public class HttpHeader
    {
        public const string Host = "Host";

        public HttpHeader(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
        {
            return this.Key + ": " + this.Value;
        }
    }
}
