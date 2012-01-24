using StructureMap;

namespace NeuCMS.Core.Repositories
{
    public class RepositoryFactory
    {
         public IContentRepository ContentRepository()
         {
             return ObjectFactory.GetInstance<IContentRepository>();
         }
    }
}