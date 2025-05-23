﻿using Sitecore.Links.UrlBuilders;
using System;
using System.Web;
using XmCloudNextJsStarter.Constants;

namespace XmCloudNextJsStarter.LinkManagers
{
    public class MediaUrlBuilder : Sitecore.ExperienceEdge.Connector.ContentHubDelivery.UrlBuilder.DeliveryMediaUrlBuilder
    {
        protected const string _edgeTenantEnvVar = "SUGCZ_EDGE_TENANT";

        protected const string _forceHttpProtocol = "SUGCZ_FORCE_MEDIA_HTTP";

        protected const string _edgePublicUrl = "https://edge.sitecorecloud.io";

        public MediaUrlBuilder(DefaultMediaUrlBuilderOptions defaultOptions, string mediaLinkPrefix)
            : base(defaultOptions, mediaLinkPrefix)
        {
        }

        protected override void AddPrefix(UrlBuildModel model, MediaUrlBuilderOptions options)
        {
            base.AddPrefix(model, options);
            if (!string.IsNullOrEmpty(HttpContext.Current?.Request?.RawUrl) &&
                HttpContext.Current.Request.RawUrl.StartsWith(EdgeConstants.PreviewEdgeUrl) &&
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(_edgeTenantEnvVar)))
            {
                model.Prefix = $"/{Environment.GetEnvironmentVariable(_edgeTenantEnvVar)}/media/";
            }
        }

        protected override void AddServer(UrlBuildModel model, MediaUrlBuilderOptions options)
        {
            base.AddServer(model, options);
            if (!string.IsNullOrEmpty(HttpContext.Current?.Request?.RawUrl) &&
                HttpContext.Current.Request.RawUrl.StartsWith(EdgeConstants.PreviewEdgeUrl) && 
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(_edgeTenantEnvVar)))
            {
                model.Server = _edgePublicUrl;
            }
            if (Environment.GetEnvironmentVariable(_forceHttpProtocol) == "1"
                && !string.IsNullOrEmpty(model.Server))
            {
                model.Server = model.Server.Replace("https://", "http://");
            }
        }
    }
}