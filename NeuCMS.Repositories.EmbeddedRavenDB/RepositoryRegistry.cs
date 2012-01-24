using NeuCMS.Core.Repositories;
using StructureMap.Configuration.DSL;

namespace NeuCMS.Repositories.EmbeddedRavenDB
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IContentRepository>().Use<Repository>().Ctor<IRepositoryContext>().Is<RepositoryContext>();
        }

    }
}