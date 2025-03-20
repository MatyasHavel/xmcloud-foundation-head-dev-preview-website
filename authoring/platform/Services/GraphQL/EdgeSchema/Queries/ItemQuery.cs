using GraphQL.Types;
using Sitecore.Data.Items;

namespace XmCloudNextJsStarter.Services.GraphQL.EdgeSchema.Queries
{
    public class ItemQuery : Sitecore.Services.GraphQL.EdgeSchema.Queries.ItemQuery
    {
        protected override Item Resolve(ResolveFieldContext context)
        {
            return PreviewItemResolver.ResolveWorkflowItem(base.Resolve(context));
        }
    }
}