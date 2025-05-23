using Sitecore.Services.GraphQL.Hosting;
using Sitecore.Services.GraphQL.Hosting.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XmCloudNextJsStarter.Constants;

namespace XmCloudNextJsStarter.Services.Managers
{
    public class GraphQLEndpointManager : Sitecore.Services.GraphQL.Hosting.Configuration.GraphQLEndpointManager,
        IGraphQLEndpointManager
    {
        public new IEnumerable<IGraphQLEndpoint> GetEndpoints()
        {
            // If the request is for a preview endpoint, set the previewedge endpoint first
            // Sitecore.LayoutService.GraphQL.LayoutService.GraphQLAwareRenderingContentsResolver.GetPublicEndpoint()
            // calls this method and takes the first in the list that ends with the string "edge"
            if (!string.IsNullOrEmpty(HttpContext.Current?.Request?.RawUrl) &&
                HttpContext.Current.Request.RawUrl.StartsWith(EdgeConstants.PreviewEdgeUrl))
            {
                return base.GetEndpoints().Reverse();
            }
            return base.GetEndpoints();
        }
    }
}