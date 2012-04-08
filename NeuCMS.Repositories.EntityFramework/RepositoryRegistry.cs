using NeuCMS.Core.Repositories;
using NeuCMS.Repositories.EntityFramework;
using StructureMap.Configuration.DSL;

namespace NeuCMS.Repositories.EntityFramework
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IContentRepository>().Use<ContentRepository>();
        }

    }
}