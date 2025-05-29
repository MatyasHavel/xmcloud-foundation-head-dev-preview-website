using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using System.Web;
using XmCloudNextJsStarter.Constants;
using XmCloudNextJsStarter.Services.GraphQL.EdgeSchema.Queries;

namespace XmCloudNextJsStarter.LayoutService.Serialization
{
    public class RenderingContentsResolver : Sitecore.XA.JSS.Foundation.Presentation.ContentsResolvers.RenderingContentsResolver
    {
        //protected override IGraphQLEndpoint GetPublicEndpoint()
        //{
        //  Set after DEVEX-4948 is published
        //}

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            // Datasource check
            if (!string.IsNullOrEmpty(HttpContext.Current?.Request?.RawUrl) &&
                HttpContext.Current.Request.RawUrl.StartsWith(EdgeConstants.PreviewEdgeUrl))
            {
                if (!string.IsNullOrEmpty(rendering.DataSource))
                {
                    var item = PreviewItemResolver.ResolveWorkflowItem(Sitecore.Context.Database.GetItem(rendering.DataSource));
                    if (item == null)
                    {
                        return string.Empty;
                    }
                }
            }
            return base.ResolveContents(rendering, renderingConfig);
        }
    }
}