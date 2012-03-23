using NeuCMS.Core.Repositories;
using StructureMap.Configuration.DSL;

namespace NeuCMS.Repositories.EntityFramework_43
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IContentRepository>().Use<ContentRepository>();
        }

    }
}