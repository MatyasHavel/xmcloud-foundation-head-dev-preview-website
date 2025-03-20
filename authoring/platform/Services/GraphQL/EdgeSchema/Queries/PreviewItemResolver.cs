using Sitecore;
using Sitecore.Data.Items;
using System;
using System.Linq;

namespace XmCloudNextJsStarter.Services.GraphQL.EdgeSchema.Queries
{
    public static class PreviewItemResolver
    {
        private const string WorkflowDraftStateID = "{7562DF15-009C-437A-9288-A766CBC209F1}";

        /// <summary>
        /// Resolves latest not draft item version
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item ResolveWorkflowItem(Item item)
        {
            if (item != null)
            {
                // Last not draft version
                if (item.Fields[FieldIDs.WorkflowState] != null
                    && item.Fields[FieldIDs.WorkflowState].Value.Equals(WorkflowDraftStateID, StringComparison.OrdinalIgnoreCase))
                {
                    item = item.Versions.GetOlderVersions()
                        .Reverse()
                        .FirstOrDefault(x => !x.Fields[FieldIDs.WorkflowState].Value.Equals(WorkflowDraftStateID, StringComparison.OrdinalIgnoreCase));
                }
            }
            return item;
        }
    }
}