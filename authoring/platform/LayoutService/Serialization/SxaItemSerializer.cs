using Sitecore.Data.Items;
using Sitecore.LayoutService.Serialization.Pipelines.GetFieldSerializer;
using Sitecore.LayoutService.Serialization;
using System.Web;
using XmCloudNextJsStarter.Services.GraphQL.EdgeSchema.Queries;
using XmCloudNextJsStarter.Constants;

namespace XmCloudNextJsStarter.LayoutService.Serialization
{
    public class SxaItemSerializer : Sitecore.XA.JSS.Foundation.Presentation.Serialization.SxaItemSerializer
    {
        public SxaItemSerializer(IGetFieldSerializerPipeline getFieldSerializerPipeline) : base(getFieldSerializerPipeline)
        {
        }

        protected override string SerializeItem(Item item, SerializationOptions options)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current?.Request?.RawUrl) &&
                HttpContext.Current.Request.RawUrl.StartsWith(EdgeConstants.PreviewEdgeUrl))
            {
                // Edge Preview - get item according to workflow state
                return base.SerializeItem(PreviewItemResolver.ResolveWorkflowItem(item), options);
            }
            return base.SerializeItem(item, options);
        }
    }
}