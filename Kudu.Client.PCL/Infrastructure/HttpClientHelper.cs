﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Kudu.Client.PCL.Infrastructure
{
    public static class HttpClientHelper
    {
        private static readonly char[] uriPathSeparator = new char[] { '/' };

        public static HttpClient CreateClient(string serviceUrl, ICredentials credentials = null, HttpMessageHandler handler = null, bool useCookies = false)
        {
            if (serviceUrl == null)
            {
                throw new ArgumentNullException("serviceUrl");
            }

            HttpMessageHandler effectiveHandler = handler ?? CreateClientHandler(serviceUrl, credentials, useCookies);
            Uri serviceAddr = new Uri(serviceUrl);
            HttpClient client = new HttpClient(effectiveHandler)
            {
                BaseAddress = serviceAddr,
                MaxResponseContentBufferSize = 30 * 1024 * 1024
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static HttpClientHandler CreateClientHandler(string serviceUrl, ICredentials credentials, bool useCookies = false)
        {
            if (serviceUrl == null)
            {
                throw new ArgumentNullException("serviceUrl");
            }

            // Set up our own HttpClientHandler and configure it
            HttpClientHandler clientHandler = new HttpClientHandler();

            if (credentials != null)
            {
                // Set up credentials cache which will handle basic authentication
                CredentialList credentialCache = new CredentialList();

                // Get base address without terminating slash
                var serviceUri = new Uri(serviceUrl);
                
                // Add credentials to cache and associate with handler
                // Working with concrete implementation of ICredentials, until otherwise needed
                NetworkCredential networkCredentials = (NetworkCredential)credentials;
                credentialCache.Add(serviceUri, "basic", networkCredentials);
                clientHandler.Credentials = credentialCache;
                clientHandler.PreAuthenticate = true;
            }

            // HttpClient's default UseCookies is true (meaning always roundtripping cookie back)
            // However, our api will default to false to cover multiple instance scenarios
            clientHandler.UseCookies = useCookies;

            // Our handler is ready
            return clientHandler;
        }

        public static HttpContent CreateJsonContent(params KeyValuePair<string, string>[] items)
        {
            var jsonObject = new JObject();
            foreach (KeyValuePair<string, string> kv in items)
            {
                jsonObject.Add(kv.Key, kv.Value);
            }
            return new ObjectContent(typeof(JObject), jsonObject, new JsonMediaTypeFormatter());
        }
    }
}
