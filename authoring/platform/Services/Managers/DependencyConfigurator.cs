using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Services.GraphQL.Hosting.Configuration;

namespace XmCloudNextJsStarter.Services.Managers
{
    public class DependencyConfigurator : IServicesConfigurator
    {
        public DependencyConfigurator()
        {
        }

        public void Configure(IServiceCollection serviceCollection)
        {
            ServiceCollectionServiceExtensions.AddSingleton<IGraphQLEndpointManager, GraphQLEndpointManager>(serviceCollection);
        }
    }
}