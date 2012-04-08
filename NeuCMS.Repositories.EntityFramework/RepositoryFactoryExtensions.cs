namespace NeuCMS.Repositories.EntityFramework
{
    public static class RepositoryFactoryExtensions
    {
        public static NeuCMS.Core.Repositories.RepositoryFactory UseEntityFramework(this NeuCMS.Core.Repositories.RepositoryFactory repository)
        {
            StructureMap.ObjectFactory.Initialize(i => i.AddRegistry<RepositoryRegistry>());
            return repository;
        }
    }
}