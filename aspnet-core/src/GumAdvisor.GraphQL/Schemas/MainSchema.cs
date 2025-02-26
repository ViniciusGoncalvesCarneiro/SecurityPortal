using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using GumAdvisor.Queries.Container;
using System;

namespace GumAdvisor.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}