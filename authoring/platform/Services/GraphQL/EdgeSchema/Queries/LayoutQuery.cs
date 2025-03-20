using GraphQL.Types;
using Sitecore.Data.Items;

namespace XmCloudNextJsStarter.Services.GraphQL.EdgeSchema.Queries
{
    public class LayoutQuery : Sitecore.Services.GraphQL.EdgeSchema.Queries.LayoutQuery
    {
        protected override Item Resolve(ResolveFieldContext context)
        {
            return PreviewItemResolver.ResolveWorkflowItem(base.Resolve(context));
        }
    }
}