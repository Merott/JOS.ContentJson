﻿using System;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;

namespace Jos.ContentJson.Extensions
{
    public static class UrlExtensions
    {
        public static string ToPrettyUrl(this Url url, bool getAbsoluteUrl = false)
        {
            if (url.Scheme == "mailto") return url.OriginalString;

            var helper = ServiceLocator.Current.GetInstance<UrlHelper>();
            var prettyUrl = helper.ContentUrl(url);

            if (getAbsoluteUrl && !url.IsAbsoluteUri)
            {
                var baseUri = new Uri(GetBaseUrl());
                var uri = new Uri(baseUri, prettyUrl);
                return uri.AbsoluteUri;
            }

            return prettyUrl;
        }

        private static string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var host = request.Url.Host;
            var scheme = request.Url.Scheme;
            var port = request.Url.Port;

            if (port == 80 || port == 443)
            {
                var baseUrl = $"{scheme}://{host}";
                return baseUrl;
            }

            return $"{scheme}://{host}:{port}";
        }
    }
}
