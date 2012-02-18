namespace NeuCMS.Core.Entities
{
    public class ContentMetadataDefinition : IEntity
    {
        public string Id { get; set; }

        public string NamespaceId { get; set; }

        public string NameSpace { get; set; }

        public string MetadataName { get; set; }

        //TODO: Other properties that define rules for Metadata values (i.e. Regex)
    }
}