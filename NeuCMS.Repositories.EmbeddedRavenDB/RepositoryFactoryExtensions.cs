namespace NeuCMS.Repositories.EmbeddedRavenDB
{
    public static class RepositoryFactoryExtensions
    {
        public static NeuCMS.Core.Repositories.RepositoryFactory UseEmbeddedRavenDB(this NeuCMS.Core.Repositories.RepositoryFactory repository)
        {
            StructureMap.ObjectFactory.Initialize(i => i.AddRegistry<RepositoryRegistry>());
            return repository;
        }
    }
}