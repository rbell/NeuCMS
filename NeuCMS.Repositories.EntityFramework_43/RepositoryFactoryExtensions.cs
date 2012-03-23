namespace NeuCMS.Repositories.EntityFramework_43
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