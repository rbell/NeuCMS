namespace NeuCMS.Core.Entities
{
    public class ContentNameSpace : IEntity
    {
        public string Id { get; set; }
        public string NamespaceDefinitionId { get; set; }
        public string NameSpace { get; set; }
        public string Description { get; set; }
    }
}